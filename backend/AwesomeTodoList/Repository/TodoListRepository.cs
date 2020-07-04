using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AwesomeTodoList.Model;
using Dapper;
using SqlKata;
using SqlKata.Compilers;

namespace AwesomeTodoList.Repository
{
    public class TodoListRepository : SqLiteBaseRepository, ITodoListRepository
    {
        public IEnumerable<TodoList> GetAll()
        {
            if (!File.Exists(DbFile)) return Enumerable.Empty<TodoList>();

            using (var cnn = SimpleDbConnection())
            {
                var compiler = new SqliteCompiler();
                var query = new Query("TodoList");
                SqlResult result = compiler.Compile(query);

                cnn.Open();
                return cnn.Query<TodoList>(result.Sql);
            }
        }

        public TodoList Get(int todoListId)
        {
            if (!File.Exists(DbFile)) return new TodoList();

            using (var cnn = SimpleDbConnection())
            {
                var compiler = new SqliteCompiler();
                var query = new Query("TodoList").Where("Id", todoListId);
                SqlResult result = compiler.Compile(query);

                cnn.Open();
                return cnn.Query<TodoList>(result.Sql).FirstOrDefault();
            }
        }

        public void Save(TodoList todoList)
        {
            if (!File.Exists(DbFile))
            {
                CreateDatabase();
            }

            using (var cnn = SimpleDbConnection())
            {
                var compiler = new SqliteCompiler();
                var query = new Query("TodoList").AsInsert(new {
                    Name = todoList.Name
                }, returnId: true);
                SqlResult result = compiler.Compile(query);

                Console.WriteLine(result.Sql);

                cnn.Open();
                todoList.Id = cnn.Query<int>(
                    @"INSERT INTO TodoList
                    ( Name ) VALUES
                    ( @Name );
                    select last_insert_rowid()", todoList).First();
            }
        }

        public void SetDone(int todoListId)
        {
            if (!File.Exists(DbFile)) throw new System.Exception("The DbFile doesn't exists.");

            using (var cnn = SimpleDbConnection())
            {
                var done = DateTime.UtcNow;
                cnn.Open();
                cnn.Execute(
                    @"UPDATE TodoList
                    SET Done = @done
                    WHERE Id = @todoListId", new { done, todoListId });
            }
        }
    }
}
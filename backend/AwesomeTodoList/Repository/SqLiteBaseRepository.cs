using System;
using System.Data.SQLite;
using Dapper;

namespace AwesomeTodoList.Repository
{
    public class SqLiteBaseRepository
    {
        public static string DbFile
        {
            get { return Environment.CurrentDirectory + "\\SimpleDb.sqlite"; }
        }

        public static SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }

        public static void CreateDatabase()
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                cnn.Execute(
                    @"create table TodoList
                    (
                        Id      integer primary key AUTOINCREMENT,
                        Name    varchar(250) not null,
                        Done    datetime null
                    )");
            }
        }
    }
}
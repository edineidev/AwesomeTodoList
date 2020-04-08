using System.Collections.Generic;
using AwesomeTodoList.Model;

namespace AwesomeTodoList.Repository
{
    public interface ITodoListRepository
    {
        IEnumerable<TodoList> GetAll();
         TodoList Get(int todoListId);
         void Save(TodoList todoList);
         void SetDone(int todoListId);
    }
}
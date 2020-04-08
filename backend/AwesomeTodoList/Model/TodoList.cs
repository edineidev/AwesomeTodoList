using System;

namespace AwesomeTodoList.Model
{
    public class TodoList
    {
        public TodoList()
        {
        }
        
        public TodoList(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Done { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeTodoList.Model;
using AwesomeTodoList.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AwesomeTodoList.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ILogger<TodoListController> _logger;
        private readonly ITodoListRepository _todoListRepository;

        public TodoListController(ILogger<TodoListController> logger,
            ITodoListRepository todoListRepository)
        {
            _logger = logger;
            _todoListRepository = todoListRepository;
        }

        [HttpGet]
        public IEnumerable<TodoList> Get() => _todoListRepository.GetAll();

        [HttpGet("{todoListId}", Name = "Get")]
        public TodoList Get([FromRoute] int todoListId) => _todoListRepository.Get(todoListId);

        [HttpPost]
        public void Post([FromBody] string todoName)
        {
            var todoList = new TodoList(todoName);
            _todoListRepository.Save(todoList);
        }

        [HttpPut("{todoListId}", Name = "SetDone")]
        public void SetDone([FromRoute] int todoListId)
        {
            _logger.LogInformation($"todoListId: {todoListId}");
            _todoListRepository.SetDone(todoListId);
        }
    }
}

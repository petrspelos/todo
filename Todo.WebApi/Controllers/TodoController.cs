using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Todo.WebApi.Storage;
using Todo.WebApi.Entities;
using System.Linq;
using System;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IReadWriteStorage<TodoList> _storage;

        public TodoController(IReadWriteStorage<TodoList> storage)
        {
            _storage = storage;
        }

        [HttpGet("list")]
        public IActionResult ListAll()
        {
            var list = GetPublicList();
            if(list is null) { return NotFound("The public list doesn't exist."); }

            return new JsonResult(list.Tasks);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody]TodoTask task)
        {
            var list = GetPublicList();
            if(list is null) { return NotFound("The public list doesn't exist."); }

            task.Id = Guid.NewGuid();

            list.Tasks.Add(task);
            _storage.Store(list);

            return Ok();
        }

        [HttpDelete("remove")]
        public IActionResult Remove([FromBody]Guid id)
        {
            var list = GetPublicList();
            if(list is null) { return NotFound("The public list doesn't exist."); }

            var taskToDelete = list.Tasks.FirstOrDefault(t => t.Id == id);

            if(taskToDelete is null) { return BadRequest("A task with this ID doesn't exist."); }

            list.Tasks.Remove(taskToDelete);
            _storage.Store(list);

            return Ok("Task removed.");
        }

        private TodoList GetPublicList() => _storage.GetAll().FirstOrDefault(l => l.Name == "public");
    }
}

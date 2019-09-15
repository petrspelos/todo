using System.Collections.Generic;
using ToDo.WebApi.Models;

namespace ToDo.WebApi.UseCases.ListTodos
{
    public sealed class ListTodosResponse
    {
        public IEnumerable<TodoTaskModel> Tasks { get; set; }
    }
}

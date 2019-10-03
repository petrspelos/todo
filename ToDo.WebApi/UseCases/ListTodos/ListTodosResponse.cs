using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDo.WebApi.Models;

namespace ToDo.WebApi.UseCases.ListTodos
{
    public sealed class ListTodosResponse
    {
        public IEnumerable<TodoTaskModel> Tasks { get; set; }

        public ListTodosResponse()
        {
            Tasks = new Collection<TodoTaskModel>();
        }
    }
}

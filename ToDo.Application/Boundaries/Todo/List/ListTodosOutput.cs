using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDo.Domain.Todos;

namespace ToDo.Application.Boundaries.Todo.List
{
    public class ListTodosOutput
    {
        public IEnumerable<TodoTask> Tasks { get; private set; }

        public ListTodosOutput(IEnumerable<TodoTask> tasks)
        {
            Tasks = tasks ?? new Collection<TodoTask>();
        }
    }
}

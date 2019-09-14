using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDo.Domain.Todos;

namespace ToDo.Infrastructure.InMemoryStorage
{
    public sealed class ToDoContext
    {
        public ICollection<TodoTask> TodoTasks { get; set; }

        public ToDoContext()
        {
            TodoTasks = new Collection<TodoTask>();
        }
    }
}

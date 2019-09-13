using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDo.Domain.Todos;

namespace ToDo.Infrastructure.InMemoryStorage
{
    public sealed class ToDoContext
    {
        public ICollection<TodoList> TodoLists { get; set; }

        public ToDoContext()
        {
            TodoLists = new Collection<TodoList>
            {
                new TodoList(Guid.NewGuid(), "public", new Collection<TodoTask>())
            };
        }
    }
}

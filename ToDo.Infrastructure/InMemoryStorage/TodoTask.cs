using System;

namespace ToDo.Infrastructure.InMemoryStorage
{
    public sealed class TodoTask : ToDo.Domain.Todos.TodoTask
    {
        public TodoTask()
        {
            Id = Guid.NewGuid();
        }
    }
}

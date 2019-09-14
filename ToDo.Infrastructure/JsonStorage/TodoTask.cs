using System;

namespace ToDo.Infrastructure.JsonStorage
{
    public sealed class TodoTask : ToDo.Domain.Todos.TodoTask
    {
        public TodoTask()
        {
            Id = Guid.NewGuid();
        }
    }
}

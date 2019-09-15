using System;
using ToDo.Domain.Todos;

namespace ToDo.Application.Boundaries.Todo.Remove
{
    public sealed class RemoveTodoOutput
    {
        public Guid Id { get; private set; }

        public RemoveTodoOutput(ITodoTask t)
        {
            Id = ((TodoTask)t).Id;
        }
    }
}

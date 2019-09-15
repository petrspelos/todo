using System;

namespace ToDo.Application.Boundaries.Todo.Remove
{
    public sealed class RemoveTodoInput
    {
        public Guid Id { get; private set; }

        public RemoveTodoInput(Guid id)
        {
            Id = id;
        }
    }
}

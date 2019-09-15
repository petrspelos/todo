using System;

namespace ToDo.Application.Boundaries.Event.Remove
{
    public sealed class RemoveEventInput
    {
        public Guid Id { get; private set; }

        public RemoveEventInput(Guid id)
        {
            Id = id;
        }
    }
}

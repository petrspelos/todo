using System;
using ToDo.Domain.Events;

namespace ToDo.Application.Boundaries.Event.Remove
{
    public sealed class RemoveEventOutput
    {
        public Guid EventId { get; private set; }

        public RemoveEventOutput(ICalendarEvent e)
        {
            EventId = ((CalendarEvent)e).Id;
        }
    }
}

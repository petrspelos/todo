using System;

namespace ToDo.Infrastructure.JsonStorage
{
    public sealed class CalendarEvent : ToDo.Domain.Events.CalendarEvent
    {
        public CalendarEvent()
        {
            Id = Guid.NewGuid();
        }
    }
}

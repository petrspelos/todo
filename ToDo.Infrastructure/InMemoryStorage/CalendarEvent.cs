using System;

namespace ToDo.Infrastructure.InMemoryStorage
{
    public class CalendarEvent : ToDo.Domain.Events.CalendarEvent
    {
        public CalendarEvent()
        {
            Id = Guid.NewGuid();
        }
    }
}

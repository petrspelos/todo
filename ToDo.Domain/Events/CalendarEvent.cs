using System;

namespace ToDo.Domain.Events
{
    public class CalendarEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public TimeSpan Duration { get; private set; }
    }
}

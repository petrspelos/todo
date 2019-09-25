using System;

namespace ToDo.Domain.Events
{
    public class CalendarEvent : ICalendarEvent, IUnique
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

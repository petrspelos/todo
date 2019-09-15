using System;

namespace ToDo.Domain.Events
{
    public class CalendarEvent : ICalendarEvent, IUnique
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

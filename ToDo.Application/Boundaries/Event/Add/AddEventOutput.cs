using System;
using ToDo.Domain.Events;

namespace ToDo.Application.Boundaries.Event.Add
{
    public sealed class AddEventOutput
    {
        public Guid EventId { get; private set; }
        public string EventName { get; private set; }
        public string EventDescription { get; private set; }
        public DateTime EventStartDate { get; private set; }
        public TimeSpan EventDuration { get; private set; }

        public AddEventOutput(ICalendarEvent e)
        {
            var cEvent = (CalendarEvent)e;

            EventId = cEvent.Id;
            EventName = cEvent.Name;
            EventDescription = cEvent.Description;
            EventStartDate = cEvent.StartDate;
            EventDuration = cEvent.Duration;
        }
    }
}

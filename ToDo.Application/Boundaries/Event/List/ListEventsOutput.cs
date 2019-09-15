using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ToDo.Domain.Events;

namespace ToDo.Application.Boundaries.Event.List
{
    public sealed class ListEventsOutput
    {
        public IEnumerable<CalendarEvent> Events { get; private set; }

        public ListEventsOutput(IEnumerable<ICalendarEvent> events)
        {
            Events = events.Select(e => (CalendarEvent)e) ?? new Collection<CalendarEvent>();
        }
    }
}

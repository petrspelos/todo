using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDo.WebApi.Models;

namespace ToDo.WebApi.UseCases.ListEvents
{
    public sealed class ListEventsResponse
    {
        public IEnumerable<CalendarEventModel> Events { get; set; }
        
        public ListEventsResponse()
        {
            Events = new Collection<CalendarEventModel>();
        }
    }
}

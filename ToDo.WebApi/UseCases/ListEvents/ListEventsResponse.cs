using System.Collections.Generic;
using ToDo.WebApi.Models;

namespace ToDo.WebApi.UseCases.ListEvents
{
    public sealed class ListEventsResponse
    {
        public IEnumerable<CalendarEventModel> Events { get; set; }
    }
}

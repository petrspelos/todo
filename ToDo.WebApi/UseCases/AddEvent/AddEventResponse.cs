using System;

namespace ToDo.WebApi.UseCases.AddEvent
{
    public sealed class AddEventResponse
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventStartDate { get; set; }
        public TimeSpan EventDuration { get; set; }
    }
}

using System;

namespace ToDo.WebApi.UseCases.AddEvent
{
    public sealed class AddEventResponse
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public DateTime EventStartDate { get; set; }
        public TimeSpan EventDuration { get; set; }
    }
}

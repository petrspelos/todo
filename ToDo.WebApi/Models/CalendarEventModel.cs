using System;

namespace ToDo.WebApi.Models
{
    public class CalendarEventModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

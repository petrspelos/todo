using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.WebApi.UseCases.AddEvent
{
    public sealed class AddEventRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }
    }
}

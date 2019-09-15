using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.WebApi.UseCases.RemoveEvent
{
    public sealed class RemoveEventRequest
    {
        [Required]
        public Guid EventId { get; set; }
    }
}
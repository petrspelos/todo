using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.WebApi.UseCases.RemoveTodo
{
    public sealed class RemoveTodoRequest
    {
        [Required]
        public Guid TaskId { get; set; }
    }
}

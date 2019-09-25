using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.WebApi.Models
{
    public sealed class TodoTaskModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}

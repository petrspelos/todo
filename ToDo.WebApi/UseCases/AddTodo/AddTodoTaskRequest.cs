using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.WebApi.UseCases.AddTodo
{
    public sealed class AddTodoTaskRequest
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1024)]
        public string Description { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }
    }
}

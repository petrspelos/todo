using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.WebApi.UseCases.AddTodo
{
    public sealed class AddTodoTaskRequest
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }
    }
}

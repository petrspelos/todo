using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.WebApi.UseCases.AddTodo
{
    public sealed class AddTodoTaskRequest
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }
    }
}

using System;

namespace ToDo.WebApi.UseCases.AddTodo
{
    public sealed class AddTodoTaskResponse
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? TaskDueDate { get; set; }
        public bool TaskIsCompleted { get; set; }
    }
}

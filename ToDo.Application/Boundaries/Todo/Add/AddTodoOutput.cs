using System;
using ToDo.Domain.Todos;

namespace ToDo.Application.Boundaries.Todo.Add
{
    public sealed class AddTodoOutput
    {
        public Guid TaskId { get; private set; }
        public string TaskName { get; private set; }
        public string TaskDescription { get; private set; }
        public DateTime? TaskDueDate { get; private set; }
        public bool TaskIsCompleted { get; private set; }

        public AddTodoOutput(ITodoTask t)
        {
            var task = (TodoTask)t;
            TaskId = task.Id;
            TaskName = task.Name;
            TaskDescription = task.Description;
            TaskDueDate = task.DueDate;
            TaskIsCompleted = task.IsCompleted;
        }
    }
}

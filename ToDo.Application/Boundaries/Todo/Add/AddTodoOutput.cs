using System;

namespace ToDo.Application.Boundaries.Todo.Add
{
    public sealed class AddTodoOutput
    {
        public Guid TaskId { get; private set; }
        public string TaskName { get; private set; }
        public string TaskDescription { get; private set; }
        public DateTime? TaskDueDate { get; private set; }
        public bool TaskIsCompleted { get; private set; }

        public AddTodoOutput(Guid id, string name, string description, DateTime? dueDate, bool isCompleted)
        {
            TaskId = id;
            TaskName = name;
            TaskDescription = description;
            TaskDueDate = dueDate;
            TaskIsCompleted = isCompleted;
        }
    }
}

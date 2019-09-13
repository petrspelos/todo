using System;

namespace ToDo.Application.Boundaries.Todo.Add
{
    public sealed class AddTodoInput
    {
        public string TaskName { get; private set; }
        public string TaskDescription { get; private set; }
        public DateTime? TaskDueDate { get; private set; }

        public AddTodoInput(string name, string description, DateTime? dueDate)
        {
            TaskName = name;
            TaskDescription = description;
            TaskDueDate = dueDate;
        }
    }
}
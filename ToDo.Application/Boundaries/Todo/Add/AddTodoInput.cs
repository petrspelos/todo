using System;
using ToDo.Domain;

namespace ToDo.Application.Boundaries.Todo.Add
{
    public sealed class AddTodoInput
    {
        private const int MaxTaskNameLength = 40;
        public string TaskName { get; private set; }
        public string TaskDescription { get; private set; }
        public DateTime? TaskDueDate { get; private set; }

        public AddTodoInput(string name, string description, DateTime? dueDate)
        {
            if(string.IsNullOrEmpty(name))
                throw new NameShouldNotBeNullOrEmptyException("The name is required.");

            if(name.Length > MaxTaskNameLength)
                throw new NameIsTooLongException("The name is too long.");

            TaskName = name;
            TaskDescription = description;
            TaskDueDate = dueDate;
        }
    }
}

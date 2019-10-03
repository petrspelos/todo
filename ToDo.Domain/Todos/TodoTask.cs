using System;

namespace ToDo.Domain.Todos
{
    public class TodoTask : IUnique, ITodoTask
    {
        public Guid Id { get; protected set; }
        public bool IsCompleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
    }
}

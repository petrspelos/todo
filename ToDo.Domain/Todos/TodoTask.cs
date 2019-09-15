using System;

namespace ToDo.Domain.Todos
{
    public class TodoTask : IUnique, ITodoTask
    {
        public Guid Id { get; protected set; }
        public bool IsCompleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

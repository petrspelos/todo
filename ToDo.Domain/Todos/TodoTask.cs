using System;

namespace ToDo.Domain.Todos
{
    public class TodoTask : IUnique
    {
        public Guid Id { get; }
        public bool IsCompleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public TodoTask(Guid id)
        {
            Id = id;
        }
    }
}

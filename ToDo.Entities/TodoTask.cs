using System;

namespace ToDo.Entities
{
    public class TodoTask : IUnique
    {
        public Guid Id { get; set; }
        public bool IsCompleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}

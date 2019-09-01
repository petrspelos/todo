using System;

namespace ToDo.Entities
{
    public class TodoTask : IUnique
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}

using System;

namespace ToDo.Entities
{
    public class TodoTask
    {
        public int Position { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}

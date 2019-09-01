using System;
using System.Collections.Generic;

namespace ToDo.Entities
{
    public class TodoList : IUnique
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TodoTask> Tasks { get; set; }
    }
}

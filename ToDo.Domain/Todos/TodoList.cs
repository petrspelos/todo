using System;
using System.Linq;
using System.Collections.Generic;

namespace ToDo.Domain.Todos
{
    public class TodoList : IUnique
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public ICollection<TodoTask> Tasks { get; }

        public TodoList(Guid id, string name, IEnumerable<TodoTask> tasks)
        {
            Id = id;
            Name = name;
            Tasks = tasks.ToList();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using ToDo.Entities;
using ToDo.Storage;

namespace ToDo.Tests.Spies
{
    public class InMemoryTaskStorageSpy : ITaskStorage
    {
        public List<string> Tasks { get; set; }

        public InMemoryTaskStorageSpy()
        {
            Tasks = new List<string>();
        }

        public InMemoryTaskStorageSpy(IEnumerable<string> items)
        {
            Tasks = items.ToList();
        }

        public void Store(TodoTask task) => Tasks.Add(task.Description);

        public TodoTask[] RetrieveAll()
        {
            var descriptions = Tasks.ToArray();
            var todoTasks = new TodoTask[descriptions.Length];

            for (var index = 0; index < descriptions.Length; index++)
            {
                todoTasks[index] = new TodoTask
                {
                    Id = index,
                    Description = descriptions[index]
                };
            }

            return todoTasks;
        }

        public void Remove(int id)
        {
            if (id < 0 || id >= Tasks.Count) { return; }
            
            Tasks.RemoveAt(id);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Task Store(TodoTask task)
        {
            Tasks.Add(task.Description);
            return Task.CompletedTask;
        }

        public Task<TodoTask[]> RetrieveAll()
        {
            var descriptions = Tasks.ToArray();
            var todoTasks = new TodoTask[descriptions.Length];

            for (var index = 0; index < descriptions.Length; index++)
            {
                todoTasks[index] = new TodoTask
                {
                    Position = index,
                    Description = descriptions[index]
                };
            }

            return Task.FromResult(todoTasks);
        }

        public Task Remove(int id)
        {
            if (id < 0 || id >= Tasks.Count) { return Task.CompletedTask; }
            
            Tasks.RemoveAt(id);
            return Task.CompletedTask;
        }
    }
}
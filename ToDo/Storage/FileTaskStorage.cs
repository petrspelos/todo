using System;
using System.Threading.Tasks;
using ToDo.Entities;
using ToDo.Infrastructure;

namespace ToDo.Storage
{
    public class FileTaskStorage : ITaskStorage
    {
        private readonly IFileSystem _fileSystem;
        private readonly string _fileName;

        public FileTaskStorage(IFileSystem fileSystem)
        {
            _fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/todo.txt";
            _fileSystem = fileSystem;
        }

        public Task Remove(int id)
        {
            _fileSystem.RemoveLine(id, _fileName);
            return Task.CompletedTask;
        }

        public Task<TodoTask[]> RetrieveAll()
        {
            var descriptions = _fileSystem.ReadAllLines(_fileName);
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

        public Task Store(TodoTask task)
        {
            _fileSystem.AppendLine(task.Description, _fileName);
            return Task.CompletedTask;
        }
    }
}

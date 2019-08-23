using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ToDo.Infrastructure;

namespace ToDo
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

        public void Remove(int id)
            => _fileSystem.RemoveLine(id, _fileName);

        public TodoTask[] RetrieveAll()
        {
            var descriptions = _fileSystem.ReadAllLines(_fileName);
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

        public void Store(TodoTask task)
            => _fileSystem.AppendLine(task.Description, _fileName);
    }
}

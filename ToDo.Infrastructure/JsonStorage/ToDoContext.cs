using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using ToDo.Domain.Todos;
using ToDo.Infrastructure.JsonStorage.FileSystem;

namespace ToDo.Infrastructure.JsonStorage
{
    public sealed class ToDoContext
    {
        private const string TasksFilePath = "json/tasks.json";
        private readonly IFileSystem _fileSystem;
        public ICollection<TodoTask> TodoTasks { get; set; }

        public ToDoContext(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            TodoTasks = new Collection<TodoTask>();
            DeserializeFromFile();
        }

        public async void Serialize()
        {
            var json = JsonConvert.SerializeObject(TodoTasks);
            await _fileSystem.WriteFileContents(TasksFilePath, json);
        }

        private async void DeserializeFromFile()
        {
            if(!await _fileSystem.FileExists(TasksFilePath))
            {
                Serialize();
            }
            else
            {
                var json = await _fileSystem.GetFileContents(TasksFilePath);
                TodoTasks = JsonConvert.DeserializeObject<Collection<TodoTask>>(json);
            }
        }
    }
}

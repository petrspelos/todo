using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDo.Domain.Todos;
using ToDo.Infrastructure.JsonStorage.FileSystem;

namespace ToDo.Infrastructure.JsonStorage
{
    public sealed class ToDoContext
    {
        private const string TasksFilePath = "json/tasks.json";
        private const string EventsFilePath = "json/events.json";
        private readonly IFileSystem _fileSystem;
        public ICollection<TodoTask> TodoTasks { get; set; }
        public ICollection<CalendarEvent> CalendarEvents { get; set; }

        public ToDoContext(IFileSystem fileSystem)
        {
            TodoTasks = new Collection<TodoTask>();
            CalendarEvents = new Collection<CalendarEvent>();
            _fileSystem = fileSystem;
            DeserializeFromFile();
        }

        public async void Serialize()
        {
            await Serialize(TodoTasks, TasksFilePath);
            await Serialize(CalendarEvents, EventsFilePath);
        }

        private async Task Serialize<T>(ICollection<T> collection, string file)
        {
            var json = JsonConvert.SerializeObject(collection);
            await _fileSystem.WriteFileContents(file, json);
        }

        private async void DeserializeFromFile()
        {
            TodoTasks = await DeserializeFromFile<TodoTask>(TasksFilePath);
            CalendarEvents = await DeserializeFromFile<CalendarEvent>(EventsFilePath);
        }

        private async Task<ICollection<T>> DeserializeFromFile<T>(string filePath)
        {
            if(!await _fileSystem.FileExists(filePath))
                return new Collection<T>();

            var json = await _fileSystem.GetFileContents(filePath);
            return JsonConvert.DeserializeObject<Collection<T>>(json);
        }
    }
}

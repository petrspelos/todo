using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ToDo.Infrastructure.InMemoryStorage
{
    public sealed class ToDoContext
    {
        public ICollection<TodoTask> TodoTasks { get; set; }
        public ICollection<CalendarEvent> CalendarEvents { get; set; }

        public ToDoContext()
        {
            TodoTasks = new Collection<TodoTask>();
            CalendarEvents = new Collection<CalendarEvent>();
        }
    }
}

using System;
using ToDo.Domain;
using ToDo.Domain.Events;
using ToDo.Domain.Todos;

namespace ToDo.Infrastructure.JsonStorage
{
    public sealed class EntityFactory : IEntityFactory
    {
        public ICalendarEvent NewCalendarEvent(string name, string description, DateTime startDate, TimeSpan duration)
        {
            return new JsonStorage.CalendarEvent
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                Duration = duration
            };
        }

        public ITodoTask NewTodoTask(string name, string description, DateTime? dueDate)
        {
            return new JsonStorage.TodoTask
            {
                Name = name,
                Description = description,
                DueDate = dueDate
            };
        }
    }
}

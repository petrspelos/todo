using System;
using ToDo.Domain.Events;
using ToDo.Domain.Todos;

namespace ToDo.Domain
{
    public interface IEntityFactory
    {
        ITodoTask NewTodoTask(string name, string description, DateTime? dueDate);
        ICalendarEvent NewCalendarEvent(string name, string description, DateTime startDate, TimeSpan duration);
    }
}

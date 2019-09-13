using System;
using ToDo.Domain.Todos;

namespace ToDo.Domain
{
    public interface IEntityFactory
    {
        ITodoTask NewTodoTask(string name, string description, DateTime? dueDate);
    }
}

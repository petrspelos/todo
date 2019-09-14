using System;
using ToDo.Domain;
using ToDo.Domain.Todos;

namespace ToDo.Infrastructure.JsonStorage
{
    public sealed class EntityFactory : IEntityFactory
    {
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

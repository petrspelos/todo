using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Domain.Todos;

namespace ToDo.Infrastructure.JsonStorage.Repositories
{
    public sealed class TodoRepository : ITodoRepository
    {
        private readonly ToDoContext _context;

        public TodoRepository(ToDoContext context)
        {
            _context = context;
        }

        public Task Add(ITodoTask task)
        {
            _context.TodoTasks.Add((TodoTask)task);
            _context.Serialize();
            return Task.CompletedTask;
        }

        public Task<bool> Exists(Guid id)
            => Task.FromResult(_context.TodoTasks.Any(t => t.Id == id));

        public Task<IEnumerable<ITodoTask>> GetAll()
        {
            return Task.FromResult(_context.TodoTasks.Select(t => (ITodoTask)t));
        }

        public Task<ITodoTask> Remove(Guid id)
        {
            var toRemove = _context.TodoTasks.SingleOrDefault(t => t.Id == id);

            if(toRemove is null)
                return null;

            _context.TodoTasks.Remove(toRemove);
            _context.Serialize();

            return Task.FromResult((ITodoTask)toRemove);
        }
    }
}

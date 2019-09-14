using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Domain.Todos;

namespace ToDo.Infrastructure.InMemoryStorage.Repositories
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
            return Task.CompletedTask;
        }
    }
}

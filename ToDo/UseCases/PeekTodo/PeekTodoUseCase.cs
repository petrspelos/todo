using ToDo.Entities;
using ToDo.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.UseCases.PeekTodo
{
    public class PeekTodoUseCase : IPeekTodoUseCase
    {
        private readonly ITaskStorage _storage;

        public PeekTodoUseCase(ITaskStorage storage)
        {
            _storage = storage;
        }

        public async Task<TodoTask> Execute()
        {
            var tasks = await _storage.RetrieveAll();

            return tasks.Any() ? tasks.Last() : null;
        }
    }
}

using ToDo.Entities;
using ToDo.Storage;
using System.Linq;

namespace ToDo.UseCases.PeekTodo
{
    public class PeekTodoUseCase : IPeekTodoUseCase
    {
        private readonly ITaskStorage _storage;

        public PeekTodoUseCase(ITaskStorage storage)
        {
            _storage = storage;
        }

        public TodoTask Execute()
        {
            var tasks = _storage.RetrieveAll();

            return tasks.Any() ? tasks.Last() : null;
        }
    }
}

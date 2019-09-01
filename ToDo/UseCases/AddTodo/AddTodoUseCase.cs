using System.Threading.Tasks;
using ToDo.Entities;
using ToDo.Storage;

namespace ToDo.UseCases.AddTodo
{
    public class AddTodoUseCase : IAddTodoUseCase
    {
        private readonly ITaskStorage _storage;

        public AddTodoUseCase(ITaskStorage storage)
        {
            _storage = storage;
        }

        public async Task Execute(string description)
        {
            if (description is null) { return; }
            await _storage.Store(new TodoTask { Description = description });
        }
    }
}

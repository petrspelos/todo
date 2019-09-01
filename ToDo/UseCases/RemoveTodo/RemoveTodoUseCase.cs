using System.Threading.Tasks;
using ToDo.Storage;

namespace ToDo.UseCases.RemoveTodo
{
    public class RemoveTodoUseCase : IRemoveTodoUseCase
    {
        private readonly ITaskStorage _storage;

        public RemoveTodoUseCase(ITaskStorage storage)
        {
            _storage = storage;
        }

        public Task ExecuteById(int id)
        {
            _storage.Remove(id);
            return Task.CompletedTask;
        }
    }
}
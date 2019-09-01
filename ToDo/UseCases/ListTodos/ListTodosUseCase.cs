using System.Threading.Tasks;
using ToDo.Entities;
using ToDo.Storage;

namespace ToDo.UseCases.ListTodos
{
    public class ListTodosUseCase : IListTodosUseCase
    {
        private readonly ITaskStorage _storage;

        public ListTodosUseCase(ITaskStorage storage)
        {
            _storage = storage; 
        }

        public Task<TodoTask[]> Execute() => _storage.RetrieveAll();
    }
}

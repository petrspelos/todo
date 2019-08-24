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

        public TodoTask[] Execute() => _storage.RetrieveAll();
    }
}

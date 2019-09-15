using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Boundaries.Todo.List;
using ToDo.Application.Repositories;
using ToDo.Domain.Todos;

namespace ToDo.Application.UseCases.Todo
{
    public class ListTodosUseCase : IListTodosUseCase
    {
        private ITodoRepository _repository;
        private IListTodosOutputPort _output;

        public ListTodosUseCase(ITodoRepository repository, IListTodosOutputPort output)
        {
            _repository = repository;
            _output = output;
        }

        public async Task Execute()
        {
            var tasks = await _repository.GetAll();

            _output.Default(new ListTodosOutput(tasks.Select(t => (TodoTask)t)));
        }
    }
}

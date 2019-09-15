using System;
using System.Threading.Tasks;
using ToDo.Application.Boundaries.Todo.Add;
using ToDo.Application.Repositories;
using ToDo.Domain;

namespace ToDo.Application.UseCases.Todo
{
    public sealed class AddTodoUseCase : IAddTodoUseCase
    {
        private readonly IAddTodoOutputPort _output;
        private readonly ITodoRepository _repository;
        private readonly IEntityFactory _entityFactory;

        public AddTodoUseCase(IAddTodoOutputPort output, ITodoRepository repository, IEntityFactory entityFactory)
        {
            _output = output;
            _repository = repository;
            _entityFactory = entityFactory;
        }

        public async Task Execute(AddTodoInput input)
        {
            if(input is null)
                throw new Exception();

            var task = _entityFactory.NewTodoTask(input.TaskName, input.TaskDescription, input.TaskDueDate);

            await _repository.Add(task);

            _output.Default(new AddTodoOutput(task));
        }
    }
}

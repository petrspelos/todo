using System;
using System.Threading.Tasks;
using ToDo.Application.Boundaries.Todo.Add;
using ToDo.Application.Repositories;
using ToDo.Domain;
using ToDo.Domain.Todos;

namespace ToDo.Application.UseCases.Todo
{
    public sealed class AddTodoUseCase : IAddTodoUseCase
    {
        private const int MaxTaskNameLength = 40;
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
            if(input?.TaskName is null)
                throw new Exception();

            if(input.TaskName.Length > MaxTaskNameLength)
            {
                _output.Error("The name is too long.");
                return;
            }

            var task = _entityFactory.NewTodoTask(input.TaskName, input.TaskDescription, input.TaskDueDate);

            await _repository.Add(task);

            _output.Default(new AddTodoOutput(task));
        }
    }
}

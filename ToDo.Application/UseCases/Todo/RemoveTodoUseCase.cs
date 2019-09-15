using System;
using System.Threading.Tasks;
using ToDo.Application.Boundaries.Todo.Remove;
using ToDo.Application.Repositories;

namespace ToDo.Application.UseCases.Todo
{
    public sealed class RemoveTodoUseCase : IRemoveTodoUseCase
    {
        private readonly IRemoveTodoOutputPort _output;
        private readonly ITodoRepository _repository;

        public RemoveTodoUseCase(IRemoveTodoOutputPort output, ITodoRepository repository)
        {
            _output = output;
            _repository = repository;
        }

        public async Task Execute(RemoveTodoInput input)
        {
            if(input is null)
                throw new Exception();

            if(!await _repository.Exists(input.Id))
            {
                _output.Error("There is no task with this ID.");
                return;
            }

            var deletedTask = await _repository.Remove(input.Id);

            _output.Default(new RemoveTodoOutput(deletedTask));
        }
    }
}

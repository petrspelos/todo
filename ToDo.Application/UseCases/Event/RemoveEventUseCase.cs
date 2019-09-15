using System;
using System.Threading.Tasks;
using ToDo.Application.Boundaries.Event.Remove;
using ToDo.Application.Repositories;

namespace ToDo.Application.UseCases.Event
{
    public class RemoveEventUseCase : IRemoveEventUseCase
    {
        private readonly IRemoveEventOutputPort _output;
        private readonly IEventRepository _repository;

        public RemoveEventUseCase(IRemoveEventOutputPort output, IEventRepository repository)
        {
            _output = output;
            _repository = repository;
        }

        public async Task Execute(RemoveEventInput input)
        {
            if(input is null)
                throw new Exception();

            if(!await _repository.Exists(input.Id))
            {
                _output.Error("There is no event with this ID.");
                return;
            }

            var deletedEvent = await _repository.Remove(input.Id);

            _output.Default(new RemoveEventOutput(deletedEvent));
        }
    }
}
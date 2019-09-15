using System;
using System.Threading.Tasks;
using ToDo.Application.Boundaries.Event.Add;
using ToDo.Application.Repositories;
using ToDo.Domain;

namespace ToDo.Application.UseCases.Event
{
    public class AddEventUseCase : IAddEventUseCase
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IEventRepository _repository;
        private readonly IAddEventOutputPort _output;

        public AddEventUseCase(IEntityFactory entityFactory, IEventRepository repository, IAddEventOutputPort output)
        {
            _entityFactory = entityFactory;
            _repository = repository;
            _output = output;
        }

        public async Task Execute(AddEventInput input)
        {
            if(input is null)
                throw new Exception();

            var newEvent = _entityFactory.NewCalendarEvent(input.Name, input.Description, input.StartDate, input.Duration);
            await _repository.Add(newEvent);

            _output.Default(new AddEventOutput(newEvent));
        }
    }
}

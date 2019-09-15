using System.Threading.Tasks;
using ToDo.Application.Boundaries.Event.List;
using ToDo.Application.Repositories;

namespace ToDo.Application.UseCases.Event
{
    public class ListEventsUseCase : IListEventsUseCase
    {
        private readonly IEventRepository _repository;
        private readonly IListEventsOutputPort _output;

        public ListEventsUseCase(IEventRepository repository, IListEventsOutputPort output)
        {
            _repository = repository;
            _output = output;
        }

        public async Task Execute()
        {
            var allEvents = await _repository.GetAll();
            _output.Default(new ListEventsOutput(allEvents));
        }
    }
}

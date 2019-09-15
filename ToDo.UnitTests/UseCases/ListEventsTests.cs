using System;
using System.Threading.Tasks;
using Moq;
using ToDo.Application.Boundaries.Event.List;
using ToDo.Application.Repositories;
using ToDo.Application.UseCases.Event;
using ToDo.Domain;
using ToDo.Infrastructure.InMemoryStorage;
using ToDo.Infrastructure.InMemoryStorage.Repositories;
using Xunit;

namespace ToDo.UnitTests.UseCases
{
    public class ListEventsTests
    {
        private readonly IEntityFactory _entityFactory;
        private readonly ToDoContext _context;
        private readonly IEventRepository _repository;
        private readonly IListEventsUseCase _useCase;
        private Mock<IListEventsOutputPort> _outputMock;
        private ListEventsOutput _output;

        public ListEventsTests()
        {
            _outputMock = new Mock<IListEventsOutputPort>();
            Action<ListEventsOutput> onReceivedOutput = o => { _output = o; };
            _outputMock.Setup(o => o.Default(It.IsAny<ListEventsOutput>())).Callback(onReceivedOutput);
            _context = new ToDoContext();
            _repository = new EventRepository(_context);
            _useCase = new ListEventsUseCase(_repository, _outputMock.Object);
            _entityFactory = new EntityFactory();
        }

        [Fact]
        public async Task NoEvents_ShouldReturnEmptyList()
        {
            await _useCase.Execute();

            Assert.Empty(_context.CalendarEvents);
            Assert.NotNull(_output);
            Assert.Empty(_output.Events);
        }
    }
}

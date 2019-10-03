using System;
using System.Linq;
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
        private ListEventsOutput? _output;

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
            Assert.Empty(_output!.Events);
        }

        [Fact]
        public async Task EventList_ShouldBeReturned()
        {
            var first = await SetupNewEventAsync("First", "Description", new DateTime(2019, 9, 16, 9, 0, 0), TimeSpan.FromHours(1));
            var second = await SetupNewEventAsync("Second", "Description", new DateTime(2019, 9, 20), TimeSpan.FromDays(1));

            await _useCase.Execute();

            Assert.NotNull(_output);
            Assert.Equal(2, _context.CalendarEvents.Count);
            
            Assert.Equal(_context.CalendarEvents.First().Id, _output!.Events.First().Id);
            Assert.Equal(_context.CalendarEvents.First().Name, _output.Events.First().Name);
            Assert.Equal(_context.CalendarEvents.First().Description, _output.Events.First().Description);
            Assert.Equal(_context.CalendarEvents.First().StartDate, _output.Events.First().StartDate);
            Assert.Equal(_context.CalendarEvents.First().Duration, _output.Events.First().Duration);

            Assert.Equal(_context.CalendarEvents.Last().Id, _output.Events.Last().Id);
            Assert.Equal(_context.CalendarEvents.Last().Name, _output.Events.Last().Name);
            Assert.Equal(_context.CalendarEvents.Last().Description, _output.Events.Last().Description);
            Assert.Equal(_context.CalendarEvents.Last().StartDate, _output.Events.Last().StartDate);
            Assert.Equal(_context.CalendarEvents.Last().Duration, _output.Events.Last().Duration);
        }

        private async Task<CalendarEvent> SetupNewEventAsync(string name, string description, DateTime startDate, TimeSpan duration)
        {
            var expected = _entityFactory.NewCalendarEvent(name, description, startDate, duration);
            await _repository.Add(expected);
            return (CalendarEvent)expected;
        }
    }
}

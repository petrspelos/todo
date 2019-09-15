using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ToDo.Application.Boundaries.Event.Remove;
using ToDo.Application.Repositories;
using ToDo.Application.UseCases.Event;
using ToDo.Domain;
using ToDo.Infrastructure.InMemoryStorage;
using ToDo.Infrastructure.InMemoryStorage.Repositories;
using Xunit;

namespace ToDo.UnitTests.UseCases
{
    public class RemoveEventTests
    {
        private readonly IEntityFactory _entityFactory;
        private readonly ToDoContext _context;
        private readonly IEventRepository _repository;
        private readonly Mock<IRemoveEventOutputPort> _outputMock;
        private RemoveEventOutput _output;
        private readonly IRemoveEventUseCase _useCase;

        public RemoveEventTests()
        {
            _outputMock = new Mock<IRemoveEventOutputPort>();
            Action<RemoveEventOutput> onReceivedOutput = o => { _output = o; };
            _outputMock.Setup(o => o.Default(It.IsAny<RemoveEventOutput>())).Callback(onReceivedOutput);

            _entityFactory = new EntityFactory();
            _context = new ToDoContext();
            _repository = new EventRepository(_context);

            _useCase = new RemoveEventUseCase(_outputMock.Object, _repository);
        }

        [Fact]
        public async Task NullInput_ShouldThrow()
        {
            await Assert.ThrowsAsync<Exception>(async () => {
                await _useCase.Execute(null);
            });
        }

        [Fact]
        public async Task UnknownGuid_ShouldOutputError()
        {
            await _useCase.Execute(new RemoveEventInput(Guid.NewGuid()));

            _outputMock.Verify(o => o.Error(It.Is<string>(s => s == "There is no event with this ID.")));
        }

        [Fact]
        public async Task ValidGuid_ShouldRemoveEvent()
        {
            var other = await SetupNewEventAsync("Other event", null, new DateTime(2022, 2, 2), TimeSpan.FromMinutes(45));
            var target = await SetupNewEventAsync("EventName", "Description", new DateTime(2020, 1, 1), TimeSpan.FromMinutes(30));

            await _useCase.Execute(new RemoveEventInput(target.Id));

            Assert.Single(_context.CalendarEvents);
            Assert.Equal(_context.CalendarEvents.First().Id, other.Id);
        }

        private async Task<CalendarEvent> SetupNewEventAsync(string name, string description, DateTime startDate, TimeSpan duration)
        {
            var expected = _entityFactory.NewCalendarEvent(name, description, startDate, duration);
            await _repository.Add(expected);
            return (CalendarEvent)expected;
        }
    }
}
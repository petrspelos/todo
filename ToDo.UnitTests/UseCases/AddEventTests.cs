using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ToDo.Application.Boundaries.Event.Add;
using ToDo.Application.UseCases.Event;
using ToDo.Domain;
using ToDo.Domain.Events;
using ToDo.Infrastructure.InMemoryStorage;
using ToDo.Infrastructure.InMemoryStorage.Repositories;
using Xunit;

namespace ToDo.UnitTests.UseCases
{
    public class AddEventTests
    {
        private readonly IAddEventUseCase _useCase;
        private readonly ToDoContext _context;
        private readonly Mock<IAddEventOutputPort> _outputMock;
        private AddEventOutput? _output;

        public AddEventTests()
        {
            _outputMock = new Mock<IAddEventOutputPort>();
            Action<AddEventOutput> onReceivedOutput = o => { _output = o; };
            _outputMock.Setup(o => o.Default(It.IsAny<AddEventOutput>())).Callback(onReceivedOutput);
            var factory = new EntityFactory();
            _context = new ToDoContext();
            var repository = new EventRepository(_context);
            _useCase = new AddEventUseCase(factory, repository, _outputMock.Object);
        }

        [Fact]
        public async Task NullValues_ShouldThrow()
        {
            await Assert.ThrowsAsync<Exception>(async () => {
                await _useCase.Execute(null!);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyName_ShouldThrow(string name)
        {
            Assert.Throws<NameShouldNotBeNullOrEmptyException>(() => {
                new AddEventInput(name, "Description", new DateTime(2020, 1, 1), TimeSpan.FromDays(2));
            });
        }

        [Fact]
        public void NegativeDuration_ShouldThrow()
        {
            Assert.Throws<DurationCannotBeNegativeException>(() => {
                new AddEventInput("Name", "Description", new DateTime(2020, 1, 1), TimeSpan.FromDays(-2));
            });
        }

        [Fact]
        public async Task ValidEvent_ShouldBeAdded()
        {
            var input = new AddEventInput("Name", "Description", new DateTime(2020, 1, 1), TimeSpan.FromMinutes(20));

            await _useCase.Execute(input);

            Assert.NotNull(_output);
            Assert.NotEqual(Guid.Empty, _output!.EventId);
            Assert.Equal("Name", _output.EventName);
            Assert.Equal("Description", _output.EventDescription);
            Assert.Equal(new DateTime(2020, 1, 1), _output.EventStartDate);
            Assert.Equal(TimeSpan.FromMinutes(20), _output.EventDuration);

            Assert.Single(_context.CalendarEvents);
            Assert.Equal(_context.CalendarEvents.First().Id, _output.EventId);
            Assert.Equal(_context.CalendarEvents.First().Name, _output.EventName);
            Assert.Equal(_context.CalendarEvents.First().Description, _output.EventDescription);
            Assert.Equal(_context.CalendarEvents.First().StartDate, _output.EventStartDate);
            Assert.Equal(_context.CalendarEvents.First().Duration, _output.EventDuration);
        }
    }
}

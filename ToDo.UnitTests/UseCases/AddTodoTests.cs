using ToDo.Application.UseCases.Todo;
using ToDo.Application.Boundaries.Todo.Add;
using System;
using Xunit;
using Moq;
using ToDo.Infrastructure.InMemoryStorage;
using ToDo.Application.Repositories;
using ToDo.Infrastructure.InMemoryStorage.Repositories;
using System.Linq;
using ToDo.Domain;
using System.Threading.Tasks;
using ToDo.Domain.Todos;

namespace ToDo.UnitTests.UseCases
{
    public class AddTodoTests
    {
        private readonly Mock<IAddTodoOutputPort> _outputMock;
        private readonly IAddTodoUseCase _useCase;
        private readonly ToDoContext _context;

        public AddTodoTests()
        {
            _context = new ToDoContext();
            ITodoRepository todoRepo = new TodoRepository(_context);
            IEntityFactory factory =  new EntityFactory();
            _outputMock = new Mock<IAddTodoOutputPort>();
            _useCase = new AddTodoUseCase(_outputMock.Object, todoRepo, factory);
        }

        [Fact]
        public async Task NullInput_ShouldThrow()
        {
            await Assert.ThrowsAsync<Exception>(async () => {
                await _useCase.Execute(null!);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MissingOrEmptyRequiredName_ShouldThrow(string name)
        {
            var exception = Assert.Throws<NameShouldNotBeNullOrEmptyException>(() => {
                new AddTodoInput(name, string.Empty, DateTime.Now);
            });

            Assert.Equal("The name is required.", exception.Message);
        }

        [Fact]
        public void NameTooLong_ReturnsError()
        {
            var exception = Assert.Throws<NameIsTooLongException>(() => {
                new AddTodoInput("This name is too long, because it is longer than 40 characters.", string.Empty, DateTime.Now);
            });

            Assert.Equal("The name is too long.", exception.Message);
        }

        [Theory]
        [InlineData("Name", "Description", "September 20, 2019")]
        [InlineData("Name", null, "September 20, 2019")]
        [InlineData("Name", "Description", null)]
        [InlineData("Name", null, null)]
        public async Task ValidData_ShouldReturnTask(string name, string description, string dueDateSource)
        {
            DateTime? dueDate = null;
            if(dueDateSource != null) { dueDate = DateTime.Parse(dueDateSource); }

            var input = new AddTodoInput(name, description, dueDate);

            AddTodoOutput? output = null;
            Action<AddTodoOutput> onReceivedOutput = o => {
                output = o;
            };

            _outputMock.Setup(o => o.Default(It.IsAny<AddTodoOutput>())).Callback(onReceivedOutput);

            await _useCase.Execute(input);

            Assert.NotNull(output);
            Assert.NotEqual(Guid.Empty, output!.TaskId);
            Assert.Equal(name, output.TaskName);
            Assert.Equal(description, output.TaskDescription);
            Assert.Equal(dueDate, output.TaskDueDate);

            Assert.Single(_context.TodoTasks);
            Assert.Equal(_context.TodoTasks.First().Id, output.TaskId);
            Assert.Equal(_context.TodoTasks.First().Name, output.TaskName);
            Assert.Equal(_context.TodoTasks.First().Description, output.TaskDescription);
            Assert.Equal(_context.TodoTasks.First().DueDate, output.TaskDueDate);
        }
    }
}

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
                await _useCase.Execute(null);
            });
        }

        [Fact]
        public async Task MissingRequiredName_ShouldThrow()
        {
            var input = new AddTodoInput(null, string.Empty, DateTime.Now);
            await Assert.ThrowsAsync<Exception>(async () => {
                await _useCase.Execute(input);
            });
        }

        [Fact]
        public async Task NameTooLong_ReturnsError()
        {
            var input = new AddTodoInput("This name is too long, because it is longer than 40 characters.", string.Empty, DateTime.Now);

            await _useCase.Execute(input);

            _outputMock.Verify(p => p.Error(It.Is<string>(s => s == "The name is too long.")));
        }

        [Theory]
        [InlineData("Name", "Description", "09/20/2019")]
        [InlineData("Name", null, "09/20/2019")]
        [InlineData("Name", "Description", null)]
        [InlineData("Name", null, null)]
        public async Task ValidData_ShouldReturnTask(string name, string description, string dueDateSource)
        {
            DateTime? dueDate = null;
            if(dueDateSource != null) { dueDate = DateTime.Parse(dueDateSource); }

            var input = new AddTodoInput(name, description, dueDate);

            AddTodoOutput output = null;
            Action<AddTodoOutput> onReceivedOutput = o => {
                output = o;
            };

            _outputMock.Setup(o => o.Default(It.IsAny<AddTodoOutput>())).Callback(onReceivedOutput);

            await _useCase.Execute(input);

            Assert.NotNull(output);
            Assert.Equal(name, output.TaskName);
            Assert.Equal(description, output.TaskDescription);
            Assert.Equal(dueDate, output.TaskDueDate);

            Assert.Single(_context.TodoLists);
            Assert.Single(_context.TodoLists.First().Tasks);
            Assert.Equal(_context.TodoLists.First().Tasks.First().Id, output.TaskId);
            Assert.Equal(_context.TodoLists.First().Tasks.First().Name, output.TaskName);
            Assert.Equal(_context.TodoLists.First().Tasks.First().Description, output.TaskDescription);
            Assert.Equal(_context.TodoLists.First().Tasks.First().DueDate, output.TaskDueDate);
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ToDo.Application.Boundaries.Todo.Remove;
using ToDo.Application.Repositories;
using ToDo.Application.UseCases.Todo;
using ToDo.Domain;
using ToDo.Infrastructure.InMemoryStorage;
using ToDo.Infrastructure.InMemoryStorage.Repositories;
using Xunit;

namespace ToDo.UnitTests
{
    public class RemoveTodoTests
    {
        private readonly IEntityFactory _entityFactory;
        private readonly ToDoContext _context;
        private readonly ITodoRepository _repository;
        private readonly Mock<IRemoveTodoOutputPort> _outputMock;
        private readonly IRemoveTodoUseCase _useCase;
        private RemoveTodoOutput? _output;

        public RemoveTodoTests()
        {
            _outputMock = new Mock<IRemoveTodoOutputPort>();
            Action<RemoveTodoOutput> onReceivedOutput = o => { _output = o; };
            _outputMock.Setup(o => o.Default(It.IsAny<RemoveTodoOutput>())).Callback(onReceivedOutput);
            _entityFactory = new EntityFactory();
            _context = new ToDoContext();
            _repository = new TodoRepository(_context);
            _useCase = new RemoveTodoUseCase(_outputMock.Object, _repository);
        }

        [Fact]
        public async Task NullInput_ShouldThrow()
        {
            await Assert.ThrowsAsync<Exception>(async () => {
                await _useCase.Execute(null!);
            });
        }

        [Fact]
        public async Task NonExistentId_ShouldOutputError()
        {
            var input = new RemoveTodoInput(Guid.Parse("79c2de5f-da7b-4576-9f2a-b92e675dad3c"));

            await _useCase.Execute(input);

            _outputMock.Verify(o => o.Error(It.Is<string>(s => s == "There is no task with this ID.")));
            _outputMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ValidId_ShouldRemoveTask()
        {
            var firstTask = await SetupNewTaskAsync("First Task", "Description", new DateTime(2019, 8, 20));
            var secondTask = await SetupNewTaskAsync("Second Task", null!, new DateTime(2020, 1, 1));
            var input = new RemoveTodoInput(firstTask.Id);

            await _useCase.Execute(input);

            Assert.NotNull(_output);
            Assert.Equal(firstTask.Id, _output!.Id);
            Assert.Single(_context.TodoTasks);
            Assert.Equal(secondTask.Id, _context.TodoTasks.First().Id);
        }

        private async Task<TodoTask> SetupNewTaskAsync(string name, string description, DateTime? dueDate)
        {
            var expected = _entityFactory.NewTodoTask(name, description, dueDate);
            await _repository.Add(expected);
            return (TodoTask)expected;
        }
    }
}

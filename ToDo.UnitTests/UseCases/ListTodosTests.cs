using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ToDo.Application.Boundaries.Todo.List;
using ToDo.Application.Repositories;
using ToDo.Application.UseCases.Todo;
using ToDo.Domain;
using ToDo.Infrastructure.InMemoryStorage;
using ToDo.Infrastructure.InMemoryStorage.Repositories;
using Xunit;

namespace ToDo.UnitTests.UseCases
{
    public class ListTodosTests
    {
        private IEntityFactory _entityFactory;
        private ToDoContext _context;
        private ITodoRepository _repository;
        private IListTodosUseCase _useCase;
        private Mock<IListTodosOutputPort> _outputMock;
        private ListTodosOutput _output;

        public ListTodosTests()
        {
            _outputMock = new Mock<IListTodosOutputPort>();
            Action<ListTodosOutput> onReceivedOutput = o => { _output = o; };
            _outputMock.Setup(o => o.Default(It.IsAny<ListTodosOutput>())).Callback(onReceivedOutput);
            _context = new ToDoContext();
            _repository = new TodoRepository(_context);
            _useCase = new ListTodosUseCase(_repository, _outputMock.Object);
            _entityFactory = new EntityFactory();
        }

        [Fact]
        public async Task NoTodos_ShouldReturnEmptyList()
        {
            await _useCase.Execute();

            Assert.NotNull(_output);
            Assert.Empty(_output.Tasks);
        }

        [Fact]
        public async Task SingleTodo_ShouldReturnListOfOne()
        {
            var expected = await SetupNewTaskAsync("Name", "Description", null);

            await _useCase.Execute();

            Assert.NotNull(_output);
            Assert.Single(_output.Tasks);
            Assert.Equal(expected.Id, _output.Tasks.First().Id);
            Assert.Equal(expected.Name, _output.Tasks.First().Name);
            Assert.Equal(expected.Description, _output.Tasks.First().Description);
        }

        [Fact]
        public async Task MultipleTodos_ShouldReturnCorrectList()
        {
            var expected = new List<TodoTask>();
            expected.Add(await SetupNewTaskAsync("FirstTask", null, null));
            expected.Add(await SetupNewTaskAsync("SecondTask", null, null));

            await _useCase.Execute();

            Assert.NotNull(_output);
            Assert.Equal(2, _output.Tasks.Count());
            Assert.Equal("FirstTask", _output.Tasks.ElementAt(0).Name);
            Assert.Equal(expected.First().Id, _output.Tasks.First().Id);
            Assert.Equal("SecondTask", _output.Tasks.ElementAt(1).Name);
            Assert.Equal(expected.Last().Id, _output.Tasks.Last().Id);
        }

        private async Task<TodoTask> SetupNewTaskAsync(string name, string description, DateTime? dueDate)
        {
            var expected = _entityFactory.NewTodoTask(name, description, dueDate);
            await _repository.Add(expected);
            return (TodoTask)expected;
        }
    }
}
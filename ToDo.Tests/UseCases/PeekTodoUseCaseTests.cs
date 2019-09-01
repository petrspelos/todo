using System.Linq;
using System.Threading.Tasks;
using ToDo.Storage;
using ToDo.UseCases.PeekTodo;
using Xunit;
using Moq;
using ToDo.Entities;

namespace ToDo.Tests.UseCases
{
    public class PeekTodoUseCaseTests
    {
        private readonly Mock<ITaskStorage> _storageMock;

        public PeekTodoUseCaseTests()
        {
            _storageMock = new Mock<ITaskStorage>();
        }

        [Fact]
        public async Task NoTasks_ReturnsNull()
        {
            var tasks = new TodoTask[0];
            _storageMock.Setup(s => s.RetrieveAll()).Returns(() => Task.FromResult(tasks));
            IPeekTodoUseCase useCase = new PeekTodoUseCase(_storageMock.Object);

            var task = await useCase.Execute();

            Assert.Null(task);
        }

        [Fact]
        public async Task OneTask_ReturnsTheTask()
        {
            var tasks = CreateTasks("The Task");

            _storageMock.Setup(s => s.RetrieveAll()).Returns(() => Task.FromResult(tasks));
            IPeekTodoUseCase useCase = new PeekTodoUseCase(_storageMock.Object);

            var task = await useCase.Execute();

            Assert.Same(tasks[0], task);
        }

        [Fact]
        public async Task TaskList_ReturnsLast()
        {
            var tasks = CreateTasks("First Task", "Second Task", "Last Task");

            _storageMock.Setup(s => s.RetrieveAll()).Returns(() => Task.FromResult(tasks));
            IPeekTodoUseCase useCase = new PeekTodoUseCase(_storageMock.Object);

            var task = await useCase.Execute();

            Assert.Same(tasks.Last(), task);
        }

        private static TodoTask[] CreateTasks(params string[] descriptions)
        {
            var tasks = new TodoTask[descriptions.Length];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new TodoTask
                {
                    Position = i,
                    Description = descriptions[i]
                };
            }

            return tasks;
        }
    }
}

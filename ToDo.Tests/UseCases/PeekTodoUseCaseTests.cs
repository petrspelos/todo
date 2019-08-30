using System.Linq;
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
        public void NoTasks_ReturnsNull()
        {
            var tasks = new TodoTask[0];
            _storageMock.Setup(s => s.RetrieveAll()).Returns(() => tasks);
            IPeekTodoUseCase useCase = new PeekTodoUseCase(_storageMock.Object);

            var task = useCase.Execute();

            Assert.Null(task);
        }

        [Fact]
        public void OneTask_ReturnsTheTask()
        {
            var tasks = CreateTasks("The Task");

            _storageMock.Setup(s => s.RetrieveAll()).Returns(() => tasks);
            IPeekTodoUseCase useCase = new PeekTodoUseCase(_storageMock.Object);

            var task = useCase.Execute();

            Assert.Same(tasks[0], task);
        }

        [Fact]
        public void TaskList_ReturnsLast()
        {
            var tasks = CreateTasks("First Task", "Second Task", "Last Task");

            _storageMock.Setup(s => s.RetrieveAll()).Returns(() => tasks);
            IPeekTodoUseCase useCase = new PeekTodoUseCase(_storageMock.Object);

            var task = useCase.Execute();

            Assert.Same(tasks.Last(), task);
        }

        private static TodoTask[] CreateTasks(params string[] descriptions)
        {
            var tasks = new TodoTask[descriptions.Length];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new TodoTask
                {
                    Id = i,
                    Description = descriptions[i]
                };
            }

            return tasks;
        }
    }
}

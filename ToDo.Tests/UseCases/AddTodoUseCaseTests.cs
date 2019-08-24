using System.Linq;
using ToDo.Storage;
using ToDo.Tests.Spies;
using ToDo.Tests.Stubs;
using ToDo.UseCases.AddTodo;
using Xunit;

namespace ToDo.Tests.UseCases
{
    public class AddTodoUseCaseTests
    {
        [Fact]
        public void NullTask_DoesNotThrow()
        {
            ITaskStorage storage = new TaskStorageStub();
            IAddTodoUseCase useCase = new AddTodoUseCase(storage);

            useCase.Execute(null);
        }

        [Fact]
        public void NewTask_GetsAdded()
        {
            var storageSpy = new InMemoryTaskStorageSpy();
            IAddTodoUseCase useCase = new AddTodoUseCase(storageSpy);

            useCase.Execute("Task");

            Assert.Single(storageSpy.Tasks);
            Assert.Equal("Task", storageSpy.Tasks.First());
        }

        [Fact]
        public void SecondTask_GetsAdded()
        {
            var storageSpy = new InMemoryTaskStorageSpy();
            IAddTodoUseCase useCase = new AddTodoUseCase(storageSpy);
            
            useCase.Execute("Task 1");
            useCase.Execute("Task 2");

            Assert.Equal(2, storageSpy.Tasks.Count);
            Assert.NotEqual(storageSpy.Tasks.ElementAt(0), storageSpy.Tasks.ElementAt(1));
            Assert.Contains("Task 2", storageSpy.Tasks);
        }

        [Fact]
        public void Duplicates_GetAdded()
        {
            var storageSpy = new InMemoryTaskStorageSpy();
            IAddTodoUseCase useCase = new AddTodoUseCase(storageSpy);

            useCase.Execute("Task 1");
            useCase.Execute("Task 1");

            Assert.Equal(2, storageSpy.Tasks.Count);
            Assert.Equal(storageSpy.Tasks.ElementAt(0), storageSpy.Tasks.ElementAt(1));
        }
    }
}

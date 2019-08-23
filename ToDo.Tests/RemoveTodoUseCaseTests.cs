using Xunit;

namespace ToDo.Tests
{
    public class RemoveTodoUseCaseTests
    {
        [Fact]
        public void InvalidId_ShouldNotRemoveAnything()
        {
            var spy = new InMemoryTaskStorageSpy(new []{ "Task 1" });
            IRemoveTodoUseCase useCase = new RemoveTodoUseCase(spy);

            useCase.ExecuteById(-1);

            Assert.Single(spy.Tasks);
        }

        [Fact]
        public void ValidId_ShouldRemoveItem()
        {
            var spy = new InMemoryTaskStorageSpy(new[] { "Task 1" });
            IRemoveTodoUseCase useCase = new RemoveTodoUseCase(spy);

            useCase.ExecuteById(0);

            Assert.Empty(spy.Tasks);
        }
    }
}

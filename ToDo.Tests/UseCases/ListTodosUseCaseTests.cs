using ToDo.Tests.Spies;
using ToDo.UseCases.ListTodos;
using Xunit;

namespace ToDo.Tests.UseCases
{
    public class ListTodosUseCaseTests
    {
        [Fact]
        public void EmptyList_ReturnsEmptyArray()
        {
            IListTodosUseCase useCase = new ListTodosUseCase(new InMemoryTaskStorageSpy());

            var actual = useCase.Execute();

            Assert.Empty(actual);
        }

        [Fact]
        public void TwoItems_ShouldBeListed()
        {
            var spy = new InMemoryTaskStorageSpy(new [] { "Task 1", "Task 2" });
            IListTodosUseCase useCase = new ListTodosUseCase(spy);

            var actual = useCase.Execute();

            Assert.Equal(2, actual.Length);
            Assert.NotEqual(actual[0].Id, actual[1].Id);
        }
    }
}

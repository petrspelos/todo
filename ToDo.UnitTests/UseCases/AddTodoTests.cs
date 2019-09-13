using ToDo.Application.UseCases.Todo;
using ToDo.Application.Boundaries.Todo.Add;
using System;
using Xunit;

namespace ToDo.UnitTests.UseCases
{
    public class AddTodoTests
    {
        [Fact]
        public void NullInput_ShouldThrow()
        {
            IAddTodoUseCase useCase = new AddTodoUseCase();
            Assert.Throws<Exception>(() => {
                useCase.Execute(null);
            });
        }
    }
}

using System;
using System.Threading.Tasks;
using ToDo.Application.Boundaries.Event.Add;
using ToDo.Application.UseCases.Event;
using Xunit;

namespace ToDo.UnitTests.UseCases
{
    public class AddEventTests
    {
        [Fact]
        public async Task NullValues_ShouldThrow()
        {
            IAddEventUseCase useCase = new AddEventUseCase();

            await Assert.ThrowsAsync<Exception>(async () => {
                await useCase.Execute(null);
            });
        }
    }
}

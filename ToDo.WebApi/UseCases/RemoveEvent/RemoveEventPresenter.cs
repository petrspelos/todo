using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Event.Remove;

namespace ToDo.WebApi.UseCases.RemoveEvent
{
    public sealed class RemoveEventPresenter : IRemoveEventOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public RemoveEventPresenter()
        {
            ViewModel = new NoContentResult();
        }

        public void Default(RemoveEventOutput output)
        {
            var response = new RemoveEventResponse
            {
                Id = output.EventId
            };

            ViewModel = new OkObjectResult(response);
        }

        public void Error(string message)
        {
            var details = new ProblemDetails
            {
                Title = "An error occured while processing your request.",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(details);
        }
    }
}

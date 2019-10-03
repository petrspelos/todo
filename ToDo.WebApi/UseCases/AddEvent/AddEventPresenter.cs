using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Event.Add;

namespace ToDo.WebApi.UseCases.AddEvent
{
    public sealed class AddEventPresenter : IAddEventOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public AddEventPresenter()
        {
            ViewModel = new NoContentResult();
        }
        
        public void Default(AddEventOutput output)
        {
            var result = new AddEventResponse
            {
                EventId = output.EventId,
                EventName = output.EventName,
                EventDescription = output.EventDescription,
                EventStartDate = output.EventStartDate,
                EventDuration = output.EventDuration
            };

            ViewModel = new OkObjectResult(result);
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

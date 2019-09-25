using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Todo.Remove;

namespace ToDo.WebApi.UseCases.RemoveTodo
{
    public sealed class RemoveTodoPresenter : IRemoveTodoOutputPort
    {
        public IActionResult ViewModel { get; set; }

        public RemoveTodoPresenter()
        {
            ViewModel = new NoContentResult();
        }

        public void Default(RemoveTodoOutput output)
        {
            var response = new RemoveTodoResponse
            {
                Id = output.Id
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

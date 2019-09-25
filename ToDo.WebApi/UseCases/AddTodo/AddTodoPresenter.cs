using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Todo.Add;

namespace ToDo.WebApi.UseCases.AddTodo
{
    public sealed class AddTodoPresenter : IAddTodoOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public AddTodoPresenter()
        {
            ViewModel = new NoContentResult();
        }
        
        public void Default(AddTodoOutput output)
        {
            var response = new AddTodoTaskResponse
            {
                TaskId = output.TaskId,
                TaskName = output.TaskName,
                TaskDescription = output.TaskDescription,
                TaskDueDate = output.TaskDueDate,
                TaskIsCompleted = output.TaskIsCompleted
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

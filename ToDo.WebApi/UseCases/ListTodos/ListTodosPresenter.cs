using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Todo.List;
using ToDo.WebApi.Models;

namespace ToDo.WebApi.UseCases.ListTodos
{
    public sealed class ListTodosPresenter : IListTodosOutputPort
    {
        public IActionResult ViewModel { get; private set; }
        
        public ListTodosPresenter()
        {
            ViewModel = new NoContentResult();
        }

        public void Default(ListTodosOutput output)
        {
            var result = new List<TodoTaskModel>();

            foreach(var task in output.Tasks)
            {
                result.Add(new TodoTaskModel
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    IsCompleted = task.IsCompleted
                });
            }

            var response = new ListTodosResponse
            {
                Tasks = result
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

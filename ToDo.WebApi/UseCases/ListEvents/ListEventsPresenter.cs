using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Event.List;
using ToDo.WebApi.Models;

namespace ToDo.WebApi.UseCases.ListEvents
{
    public sealed class ListEventsPresenter : IListEventsOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Default(ListEventsOutput output)
        {
            var result = new List<CalendarEventModel>();

            foreach(var task in output.Events)
            {
                result.Add(new CalendarEventModel
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    StartDate = task.StartDate,
                    Duration = task.Duration
                });
            }

            var response = new ListEventsResponse
            {
                Events = result
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

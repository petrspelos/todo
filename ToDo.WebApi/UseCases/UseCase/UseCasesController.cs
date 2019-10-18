using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Event.Add;

namespace ToDo.WebApi.UseCases.UseCase
{
    [ApiController]
    [Route("api")]
    public sealed class AddEventController : Controller
    {
        [HttpGet("about")]
        public IActionResult About()
            => Content("Personal_ToDo_Application");
    }
}

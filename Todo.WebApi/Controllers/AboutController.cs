using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("app")]
        public IActionResult AboutApp()
            => Content("Personal_ToDo_Application");
    }
}

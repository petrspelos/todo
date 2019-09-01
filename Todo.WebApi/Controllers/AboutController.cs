using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ToDo.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AboutApp()
            => Content("Personal_ToDo_Application");
    }
}

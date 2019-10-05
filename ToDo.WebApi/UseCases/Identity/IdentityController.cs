using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.WebApi.UseCases.Identity
{
    [Authorize]
    [ApiController]
    [Route("api/identity")]
    public class IdentityController : Controller
    {
        [HttpGet("verify")]
        public IActionResult Verify()
        {
            return Ok("OK");
        }
    }
}
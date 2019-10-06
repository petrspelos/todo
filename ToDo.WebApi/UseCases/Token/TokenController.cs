using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Services;

namespace ToDo.WebApi.UseCases.Token
{
    [ApiController]
    [Authorize]
    [Route("token")]
    public class TokenController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public TokenController(IAuthService authService, IUserService userService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("authorize")]
        [AllowAnonymous]
        public async Task<IActionResult> Authorize([FromBody]TokenRequest request)
        {
            var user = await _userService.Authenticate(request.Username, request.Password);
            if(user == null) { 
                return NotFound();
            }
            return Ok(_authService.GenerateTokenFromUser(user));
        }
    }
}

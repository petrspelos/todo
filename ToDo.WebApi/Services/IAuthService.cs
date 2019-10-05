using System.Collections.Generic;
using System.Security.Claims;
using ToDo.WebApi.Config;
using ToDo.WebApi.Entities;

namespace ToDo.WebApi.Services
{
    public interface IAuthService
    {
        bool IsTokenValid(string token);
        string GenerateToken(IAuthModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
        string GenerateTokenFromUser(User user);
    }
}
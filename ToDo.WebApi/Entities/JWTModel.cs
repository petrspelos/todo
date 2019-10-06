using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
namespace ToDo.WebApi.Entities
{
    public class JWTModel : IAuthModel
    {
        public JWTModel(Claim[] claims)
        {
            this.Claims = claims;
        }
        public Claim[] Claims { get; set; }
    }
}

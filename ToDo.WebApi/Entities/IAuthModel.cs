using System.Security.Claims;

namespace ToDo.WebApi.Entities
{
    public interface IAuthModel
    {
        Claim[] Claims { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ToDo.WebApi.UseCases.Token
{
    public class TokenRequest {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}

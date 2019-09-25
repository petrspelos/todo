using System.Threading.Tasks;
using ToDo.WebApi.Entities;
using ToDo.WebApi.Helpers;
using ToDo.WebApi.Storage;

namespace ToDo.WebApi.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IUserStorage _users;

        public UserService(IUserStorage users)
        {
            _users = users;
        }

        public Task<User> Authenticate(string username, string password)
        {
            var user = _users.GetByPredicate(u => u.Username == username);

            if (user != null && PasswordStorage.VerifyPassword(password, user.Password ?? string.Empty))
            {
                user.Password = null;
                return Task.FromResult(user);
            }
            
            return null!;
        }
    }
}

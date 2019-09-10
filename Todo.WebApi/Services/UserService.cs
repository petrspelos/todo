using System.Threading.Tasks;
using ToDo.WebApi.Entities;
using ToDo.WebApi.Helpers;
using ToDo.WebApi.Repositories;
using ToDo.WebApi.Storage;

namespace ToDo.WebApi.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _users;

        public UserService(IUserRepository users)
        {
            _users = users;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _users.GetByName(username);

            if (user != null && PasswordStorage.VerifyPassword(password, user.Password))
            {
                user.Password = null;
                return user;
            }
            
            return null;
        }
    }
}

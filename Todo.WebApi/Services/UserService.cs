using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.WebApi.Entities;
using Todo.WebApi.Helpers;
using Todo.WebApi.Storage;

namespace WebApi.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IReadonlyStorage<User> _storage;

        public UserService(IReadonlyStorage<User> storage)
        {
            _storage = storage;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _storage.GetByPredicate(x => x.Username == username));

            if(user is null) { return null; }

            if(!PasswordStorage.VerifyPassword(password, user.Password)) { return null; }

            user.Password = null;
            return user;
        }
    }
}

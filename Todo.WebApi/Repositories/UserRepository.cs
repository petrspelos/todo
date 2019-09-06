using System;
using System.IO;
using System.Threading.Tasks;
using ToDo.WebApi.Entities;
using ToDo.WebApi.Storage;

namespace ToDo.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IReadonlyStorage<User> _storage;

        public UserRepository(IReadonlyStorage<User> storage)
        {
            _storage = storage;
        }

        public Task<User> GetByName(string username)
        {
            var user = _storage.GetByPredicate(u => u.Username == username);
            return Task.FromResult(user);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.WebApi.Entities;
using ToDo.WebApi.Helpers;
using ToDo.WebApi.Storage;

namespace ToDo.WebApi.Tests
{
    internal class TestUserReadonlyStorage : IReadonlyStorage<User>
    {
        private readonly ICollection<User> _users;

        public TestUserReadonlyStorage()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "User",
                    Password = PasswordStorage.CreateHash("Password")
                }
            };
        }

        public User GetByPredicate(Predicate<User> predicate)
            => _users.FirstOrDefault(predicate.Invoke);
    }
}

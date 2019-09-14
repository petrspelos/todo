using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ToDo.WebApi.Entities;
using ToDo.WebApi.Helpers;

namespace ToDo.WebApi.Storage
{
    public class JsonUserStorage : IUserStorage
    {
        public User GetByPredicate(Predicate<User> predicate)
        {
            Directory.CreateDirectory("json");
            var filePath = Path.Combine("json", $".json");

            try
            {
                var json = File.ReadAllText(filePath);
                var all = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
                return all.FirstOrDefault(predicate.Invoke);
            }
            catch (FileNotFoundException)
            {
                var user = new User {
                    Id = Guid.NewGuid(),
                    Username = "todoist",
                    Password = PasswordStorage.CreateHash("todoist")
                };
                var defaultJson = JsonConvert.SerializeObject(new[] { user });
                File.WriteAllText(filePath, defaultJson);
                return user;
            }
        }
    }
}

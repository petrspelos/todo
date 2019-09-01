using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ToDo.WebApi.Storage
{
    public class JsonReadonlyStorage<T> : IReadonlyStorage<T>
    {
        public T GetByPredicate(Predicate<T> predicate)
        {
            Directory.CreateDirectory("json");
            var filePath = Path.Combine("json", $"{typeof(T).FullName}.json");
            if(!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            var json = File.ReadAllText(filePath);
            var all = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

            return all.FirstOrDefault(a => predicate.Invoke(a));
        }
    }
}

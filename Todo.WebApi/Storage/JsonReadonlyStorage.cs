using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ToDo.WebApi.Storage
{
    public class JsonReadonlyStorage<T> : IReadonlyStorage<T>
    {
        private readonly T _defaultValue;

        public JsonReadonlyStorage(T defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public T GetByPredicate(Predicate<T> predicate)
        {
            Directory.CreateDirectory("json");
            var filePath = Path.Combine("json", $"{typeof(T).FullName}.json");

            try
            {
                var json = File.ReadAllText(filePath);
                var all = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                return all.FirstOrDefault(predicate.Invoke);
            }
            catch (FileNotFoundException)
            {
                var defaultJson = JsonConvert.SerializeObject(new[] {_defaultValue});
                File.WriteAllText(filePath, defaultJson);
                return _defaultValue;
            }
        }
    }
}

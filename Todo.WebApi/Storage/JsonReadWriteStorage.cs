using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Todo.WebApi.Entities;

namespace Todo.WebApi.Storage
{
    public class JsonReadWriteStorage<T> : IReadWriteStorage<T> where T : IUnique
    {
        private readonly string directory = $"json/{typeof(T).FullName}";

        public T Get(Predicate<T> predicate)
        {
            var all = GetAll();
            return all.FirstOrDefault(predicate.Invoke);
        }

        public IEnumerable<T> GetAll()
        {
            Directory.CreateDirectory(directory);
            var files = Directory.GetFiles(directory, "*.json");
            var result = new List<T>();

            foreach(var file in files)
            {
                var id = Path.GetFileNameWithoutExtension(file);
                if(!Guid.TryParse(id, out var guid)) continue;
                var json = File.ReadAllText(file);
                try
                {
                    var obj = JsonConvert.DeserializeObject<T>(json);
                    if(!obj.Id.Equals(guid)) continue;
                    result.Add(obj);
                }
                catch (JsonSerializationException)
                {
                    continue;
                }
            }
            
            return result;
        }

        public void Store(T obj)
        {
            var storageFile = $"{obj.Id}.json";
            Directory.CreateDirectory(directory);
            var path = Path.Combine(directory, storageFile);
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}

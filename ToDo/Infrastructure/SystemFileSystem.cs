using System.IO;
using System.Linq;

namespace ToDo.Infrastructure
{
    public class SystemFileSystem : IFileSystem
    {
        public void AppendLine(string line, string fileName)
        {
            EnsureFileExistence(fileName);
            File.AppendAllLines(fileName, new[] {line});
        }

        private static void EnsureFileExistence(string fileName)
        {
            if (File.Exists(fileName)) { return; }
            File.WriteAllText(fileName, "");
        }

        public string[] ReadAllLines(string fileName)
        {
            EnsureFileExistence(fileName);
            return File.ReadAllLines(fileName);
        }

        public void RemoveLine(int id, string fileName)
        {
            EnsureFileExistence(fileName);
            var todos = ReadAllLines(fileName).ToList();

            if (id < 0 || id >= todos.Count) { return; }

            todos.RemoveAt(id);

            File.WriteAllLines(fileName, todos);
        }
    }
}
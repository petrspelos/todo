using System.IO;
using System.Threading.Tasks;
using ToDo.Infrastructure.JsonStorage.FileSystem;

namespace ToDo.WebApi.FileSystem
{
    public sealed class SystemFileSystem : IFileSystem
    {
        public Task<bool> FileExists(string path)
        {
            EnsureDirectoryExists(path);
            return Task.FromResult(File.Exists(path));
        }

        public Task<string> GetFileContents(string path)
        {
            EnsureDirectoryExists(path);
            return Task.FromResult(File.ReadAllText(path));
        }

        public Task WriteFileContents(string path, string contents)
        {
            EnsureDirectoryExists(path);
            File.WriteAllText(path, contents);
            return Task.CompletedTask;
        }

        private void EnsureDirectoryExists(string path)
        {
            var directory = Path.GetDirectoryName(path);
            Directory.CreateDirectory(directory);
        }
    }
}

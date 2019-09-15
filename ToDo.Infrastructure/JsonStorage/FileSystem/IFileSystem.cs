using System.Threading.Tasks;

namespace ToDo.Infrastructure.JsonStorage.FileSystem
{
    public interface IFileSystem
    {
        Task<bool> FileExists(string path);
        Task<string> GetFileContents(string path);
        Task WriteFileContents(string path, string contents);
    }
}

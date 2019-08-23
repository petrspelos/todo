namespace ToDo.Infrastructure
{
    public interface IFileSystem
    {
        void AppendLine(string line, string fileName);
        string[] ReadAllLines(string fileName);
        void RemoveLine(int id, string fileName);
    }
}

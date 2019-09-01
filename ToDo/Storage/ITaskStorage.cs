using System.Threading.Tasks;
using ToDo.Entities;

namespace ToDo.Storage
{
    public interface ITaskStorage
    {
        Task Store(TodoTask task);
        Task<TodoTask[]> RetrieveAll();
        Task Remove(int id);
    }
}

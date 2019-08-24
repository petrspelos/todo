using ToDo.Entities;

namespace ToDo.Storage
{
    public interface ITaskStorage
    {
        void Store(TodoTask task);
        TodoTask[] RetrieveAll();
        void Remove(int id);
    }
}

namespace ToDo
{
    public interface ITaskStorage
    {
        void Store(TodoTask task);
        TodoTask[] RetrieveAll();
        void Remove(int id);
    }
}

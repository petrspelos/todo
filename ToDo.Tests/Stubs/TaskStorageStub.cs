using ToDo.Entities;
using ToDo.Storage;

namespace ToDo.Tests.Stubs
{
    public class TaskStorageStub : ITaskStorage
    {
        public void Store(TodoTask task) => throw new System.NotImplementedException();
        public TodoTask[] RetrieveAll() => throw new System.NotImplementedException();
        public void Remove(int id) => throw new System.NotImplementedException();
    }
}
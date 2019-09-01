using System;
using System.Collections.Generic;

namespace ToDo.WebApi.Storage
{
    public interface IReadWriteStorage<T>
    {
        IEnumerable<T> GetAll();
        T Get(Predicate<T> predicate);
        void Store(T obj);
    }
}

using System;
using System.Collections.Generic;

namespace Todo.WebApi.Storage
{
    public interface IReadWriteStorage<T>
    {
        IEnumerable<T> GetAll();
        T Get(Predicate<T> predicate);
        void Store(T obj);
    }
}

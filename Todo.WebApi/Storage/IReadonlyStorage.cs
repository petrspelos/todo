using System;

namespace Todo.WebApi.Storage
{
    public interface IReadonlyStorage<T>
    {
        T GetByPredicate(Predicate<T> predicate);
    }
}

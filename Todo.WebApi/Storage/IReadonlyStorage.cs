using System;

namespace ToDo.WebApi.Storage
{
    public interface IReadonlyStorage<T>
    {
        T GetByPredicate(Predicate<T> predicate);
    }
}

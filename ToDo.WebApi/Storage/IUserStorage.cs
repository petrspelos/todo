using System;
using ToDo.WebApi.Entities;

namespace ToDo.WebApi.Storage
{
    public interface IUserStorage
    {
        User GetByPredicate(Predicate<User> predicate);
    }
}

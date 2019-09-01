using System;

namespace Todo.WebApi.Entities
{
    public interface IUnique
    {
        Guid Id { get; }
    }
}

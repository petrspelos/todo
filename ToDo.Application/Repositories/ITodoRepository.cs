using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Todos;

namespace ToDo.Application.Repositories
{
    public interface ITodoRepository
    {
        Task Add(ITodoTask task);
        Task<IEnumerable<ITodoTask>> GetAll();
        Task<bool> Exists(Guid id);
        Task<ITodoTask> Remove(Guid id);
    }
}

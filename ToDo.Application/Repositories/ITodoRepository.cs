using System.Threading.Tasks;
using ToDo.Domain.Todos;

namespace ToDo.Application.Repositories
{
    public interface ITodoRepository
    {
        Task Add(ITodoTask task);
    }
}

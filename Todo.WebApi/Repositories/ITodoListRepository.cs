using System.Threading.Tasks;
using ToDo.Entities;
using ToDo.WebApi.Entities;

namespace ToDo.WebApi.Repositories
{
    public interface ITodoListRepository
    {
        TodoList GetPublic();
        void Store(TodoList list);
    }
}

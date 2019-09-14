using System.Threading.Tasks;

namespace ToDo.Application.Boundaries.Todo.List
{
    public interface IListTodosUseCase
    {
        Task Execute();
    }
}

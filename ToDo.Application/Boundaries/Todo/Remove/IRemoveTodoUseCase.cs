using System.Threading.Tasks;

namespace ToDo.Application.Boundaries.Todo.Remove
{
    public interface IRemoveTodoUseCase
    {
        Task Execute(RemoveTodoInput input);
    }
}

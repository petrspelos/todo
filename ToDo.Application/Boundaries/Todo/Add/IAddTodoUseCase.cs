using System.Threading.Tasks;

namespace ToDo.Application.Boundaries.Todo.Add
{
    public interface IAddTodoUseCase
    {
        Task Execute(AddTodoInput input);
    }
}

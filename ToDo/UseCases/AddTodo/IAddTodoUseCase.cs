using System.Threading.Tasks;

namespace ToDo.UseCases.AddTodo
{
    public interface IAddTodoUseCase
    {
        Task Execute(string description);
    }
}

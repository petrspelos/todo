using System.Threading.Tasks;
using ToDo.Entities;

namespace ToDo.UseCases.PeekTodo
{
    public interface IPeekTodoUseCase
    {
        Task<TodoTask> Execute();
    }
}

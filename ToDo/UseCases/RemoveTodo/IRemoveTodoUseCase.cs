using System.Threading.Tasks;

namespace ToDo.UseCases.RemoveTodo
{
    public interface IRemoveTodoUseCase
    {
        Task ExecuteById(int id);
    }
}
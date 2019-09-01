using System.Threading.Tasks;
using ToDo.Entities;

namespace ToDo.UseCases.ListTodos
{
    public interface IListTodosUseCase
    {
        Task<TodoTask[]> Execute();
    }
}

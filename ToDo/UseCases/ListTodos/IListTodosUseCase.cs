using ToDo.Entities;

namespace ToDo.UseCases.ListTodos
{
    public interface IListTodosUseCase
    {
        TodoTask[] Execute();
    }
}

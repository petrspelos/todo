namespace ToDo.Application.Boundaries.Todo.Add
{
    public interface IAddTodoUseCase
    {
        void Execute(AddTodoInput input);
    }
}

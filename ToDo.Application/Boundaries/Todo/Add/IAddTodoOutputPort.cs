namespace ToDo.Application.Boundaries.Todo.Add
{
    public interface IAddTodoOutputPort : IErrorHandler
    {
        void Default(AddTodoOutput output);
    }
}

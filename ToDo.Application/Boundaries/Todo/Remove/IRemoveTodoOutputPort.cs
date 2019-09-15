namespace ToDo.Application.Boundaries.Todo.Remove
{
    public interface IRemoveTodoOutputPort : IErrorHandler
    {
        void Default(RemoveTodoOutput output);
    }
}

namespace ToDo.Application.Boundaries.Todo.List
{
    public interface IListTodosOutputPort : IErrorHandler
    {
        void Default(ListTodosOutput output);
    }
}

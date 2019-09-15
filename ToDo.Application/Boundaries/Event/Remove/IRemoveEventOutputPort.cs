namespace ToDo.Application.Boundaries.Event.Remove
{
    public interface IRemoveEventOutputPort : IErrorHandler
    {
        void Default(RemoveEventOutput output);
    }
}

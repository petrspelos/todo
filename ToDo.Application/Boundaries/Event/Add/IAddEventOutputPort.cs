namespace ToDo.Application.Boundaries.Event.Add
{
    public interface IAddEventOutputPort : IErrorHandler
    {
        void Default(AddEventOutput output);
    }
}

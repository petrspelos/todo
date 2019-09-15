namespace ToDo.Application.Boundaries.Event.List
{
    public interface IListEventsOutputPort : IErrorHandler
    {
        void Default(ListEventsOutput output);
    }
}

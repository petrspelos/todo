namespace ToDo.Domain.Events
{
    public class DurationCannotBeNegativeException : DomainException
    {
        public DurationCannotBeNegativeException(string message) : base(message) { }
    }
}

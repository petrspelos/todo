namespace ToDo.Domain.Todos
{
    public sealed class NameIsTooLongException : DomainException
    {
        public NameIsTooLongException(string message) : base(message) { }
    }
}

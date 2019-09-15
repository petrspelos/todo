namespace ToDo.Domain
{
    public sealed class NameIsTooLongException : DomainException
    {
        public NameIsTooLongException(string message) : base(message) { }
    }
}

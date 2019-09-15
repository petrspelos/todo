namespace ToDo.Domain.Todos
{
    public sealed class NameShouldNotBeNullOrEmptyException : DomainException
    {
        public NameShouldNotBeNullOrEmptyException(string message) : base(message) { }
    }
}

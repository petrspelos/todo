namespace ToDo.Domain
{
    public sealed class NameShouldNotBeNullOrEmptyException : DomainException
    {
        public NameShouldNotBeNullOrEmptyException(string message) : base(message) { }
    }
}

using System;

namespace ToDo.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string businessMessage) : base(businessMessage) { }
    }
}

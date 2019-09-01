using System;

namespace Todo.WebApi.Entities
{
    public class User : IUnique
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

using System;

namespace Todo.WebApi.Entities
{
    public class TodoTask : IUnique
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}

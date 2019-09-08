using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Entities;
using ToDo.WebApi.Storage;

namespace ToDo.WebApi.Tests
{
    internal class TestTaskReadWriteStorage : IReadWriteStorage<TodoList>
    {
        private readonly ICollection<TodoList> _lists;

        public TestTaskReadWriteStorage()
        {
            _lists = new List<TodoList>
            {
                new TodoList
                {
                    Id = Guid.NewGuid(),
                    Name = "public",
                    Tasks = new List<TodoTask>
                    {
                        new TodoTask
                        {
                            Id = Guid.Parse("6328259d-07c7-4443-9973-9fac0404b9b2"),
                            Description = "Task 1"
                        },
                        new TodoTask
                        {
                            Id = Guid.Parse("76c4c3d2-757b-43d5-bce7-223c7d68db4a"),
                            Description = "Task 2"
                        }
                    }
                }
            };
        }

        public IEnumerable<TodoList> GetAll() => _lists;

        public TodoList Get(Predicate<TodoList> predicate)
            => _lists.FirstOrDefault(predicate.Invoke);

        public void Store(TodoList list) => _lists.Add(list);
    }
}
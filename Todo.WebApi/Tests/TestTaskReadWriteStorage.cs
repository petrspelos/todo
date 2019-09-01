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
                            Id = Guid.NewGuid(),
                            Description = "Todo task"
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
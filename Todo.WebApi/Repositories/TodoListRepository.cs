using System;
using System.Collections.Generic;
using ToDo.Entities;
using ToDo.WebApi.Storage;

namespace ToDo.WebApi.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly IReadWriteStorage<TodoList> _storage;

        public TodoListRepository(IReadWriteStorage<TodoList> storage)
        {
            _storage = storage;
        }

        public TodoList GetPublic()
        {
            var publicTodoList = _storage.Get(l => l.Name == "public");
            
            if (publicTodoList is null)
            {
                publicTodoList = new TodoList
                {
                    Id = Guid.NewGuid(),
                    Name = "public",
                    Tasks = new List<TodoTask>()
                };

                _storage.Store(publicTodoList);
            }

            return publicTodoList;
        }

        public void Store(TodoList list) => _storage.Store(list);
    }
}
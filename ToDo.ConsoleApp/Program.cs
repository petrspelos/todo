using System;
using System.Linq;
using ToDo.Infrastructure;
using ToDo.Storage;
using ToDo.UseCases.AddTodo;
using ToDo.UseCases.ListTodos;
using ToDo.UseCases.RemoveTodo;

namespace ToDo.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (!args.Any()) { return; }

            IFileSystem fileSystem = new SystemFileSystem();
            ITaskStorage storage = new FileTaskStorage(fileSystem);

            switch (args[0])
            {
                case "add" when args.Length == 2:
                {
                    IAddTodoUseCase useCase = new AddTodoUseCase(storage);
                    useCase.Execute(args[1]);
                    break;
                }
                case "list":
                {
                    IListTodosUseCase useCase = new ListTodosUseCase(storage);
                    var result = useCase.Execute();

                    foreach (var item in result)
                    {
                        Console.WriteLine($"[{item.Id}] {item.Description}");
                    }

                    break;
                }
                case "remove" when args.Length == 2:
                {
                    IRemoveTodoUseCase useCase = new RemoveTodoUseCase(storage);
                    
                    if (int.TryParse(args[1], out var id))
                    {
                        useCase.ExecuteById(id);
                    }
                    
                    break;
                }
            }
        }
    }
}

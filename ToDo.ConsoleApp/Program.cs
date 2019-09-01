using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToDo.Infrastructure;
using ToDo.Storage;
using ToDo.UseCases.AddTodo;
using ToDo.UseCases.ListTodos;
using ToDo.UseCases.PeekTodo;
using ToDo.UseCases.RemoveTodo;

namespace ToDo.ConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            if (!args.Any()) { return; }

            IFileSystem fileSystem = new SystemFileSystem();
            ITaskStorage storage = new FileTaskStorage(fileSystem);

            switch (args[0])
            {
                case "add" when args.Length == 2:
                {
                    IAddTodoUseCase useCase = new AddTodoUseCase(storage);
                    await useCase.Execute(args[1]);
                    break;
                }
                case "remove" when args.Length == 2:
                {
                    IRemoveTodoUseCase useCase = new RemoveTodoUseCase(storage);

                    if (int.TryParse(args[1], out var id))
                    {
                        await useCase.ExecuteById(id);
                    }

                    break;
                }
                case "list":
                {
                    IListTodosUseCase useCase = new ListTodosUseCase(storage);
                    var result = await useCase.Execute();

                    foreach (var item in result)
                    {
                        Console.WriteLine($"[{item.Position}] {item.Description}");
                    }

                    break;
                }
                case "peek":
                {
                    IPeekTodoUseCase useCase = new PeekTodoUseCase(storage);
                    var item = await useCase.Execute();

                    Console.WriteLine($"-> [{item.Position}] {item.Description}");
                    break;
                }
            }
        }
    }
}

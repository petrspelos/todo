using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Boundaries.Todo.Add;
using ToDo.Application.Boundaries.Todo.List;
using ToDo.WebApi.UseCases.AddTodo;
using ToDo.WebApi.UseCases.ListTodos;

namespace ToDo.WebApi.Extensions
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<AddTodoPresenter>();
            services.AddScoped<IAddTodoOutputPort, AddTodoPresenter>(x => x.GetRequiredService<AddTodoPresenter>());

            services.AddScoped<ListTodosPresenter>();
            services.AddScoped<IListTodosOutputPort, ListTodosPresenter>(x => x.GetRequiredService<ListTodosPresenter>());

            return services;
        }
    }
}

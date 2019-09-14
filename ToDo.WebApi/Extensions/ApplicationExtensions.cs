using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Boundaries.Todo.Add;
using ToDo.Application.Boundaries.Todo.List;
using ToDo.Application.UseCases.Todo;

namespace ToDo.WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IAddTodoUseCase, AddTodoUseCase>();
            services.AddScoped<IListTodosUseCase, ListTodosUseCase>();

            return services;
        }
    }
}

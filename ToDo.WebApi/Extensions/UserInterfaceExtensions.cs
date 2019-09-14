using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Boundaries.Todo.Add;
using ToDo.WebApi.UseCases.AddTodo;

namespace ToDo.WebApi.Extensions
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<AddTodoPresenter>();
            services.AddScoped<IAddTodoOutputPort, AddTodoPresenter>(x => x.GetRequiredService<AddTodoPresenter>());

            return services;
        }
    }
}

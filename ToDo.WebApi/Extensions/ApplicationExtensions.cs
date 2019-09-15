using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Boundaries.Event.Add;
using ToDo.Application.Boundaries.Event.List;
using ToDo.Application.Boundaries.Event.Remove;
using ToDo.Application.Boundaries.Todo.Add;
using ToDo.Application.Boundaries.Todo.List;
using ToDo.Application.Boundaries.Todo.Remove;
using ToDo.Application.UseCases.Event;
using ToDo.Application.UseCases.Todo;

namespace ToDo.WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IAddTodoUseCase, AddTodoUseCase>();
            services.AddScoped<IListTodosUseCase, ListTodosUseCase>();
            services.AddScoped<IRemoveTodoUseCase, RemoveTodoUseCase>();
            services.AddScoped<IAddEventUseCase, AddEventUseCase>();
            services.AddScoped<IListEventsUseCase, ListEventsUseCase>();
            services.AddScoped<IRemoveEventUseCase, RemoveEventUseCase>();

            return services;
        }
    }
}

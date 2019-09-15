using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Boundaries.Event.Add;
using ToDo.Application.Boundaries.Event.List;
using ToDo.Application.Boundaries.Event.Remove;
using ToDo.Application.Boundaries.Todo.Add;
using ToDo.Application.Boundaries.Todo.List;
using ToDo.Application.Boundaries.Todo.Remove;
using ToDo.WebApi.UseCases.AddEvent;
using ToDo.WebApi.UseCases.AddTodo;
using ToDo.WebApi.UseCases.ListEvents;
using ToDo.WebApi.UseCases.ListTodos;
using ToDo.WebApi.UseCases.RemoveEvent;
using ToDo.WebApi.UseCases.RemoveTodo;

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

            services.AddScoped<RemoveTodoPresenter>();
            services.AddScoped<IRemoveTodoOutputPort, RemoveTodoPresenter>(x => x.GetRequiredService<RemoveTodoPresenter>());

            services.AddScoped<AddEventPresenter>();
            services.AddScoped<IAddEventOutputPort, AddEventPresenter>(x => x.GetRequiredService<AddEventPresenter>());

            services.AddScoped<ListEventsPresenter>();
            services.AddScoped<IListEventsOutputPort, ListEventsPresenter>(x => x.GetRequiredService<ListEventsPresenter>());

            services.AddScoped<RemoveEventPresenter>();
            services.AddScoped<IRemoveEventOutputPort, RemoveEventPresenter>(x => x.GetRequiredService<RemoveEventPresenter>());

            return services;
        }
    }
}

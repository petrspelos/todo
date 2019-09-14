using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Repositories;
using ToDo.Domain;
using ToDo.Infrastructure.JsonStorage;
using ToDo.Infrastructure.JsonStorage.FileSystem;
using ToDo.Infrastructure.JsonStorage.Repositories;
using ToDo.WebApi.FileSystem;

namespace ToDo.WebApi.Extensions
{
    public static class JsonStorageExtensions
    {
        public static IServiceCollection AddJsonStorage(this IServiceCollection services)
        {
            services.AddSingleton<IFileSystem, SystemFileSystem>();
            services.AddScoped<IEntityFactory, EntityFactory>();
            services.AddSingleton<ToDoContext, ToDoContext>();
            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}

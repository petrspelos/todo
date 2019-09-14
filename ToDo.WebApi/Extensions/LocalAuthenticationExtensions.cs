using Microsoft.Extensions.DependencyInjection;
using ToDo.WebApi.Services;
using ToDo.WebApi.Storage;

namespace ToDo.WebApi.Extensions
{
    public static class LocalAuthenticationExtensions
    {
        public static IServiceCollection AddLocalAuthentication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserStorage, JsonUserStorage>();

            return services;
        }
    }
}

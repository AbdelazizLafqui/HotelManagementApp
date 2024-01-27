using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace HotelManagementApp.Application
{
    public static class DependebcyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }

    }
}

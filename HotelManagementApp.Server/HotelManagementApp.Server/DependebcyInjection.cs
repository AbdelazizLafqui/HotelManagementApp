
using HotelManagementApp.Api.Common.Errors;
using HotelManagementApp.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HotelManagementApp.Api
{
    public static class DependebcyInjection
    {

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddSingleton<ProblemDetailsFactory, HMProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }

    }
}

using HotelManagementApp.Application.Common.Interfaces.Authentication;
using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Application.Common.Interfaces.Services;
using HotelManagementApp.Infrastructure.Authentication;
using HotelManagementApp.Infrastructure.Common.Persistence;
using HotelManagementApp.Infrastructure.Serivces;
using HotelManagementApp.Infrastructure.Users.Persistence;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HotelManagementApp.Infrastructure
{
    public static class DependebcyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                   ConfigurationManager configuration)
        {
            services.AddDbContext<HotelManagementDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "HotelManagementDb");
            });

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}

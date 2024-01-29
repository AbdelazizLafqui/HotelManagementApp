using HotelManagementApp.Application.Common.Interfaces.Authentication;
using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Application.Common.Interfaces.Services;
using HotelManagementApp.Infrastructure.Authentication;
using HotelManagementApp.Infrastructure.Common.Persistence;
using HotelManagementApp.Infrastructure.Reservations.Persistence;
using HotelManagementApp.Infrastructure.Rooms.Persistence;
using HotelManagementApp.Infrastructure.Serivces;
using HotelManagementApp.Infrastructure.Users.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddAuth(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services,
                                           ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, 
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF32.GetBytes(jwtSettings.SecretKey))
                });


            return services;
        }
    }
}

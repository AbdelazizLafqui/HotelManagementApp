using HotelManagementApp.Application.Authentication.Queries.Login;
using HotelManagementApp.Application.Authentication.Register.Commands;
using HotelManagementApp.Application.DTOs;
using HotelManagementApp.Contracts.Authentication;
using Mapster;

namespace HotelManagementApp.Api.Common.Mapping
{
    public class AuthenticationMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResultDto, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}

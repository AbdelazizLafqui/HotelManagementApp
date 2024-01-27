using ErrorOr;
using HotelManagementApp.Application.DTOs;
using MediatR;

namespace HotelManagementApp.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email,
                             string Password) : IRequest<ErrorOr<AuthenticationResultDto>>;
}
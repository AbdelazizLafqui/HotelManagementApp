using ErrorOr;
using HotelManagementApp.Application.DTOs;
using MediatR;

namespace HotelManagementApp.Application.Authentication.Register.Commands
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResultDto>>;
}
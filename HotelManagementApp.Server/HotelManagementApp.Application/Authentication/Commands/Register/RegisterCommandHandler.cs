using ErrorOr;
using HotelManagementApp.Application.Common.Interfaces.Authentication;
using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Application.DTOs;
using HotelManagementApp.Domain.Common.Errors;
using Mapster;
using MediatR;

namespace HotelManagementApp.Application.Authentication.Register.Commands
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResultDto>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ErrorOr<AuthenticationResultDto>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(command.Email);

            if (user is not null)
            {
                return CommonErrors.User.DuplicateEmail;
            }

            var newUser = new Domain.Entities.User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            var token = _jwtTokenGenerator.GenerateToken(newUser);

            await _userRepository.AddUserAsync(newUser);

            var userDto = newUser.Adapt<UserDto>();

            return new AuthenticationResultDto(
                userDto,
                token);

        }
    }
}
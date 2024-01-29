using ErrorOr;
using HotelManagementApp.Application.Common.Interfaces.Authentication;
using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Application.DTOs;
using HotelManagementApp.Domain.Common.Errors;
using Mapster;
using MediatR;

namespace HotelManagementApp.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResultDto>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResultDto>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(query.Email);

            var userDto = user.Adapt<UserDto>();

            if (userDto is not UserDto)
            {
                return CommonErrors.Authentication.InvalidCredentials;
            }

            if (userDto.Password != query.Password)
            {
                return CommonErrors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResultDto(
            userDto,
            token);
        }
    }
}
using BubberDinner.Api.Controllers;
using ErrorOr;
using HotelManagementApp.Application.Authentication.Queries.Login;
using HotelManagementApp.Application.Authentication.Register.Commands;
using HotelManagementApp.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelManagementApp.Domain.Common.Errors;
using MapsterMapper;
using HotelManagementApp.Application.DTOs;


namespace HotelManagementApp.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request); 
            ErrorOr<AuthenticationResultDto> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => GlobalProblems(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResultDto> authResult = await _mediator.Send(query);
            if (authResult.IsError && authResult.FirstError == CommonErrors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => GlobalProblems(errors));
        }
    }
}

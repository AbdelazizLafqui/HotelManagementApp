using BubberDinner.Api.Controllers;
using ErrorOr;
using HotelManagementApp.Application.Authentication.Queries.Login;
using HotelManagementApp.Application.Authentication.Register.Commands;
using HotelManagementApp.Application.DTOs;
using HotelManagementApp.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApp.Api.Controllers
{
    [Route("[controller]")]
    public class RoomController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        //[HttpGet]
        //public async Task<IActionResult> Login()
        //{
        //    var query = _mapper.Map<LoginQuery>(request);
        //    ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        //    if (authResult.IsError && authResult.FirstError == CommonErrors.Authentication.InvalidCredentials)
        //    {
        //        return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        //    }

        //    return authResult.Match(
        //        authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
        //        errors => Problem(errors));
        //}

        //[HttpPost("login")]
        //public IActionResult Login()
        //{
        //    return Ok();
        //}
    }
}

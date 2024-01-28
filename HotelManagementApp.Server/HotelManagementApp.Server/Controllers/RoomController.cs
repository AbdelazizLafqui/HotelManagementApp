using BubberDinner.Api.Controllers;
using ErrorOr;
using HotelManagementApp.Application.Authentication.Queries.Login;
using HotelManagementApp.Application.Authentication.Register.Commands;
using HotelManagementApp.Application.DTOs;
using HotelManagementApp.Application.Room.Queries;
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

        public RoomController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet("rooms")]
        public async Task<ActionResult<List<RoomDto>>> GetRooms()
        {
            var query = new RoomSummaryQuery();
            var rooms = await _mediator.Send(query);

            return rooms;
        }
    }
}

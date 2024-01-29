using BubberDinner.Api.Controllers;
using ErrorOr;
using HotelManagementApp.Application.Authentication.Queries.Login;
using HotelManagementApp.Application.Authentication.Register.Commands;
using HotelManagementApp.Application.DTOs;
using HotelManagementApp.Application.Room.Commands.CreateRoom;
using HotelManagementApp.Application.Room.Commands.DeleteRoom;
using HotelManagementApp.Application.Room.Queries;
using HotelManagementApp.Application.Room.Queries.RoomSummary;
using HotelManagementApp.Contracts.Authentication;
using HotelManagementApp.Contracts.Room;
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


        [HttpGet("lookups")]
        public async Task<ActionResult<List<RoomLookupDto>>> GetRoomsLookup()
        {
            var query = new RoomLookupQuery();
            var lookups = await _mediator.Send(query);
            return lookups;
        }

        [HttpGet("rooms")]
        public async Task<ActionResult<List<RoomDto>>> GetRooms()
        {
            var query = new RoomSummaryQuery();
            var rooms = await _mediator.Send(query);
            return rooms;
        }

        [HttpPost("addRoom")]
        public async Task<IActionResult> AddRoomAsync(CreateRoomRequest request)
        {
            var command = _mapper.Map<CreateRoomCommand>(request);
            ErrorOr<RoomDto> result = await _mediator.Send(command);

            return result.Match(
                roomResult => Ok(_mapper.Map<RoomResponse>(roomResult)),
                errors => GlobalProblems(errors));
        }

        [HttpDelete("{roomId:guid}")]
        public async Task<IActionResult> DeleteRoomAsync(Guid roomId)
        {
            var command = new DeleteRoomCommand(roomId);

            var result = await _mediator.Send(command);

            return result.Match(
                _ => NoContent(),
                GlobalProblems);
        }


    }
}

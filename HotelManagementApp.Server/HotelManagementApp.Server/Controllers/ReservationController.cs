using BubberDinner.Api.Controllers;
using ErrorOr;
using HotelManagementApp.Application.DTOs;
using HotelManagementApp.Application.Reservation.Commands.CreateReservation;
using HotelManagementApp.Application.Reservation.Commands.DeleteReservation;
using HotelManagementApp.Application.Reservation.Queries;
using HotelManagementApp.Contracts.Reservation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApp.Api.Controllers
{
    [Route("[controller]")]
    public class ReservationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReservationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("reservations")]
        public async Task<ActionResult<List<ReservationDto>>> GetReservationsAsync()
        {
            var query = new ReservationSummaryQuery();
            var reservations = await _mediator.Send(query);
            return reservations;
        }

        [HttpPost("addReservation")]
        public async Task<IActionResult> AddReservationAsync(CreateReservationRequest request)
        {
            var command = _mapper.Map<CreateReservationCommand>(request);
            ErrorOr<ReservationDto> result = await _mediator.Send(command);

            return result.Match(
                resResult => Ok(_mapper.Map<ReservationDto>(resResult)),
                errors => GlobalProblems(errors));
        }

        [HttpDelete("{reservationId:guid}")]
        public async Task<IActionResult> DeleteReservationAsync(Guid reservationId)
        {
            var command = new DeleteReservationCommand(reservationId);

            var result = await _mediator.Send(command);

            return result.Match(
                _ => NoContent(),
                GlobalProblems);
        }
    }
}

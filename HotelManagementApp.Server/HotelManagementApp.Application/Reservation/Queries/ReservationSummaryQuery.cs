using HotelManagementApp.Application.DTOs;
using MediatR;

namespace HotelManagementApp.Application.Reservation.Queries
{
    public class ReservationSummaryQuery : IRequest<List<ReservationDto>>
    {
    }
}

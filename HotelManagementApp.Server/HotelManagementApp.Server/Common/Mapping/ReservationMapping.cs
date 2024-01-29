using HotelManagementApp.Application.Reservation.Commands.CreateReservation;
using HotelManagementApp.Contracts.Reservation;
using Mapster;

namespace HotelManagementApp.Api.Common.Mapping
{
    public class ReservationMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateReservationRequest, CreateReservationCommand>();

        }
    }
}

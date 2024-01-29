using ErrorOr;
using HotelManagementApp.Application.Common.Interfaces.Persistence;
using MediatR;

namespace HotelManagementApp.Application.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, ErrorOr<Success>>
    {
        private readonly IReservationRepository _reservationRepository;

        public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<ErrorOr<Success>> Handle(DeleteReservationCommand command, CancellationToken cancellationToken)
        {
            var reservation = _reservationRepository.GetByIdAsync(command.Id);

            if (reservation is null)
            {
                return Error.NotFound(description: "Reservation not found");
            }
            await _reservationRepository.DeleteReservationAsync(command.Id);

            return Result.Success;
        }
    }
}

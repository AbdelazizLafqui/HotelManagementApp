using FluentValidation;

namespace HotelManagementApp.Application.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(x => x.GuestName).NotEmpty();
            RuleFor(x => x.MobileNumber).NotEmpty();
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.CheckInDate).NotEmpty();
            RuleFor(x => x.CheckOutDate).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty();

        }
    }
}

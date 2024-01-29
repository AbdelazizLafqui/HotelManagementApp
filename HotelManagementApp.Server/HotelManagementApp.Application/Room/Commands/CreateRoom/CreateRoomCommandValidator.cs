using FluentValidation;

namespace HotelManagementApp.Application.Room.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.RoomNumber).NotEmpty();
            RuleFor(x => x.FloorNumber).NotEmpty();
            RuleFor(x => x.RoomType).NotEmpty();
            RuleFor(x => x.Bed).NotEmpty();
            RuleFor(x => x.Capacity).NotEmpty();
            RuleFor(x => x.Amenities).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();

        }
    }
}

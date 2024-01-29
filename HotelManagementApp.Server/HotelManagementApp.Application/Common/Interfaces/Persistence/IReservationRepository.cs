namespace HotelManagementApp.Application.Common.Interfaces.Persistence
{
    public interface IReservationRepository
    {
        Task<Domain.Entities.Reservation?> GetByIdAsync(Guid id);
        Task<List<Domain.Entities.Reservation>> GetReservationsAsync();
        Task AddReservationAsync(Domain.Entities.Reservation reservation);
        Task DeleteReservationAsync(Guid id);

    }
}

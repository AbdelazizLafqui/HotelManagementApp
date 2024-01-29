using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Domain.Entities;
using HotelManagementApp.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.Infrastructure.Reservations.Persistence
{
    public class ReservationRepository : IReservationRepository
    {

        private readonly HotelManagementDbContext _hotelManagementDbContext;

        public ReservationRepository(HotelManagementDbContext hotelManagementDbContext)
        {
            _hotelManagementDbContext = hotelManagementDbContext;
        }

        public async Task<Reservation?> GetByIdAsync(Guid id)
        {
            return await _hotelManagementDbContext.Reservations.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            _hotelManagementDbContext.Reservations.Add(reservation);
            await _hotelManagementDbContext.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _hotelManagementDbContext.Reservations.AsNoTracking().ToListAsync();
        }

        public async Task DeleteReservationAsync(Guid id)
        {
            var reservation = _hotelManagementDbContext.Reservations.Single(x => x.Id == id);
            _hotelManagementDbContext.Reservations.Remove(reservation);
            await _hotelManagementDbContext.SaveChangesAsync();
        }

    }
}

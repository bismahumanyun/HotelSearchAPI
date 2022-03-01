using HotelSearchAPI.Common.IRepository;
using HotelSearchAPI.Engine;
using System;
using System.Threading.Tasks;

namespace HotelSearchAPI.Common.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        
        private IGenericRepository<Hotel> _hotels;
        private IGenericRepository<Room> _rooms;
        private IGenericRepository<Booking> _bookings;
        private IGenericRepository<Payment> _payments;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);
        public IGenericRepository<Room> Rooms => _rooms ??= new GenericRepository<Room>(_context);
        public IGenericRepository<Booking> Bookings => _bookings ??= new GenericRepository<Booking>(_context);
        public IGenericRepository<Payment> Payments => _payments ??= new GenericRepository<Payment>(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using HotelSearchAPI.Engine;
using System;
using System.Threading.Tasks;

namespace HotelSearchAPI.Common.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepository<Hotel> Hotels { get; }
        IGenericRepository<Room> Rooms { get; }
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<Payment> Payments { get; }
        Task Save();
    }
}

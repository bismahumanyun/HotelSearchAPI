using HotelSearchAPI.Engine.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelSearchAPI.Engine
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {}           
 
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }         
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);             
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}

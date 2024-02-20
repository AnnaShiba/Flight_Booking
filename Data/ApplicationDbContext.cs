using COMP2139_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel {
                    HotelId = 1,
                    Name = "Villa Coco",
                    Amentities = "All-inclusive resort with outdoor pool and beach access",
                    Location = "Varadero",
                    Price = 299.99,
                    Reviews = 4.5
                },
                new Hotel {
                    HotelId = 2,
                    Name = "Hotel Varadero",
                    Amentities = "All-inclusive resort with beach access",
                    Location = "Varadero",
                    Price = 199.99,
                    Reviews = 3.7
                }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking {
                    BookingId = 1,
                    StartDate = new DateTime(2024, 05, 13),
                    EndDate = new DateTime(2024, 05, 27),
                    HotelId = 1
                },
                new Booking {
                    BookingId = 2,
                    StartDate = new DateTime(2024, 04, 13),
                    EndDate = new DateTime(2024, 04, 27),
                    HotelId = 2
                }
            );
        }
    }
}

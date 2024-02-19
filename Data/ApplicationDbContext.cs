using COMP2139_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}

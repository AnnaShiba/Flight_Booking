using COMP2139_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectsTasks { get; set; }
    }
}

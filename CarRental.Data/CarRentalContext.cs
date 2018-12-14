using CarRental.Domain;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CarRental.Data
{
    public class CarRentalContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}

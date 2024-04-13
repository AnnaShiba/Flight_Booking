using COMP2139_Assignment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<CarRental> CarRentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

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
                },
                new Hotel {
                    HotelId = 3,
                    Name = "Playa Azul",
                    Amentities = "All-inclusive resort with beach access",
                    Location = "Varadero",
                    Price = 229.99,
                    Reviews = 4.1
                },
                new Hotel {
                    HotelId = 4,
                    Name = "Hotel Cubana",
                    Amentities = "Island resort with bungalows",
                    Location = "Varadero",
                    Price = 249.49,
                    Reviews = 4.0
                },
                new Hotel {
                    HotelId = 5,
                    Name = "Hotel Excellent",
                    Amentities = "In historical part of the town",
                    Location = "Munich",
                    Price = 149.01,
                    Reviews = 4.1
                },
                new Hotel {
                    HotelId = 6,
                    Name = "Le Daufin",
                    Amentities = "Cute mountain hotel",
                    Location = "Munich",
                    Price = 180.01,
                    Reviews = 4.1
                },
                new Hotel {
                    HotelId = 7,
                    Name = "Kaiser Hotel",
                    Amentities = "Old luxury hotel in the heart of the city",
                    Location = "Munich",
                    Price = 499.00,
                    Reviews = 5.0
                },
                new Hotel {
                    HotelId = 8,
                    Name = "Sakura Tower",
                    Amentities = "Authentic Japanese hotel",
                    Location = "Tokyo",
                    Price = 179.01,
                    Reviews = 4.8
                },
                new Hotel {
                    HotelId = 9,
                    Name = "Shinjuku Hotel",
                    Amentities = "Authentic Japanese hotel",
                    Location = "Tokyo",
                    Price = 129.99,
                    Reviews = 3.6
                },
                new Hotel {
                    HotelId = 10,
                    Name = "Gojira Hotel",
                    Amentities = "Newly built modern hotel with gym and indoor pool",
                    Location = "Tokyo",
                    Price = 299.99,
                    Reviews = 4.5
                }
            );

            modelBuilder.Entity<Flight>().HasData(
                new Flight {
                    FlightId = 1,
                    Airline = "Air Canada",
                    Source = "Toronto",
                    Destination = "Varadero",
                    DepartureFrom = new DateTime(2024, 05, 13, 07, 10, 00),
                    DepartureTo = new DateTime(2024, 05, 13, 10, 10, 00),
                    ReturnFrom = new DateTime(2024, 05, 27, 07, 10, 00),
                    ReturnTo = new DateTime(2024, 05, 27, 10, 10, 00),
                    Price = 300
                },
                new Flight {
                    FlightId = 2,
                    Airline = "Air Canada",
                    Source = "Toronto",
                    Destination = "Varadero",
                    DepartureFrom = new DateTime(2024, 04, 13, 07, 10, 00),
                    DepartureTo = new DateTime(2024, 04, 13, 10, 10, 00),
                    ReturnFrom = new DateTime(2024, 04, 27, 07, 10, 00),
                    ReturnTo = new DateTime(2024, 04, 27, 10, 10, 00),
                    Price = 249
                },
                new Flight {
                    FlightId = 3,
                    Airline = "Nippon Airways",
                    Source = "Toronto",
                    Destination = "Tokyo",
                    DepartureFrom = new DateTime(2024, 04, 13, 07, 10, 00),
                    DepartureTo = new DateTime(2024, 04, 13, 10, 10, 00),
                    ReturnFrom = new DateTime(2024, 04, 27, 07, 10, 00),
                    ReturnTo = new DateTime(2024, 04, 27, 10, 10, 00),
                    Price = 1699
                },
                new Flight {
                    FlightId = 4,
                    Airline = "Lufthansa",
                    Source = "Toronto",
                    Destination = "Munich",
                    DepartureFrom = new DateTime(2024, 04, 13, 07, 10, 00),
                    DepartureTo = new DateTime(2024, 04, 13, 10, 10, 00),
                    ReturnFrom = new DateTime(2024, 04, 27, 07, 10, 00),
                    ReturnTo = new DateTime(2024, 04, 27, 10, 10, 00),
                    Price = 1070
                }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking {
                    BookingId = 1,
                    StartDate = new DateTime(2024, 05, 13),
                    EndDate = new DateTime(2024, 05, 27),
                    HotelId = 1,
                    FlightId = 1,
                    PersonCount = 1,
                    TotalPrice = 1099
                },
                new Booking {
                    BookingId = 2,
                    StartDate = new DateTime(2024, 04, 13),
                    EndDate = new DateTime(2024, 04, 27),
                    HotelId = 2,
                    FlightId = 2,
                    PersonCount = 1,
                    TotalPrice = 1249
                }
            );

            modelBuilder.Entity<CarRental>().HasData(
               new CarRental {
                   Id = 1,
                   Make = "Toyota",
                   Model = "Camry",
                   Year = 2020,
                   Color = "Blue",
                   PricePerDay = 50.00M,
                   IsAvailable = true,
                   AvailableFrom = DateTime.Today,
                   AvailableUntil = DateTime.Today.AddDays(30)
               },
                new CarRental {
                    Id = 2,
                    Make = "Ford",
                    Model = "Focus",
                    Year = 2019,
                    Color = "White",
                    PricePerDay = 45.00M,
                    IsAvailable = true,
                    AvailableFrom = DateTime.Today,
                    AvailableUntil = DateTime.Today.AddDays(30)
                },
                new CarRental {
                    Id = 3,
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2018,
                    Color = "Red",
                    PricePerDay = 40.00M,
                    IsAvailable = true,
                    AvailableFrom = new DateTime(2024, 01, 01),
                    AvailableUntil = new DateTime(2024, 01, 31)
                },
                new CarRental {
                    Id = 4,
                    Make = "Chevrolet",
                    Model = "Malibu",
                    Year = 2019,
                    Color = "Black",
                    PricePerDay = 55.00M,
                    IsAvailable = true,
                    AvailableFrom = new DateTime(2024, 02, 01),
                    AvailableUntil = new DateTime(2024, 02, 28)
                },
                new CarRental {
                    Id = 5,
                    Make = "Ford",
                    Model = "Mustang",
                    Year = 2020,
                    Color = "Yellow",
                    PricePerDay = 75.00M,
                    IsAvailable = true,
                    AvailableFrom = new DateTime(2024, 03, 01),
                    AvailableUntil = new DateTime(2024, 03, 31)
                },
                new CarRental {
                    Id = 6,
                    Make = "Tesla",
                    Model = "Model 3",
                    Year = 2021,
                    Color = "White",
                    PricePerDay = 85.00M,
                    IsAvailable = true,
                    AvailableFrom = new DateTime(2024, 04, 01),
                    AvailableUntil = new DateTime(2024, 04, 30)
                },
                new CarRental {
                    Id = 7,
                    Make = "BMW",
                    Model = "3 Series",
                    Year = 2019,
                    Color = "Blue",
                    PricePerDay = 90.00M,
                    IsAvailable = true,
                    AvailableFrom = new DateTime(2024, 05, 01),
                    AvailableUntil = new DateTime(2024, 05, 31)
                },
                new CarRental {
                    Id = 8,
                    Make = "Audi",
                    Model = "A4",
                    Year = 2020,
                    Color = "Grey",
                    PricePerDay = 95.00M,
                    IsAvailable = true,
                    AvailableFrom = new DateTime(2024, 06, 01),
                    AvailableUntil = new DateTime(2024, 06, 30)
                },
                new CarRental {
                    Id = 9,
                    Make = "Mercedes",
                    Model = "Benz C-Class",
                    Year = 2021,
                    Color = "Black",
                    PricePerDay = 100.00M,
                    IsAvailable = true,
                    AvailableFrom = new DateTime(2024, 07, 01),
                    AvailableUntil = new DateTime(2024, 07, 31)
                },
                new CarRental {
                    Id = 10,
                    Make = "Nissan",
                    Model = "Altima",
                    Year = 2018,
                    Color = "Silver",
                    PricePerDay = 50.00M,
                    IsAvailable = true,
                    AvailableFrom = new DateTime(2024, 08, 01),
                    AvailableUntil = new DateTime(2024, 08, 31)
                }
            );
        }
    }
}

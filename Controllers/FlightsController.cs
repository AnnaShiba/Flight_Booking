using COMP2139_Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Labs.Controllers {
    public class FlightsController : Controller {
        private ApplicationDbContext _database;

        // dependency injection
        public FlightsController(ApplicationDbContext applicationDbContext) {
            _database = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index() {
            var hotels = _database.Flights.ToList();
            return View(hotels);
        }

        [HttpGet("Flights/Search")]
        public async Task<IActionResult> Search(string destination, DateTime departureDate, DateTime returnDate, int? hotelId) {
            var query = _database.Flights.AsQueryable();

            if (!string.IsNullOrEmpty(destination)) {
                query = query.Where(f => f.Destination.Contains(destination));
            }

            var flights = await query.ToListAsync();
            ViewBag.Destination = destination;
            ViewBag.DepartureDate = departureDate.ToString("yyyy-MM-dd");
            ViewBag.ReturnDate = returnDate.ToString("yyyy-MM-dd");
            ViewBag.HotelId = hotelId;
            return View("Index", flights);
        }
    }
}

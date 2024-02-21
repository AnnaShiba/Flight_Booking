using COMP2139_Assignment.Data;
using COMP2139_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment.Controllers {
    public class BookingsController : Controller {
        private ApplicationDbContext _database;

        // dependency injection
        public BookingsController(ApplicationDbContext applicationDbContext) {
            _database = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index() {
            var bookings = _database.Bookings.ToList();
            return View(bookings);
        }
        [HttpGet]
        public IActionResult Details(int id) {
            var booking = _database.Bookings.Include(b => b.Hotel).Include(b => b.Flight).FirstOrDefault(b => b.BookingId == id);

            if (booking == null) {
                return NotFound();
            }

            return View(booking);
        }
        [HttpGet]
        public IActionResult Create(DateTime departureDate, DateTime returnDate, int? hotelId, int? flightId) {
            double totalPrice = 0;

            var hotel = _database.Hotels.Find(hotelId);
            var flight = _database.Flights.Find(flightId);
            if (flight == null && hotel == null) {
                return NotFound();
            }

            if (hotel != null) {
                totalPrice += hotel.Price;
            }
            if (flight != null) {
                totalPrice += flight.Price;
            }

            var booking = new Booking { HotelId = hotelId, FlightId = flightId, TotalPrice = totalPrice };
            ViewBag.Hotel = hotel;
            ViewBag.Flight = flight;
            ViewBag.DepartureDate = departureDate;
            ViewBag.ReturnDate = returnDate;
            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StartDate", "EndDate", "HotelId", "FlightId")] Booking booking) {
            if (ModelState.IsValid) {
                booking.TotalPrice = 0;

                _database.Bookings.Add(booking);
                _database.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = booking.BookingId });
            }
            return View(booking);
        }

        [HttpGet]
        public IActionResult Delete(int id) {

            var booking = _database.Bookings.Include(b => b.Hotel).FirstOrDefault(b => b.BookingId == id);

            if (booking == null) {
                return NotFound();
            }

            return View(booking);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int bookingId) {
            var booking = _database.Bookings.Find(bookingId);

            if (booking != null) {
                _database.Bookings.Remove(booking);
                _database.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}

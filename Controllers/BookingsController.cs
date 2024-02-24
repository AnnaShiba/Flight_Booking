﻿using COMP2139_Assignment.Data;
using COMP2139_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext _database;

        // dependency injection
        public BookingsController(ApplicationDbContext applicationDbContext)
        {
            _database = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var bookings = _database.Bookings.ToList();
            return View(bookings);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var booking = _database.Bookings
                .Include(b => b.Hotel)
                .Include(b => b.Flight)
                .Include(b => b.CarRental)
                .FirstOrDefault(b => b.BookingId == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpGet]
        public IActionResult Create(DateTime departureDate, DateTime returnDate, int? hotelId, int? flightId, int? carId)
        {
            double totalPrice = 0;

            var hotel = _database.Hotels.Find(hotelId);
            var flight = _database.Flights.Find(flightId);
            var car = _database.CarRentals.Find(carId);
            if (flight == null && hotel == null && car == null)
            {
                return NotFound();
            }

            totalPrice = calculateTotalPrice(departureDate, returnDate, hotel, flight, car);

            var booking = new Booking { HotelId = hotelId, FlightId = flightId, CarRentalId = carId, TotalPrice = totalPrice };
            ViewBag.Hotel = hotel;
            ViewBag.Flight = flight;
            ViewBag.CarRental = car;
            ViewBag.DepartureDate = departureDate;
            ViewBag.ReturnDate = returnDate;
            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StartDate", "EndDate", "HotelId", "FlightId", "CarRentalId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.TotalPrice = 0;

                var hotel = _database.Hotels.Find(booking.HotelId);
                var flight = _database.Flights.Find(booking.FlightId);
                var car = _database.CarRentals.Find(booking.CarRentalId);
                if (flight == null && hotel == null)
                {
                    return NotFound();
                }

                booking.TotalPrice = calculateTotalPrice(booking.StartDate, booking.EndDate, hotel, flight, car);


                _database.Bookings.Add(booking);
                _database.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = booking.BookingId });
            }
            return View(booking);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var booking = _database.Bookings.Include(b => b.Hotel).FirstOrDefault(b => b.BookingId == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int bookingId)
        {
            var booking = _database.Bookings.Find(bookingId);

            if (booking != null)
            {
                _database.Bookings.Remove(booking);
                _database.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        private double calculateTotalPrice(DateTime start, DateTime end, Hotel? hotel, Flight? flight, CarRental? car)
        {
            double totalPrice = 0;
            int duration = (int)(end - start).TotalDays;
            if (hotel != null)
            {
                totalPrice += duration * hotel.Price;
            }
            if (flight != null)
            {
                totalPrice += flight.Price;
            }
            if (car != null)
            {
                totalPrice += (double)car.PricePerDay * duration;
            }
            return totalPrice;
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _database.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            ViewData["HotelId"] = new SelectList(_database.Hotels, "HotelId", "Name", booking.HotelId);
            ViewData["FlightId"] = new SelectList(_database.Flights, "FlightId", "Airline", booking.FlightId);
            ViewData["CarRentalId"] = new SelectList(_database.CarRentals, "Id", "Model", booking.CarRentalId);
            return View(booking);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId", "StartDate", "EndDate", "HotelId", "FlightId", "CarRentalId", "TotalPrice")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _database.Update(booking);
                    await _database.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["HotelId"] = new SelectList(_database.Hotels, "HotelId", "Name", booking.HotelId);
            ViewData["FlightId"] = new SelectList(_database.Flights, "FlightId", "Airline", booking.FlightId);
            ViewData["CarRentalId"] = new SelectList(_database.CarRentals, "Id", "Model", booking.CarRentalId);
            return View(booking);
        }

        private bool BookingExists(int id)
        {
            return _database.Bookings.Any(e => e.BookingId == id);
        }


    }
}

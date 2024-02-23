using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment.Models;
using COMP2139_Assignment.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace COMP2139_Assignment.Controllers {
    public class HotelsController : Controller {
        private ApplicationDbContext _database;

        // dependency injection
        public HotelsController(ApplicationDbContext applicationDbContext) {
            _database = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index() {
            var hotels = _database.Hotels.ToList();
            return View(hotels);
        }
        [HttpGet]
        public IActionResult Details(int id) {
            var hotel = _database.Hotels.Where(p => p.HotelId == id).Single();
            return View(hotel);
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hotel hotel) {
            if (ModelState.IsValid) {
                _database.Hotels.Add(hotel);
                _database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }
        [HttpGet]
        public IActionResult Edit(int id) {

            var project = _database.Hotels.Where(p => p.HotelId == id);
            if (project.IsNullOrEmpty()) {
                return NotFound();
            }
            return View(project.Single());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Hotel hotel) {
            if (ModelState.IsValid) {
                var dbHotel = _database.Hotels.Where(p => p.HotelId == hotel.HotelId).Single();
                dbHotel.Name = hotel.Name;
                dbHotel.Amentities = hotel.Amentities;
                _database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        [HttpGet]
        public IActionResult Delete(int id) {

            var hotel = _database.Hotels.Where(p => p.HotelId == id);
            if (hotel.IsNullOrEmpty()) {
                return NotFound();
            }
            return View(hotel.Single());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Hotel hotel) {
            _database.Hotels.Where(p => p.HotelId == hotel.HotelId).ExecuteDelete();
            return RedirectToAction("Index");
        }

        
        [HttpGet("Hotels/Search")]
        public async Task<IActionResult> Search(string destination, DateTime departureDate, DateTime returnDate, string sort) {
            var query = _database.Hotels.AsQueryable();

            if (!string.IsNullOrEmpty(destination)) {
                query = query.Where(h => h.Location.Contains(destination));
            }

            switch (sort) {
                case "Name":
                    query = query.OrderBy(h => h.Name);
                    break;
                case "Reviews":
                    query = query.OrderBy(h => h.Reviews);
                    break;
                case "Price":
                    query = query.OrderBy(h => h.Price);
                    break;
                default:
                    break;
            }

            var hotels = await query.ToListAsync();
            ViewBag.Destination = destination;
            ViewBag.DepartureDate = departureDate.ToString("yyyy-MM-dd");
            ViewBag.ReturnDate = returnDate.ToString("yyyy-MM-dd");
            return View("Index", hotels);
        }
    }
}

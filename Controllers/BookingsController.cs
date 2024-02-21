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
        public IActionResult Index(int id) {
            var tasks = _database.Bookings.Where(t => t.BookingId == id).ToList();
            ViewBag.ProjectId = id;
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Details(int id) {
            var task = _database.Bookings.Include(t => t.Hotel).FirstOrDefault(t => t.BookingId == id);

            if (task == null) {
                return NotFound();
            }

            return View(task);
        }
        [HttpGet]
        public IActionResult Create(int id) {
            var project = _database.Hotels.Find(id);
            if (project == null) {
                return NotFound();
            }

            var task = new Booking { BookingId = id };
            ViewBag.Hotels = _database.Hotels.OrderBy(h => h.Price).ToList();
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title", "Amentities", "HotelId")] Booking task) {
            if (ModelState.IsValid) {
                _database.Bookings.Add(task);
                _database.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = task.BookingId });
            }
            ViewBag.Hotels = _database.Hotels.OrderBy(h => h.Price).ToList();
            return View(task);
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            var task = _database.Bookings.Include(t => t.Hotel).FirstOrDefault(t => t.BookingId == id);

            if (task == null) {
                return NotFound();
            }

            ViewBag.Hotels = new SelectList(_database.Hotels, "HotelId", "Name", task.HotelId);
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BookingId", "Title", "Amentities", "HotelId")] Booking task) {
            if (id != task.BookingId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                _database.Update(task);
                _database.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = task.BookingId });
            }

            ViewBag.Hotels = new SelectList(_database.Hotels, "HotelId", "Name", task.HotelId);
            return View(task);
        }

        [HttpGet]
        public IActionResult Delete(int id) {

            var task = _database.Bookings.Include(t => t.Hotel).FirstOrDefault(t => t.BookingId == id);

            if (task == null) {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ProjectTaskId) {
            var task = _database.Bookings.Find(ProjectTaskId);

            if (task != null) {
                _database.Bookings.Remove(task);
                _database.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = task.BookingId });
            }

            return NotFound();
        }
    }
}

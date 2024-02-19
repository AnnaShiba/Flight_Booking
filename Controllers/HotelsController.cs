using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment.Models;
using COMP2139_Assignment.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment.Controllers {
    public class HotelsController : Controller {
        private ApplicationDbContext _database;

        // dependency injection
        public HotelsController(ApplicationDbContext applicationDbContext) {
            _database = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index() {
            var projects = _database.Hotels.ToList();
            return View(projects);
        }
        [HttpGet]
        public IActionResult Details(int id) {
            var project = _database.Hotels.Where(p => p.HotelId == id).Single();
            return View(project);
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hotel project) {
            if (ModelState.IsValid) {
                _database.Hotels.Add(project);
                _database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
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
        public IActionResult Edit(Hotel project) {
            if (ModelState.IsValid) {
                var dbProject = _database.Hotels.Where(p => p.HotelId == project.HotelId).Single();
                dbProject.Name = project.Name;
                dbProject.Amentities = project.Amentities;
                _database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [HttpGet]
        public IActionResult Delete(int id) {

            var project = _database.Hotels.Where(p => p.HotelId == id);
            if (project.IsNullOrEmpty()) {
                return NotFound();
            }
            return View(project.Single());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Hotel project) {
            _database.Hotels.Where(p => p.HotelId == project.HotelId).ExecuteDelete();
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment.Models;
using COMP2139_Assignment.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment.Controllers {
    public class ProjectsController : Controller {
        private ApplicationDbContext _database;

        // dependency injection
        public ProjectsController(ApplicationDbContext applicationDbContext) {
            _database = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index() {
            var projects = _database.Projects.ToList();
            return View(projects);
        }
        [HttpGet]
        public IActionResult Details(int id) {
            var project = _database.Projects.Where(p => p.ProjectId == id).Single();
            return View(project);
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project) {
            if (ModelState.IsValid) {
                _database.Projects.Add(project);
                _database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }
        [HttpGet]
        public IActionResult Edit(int id) {

            var project = _database.Projects.Where(p => p.ProjectId == id);
            if (project.IsNullOrEmpty()) {
                return NotFound();
            }
            return View(project.Single());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project project) {
            if (ModelState.IsValid) {
                var dbProject = _database.Projects.Where(p => p.ProjectId == project.ProjectId).Single();
                dbProject.Name = project.Name;
                dbProject.Description = project.Description;
                _database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [HttpGet]
        public IActionResult Delete(int id) {

            var project = _database.Projects.Where(p => p.ProjectId == id);
            if (project.IsNullOrEmpty()) {
                return NotFound();
            }
            return View(project.Single());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Project project) {
            _database.Projects.Where(p => p.ProjectId == project.ProjectId).ExecuteDelete();
            return RedirectToAction("Index");
        }
    }
}

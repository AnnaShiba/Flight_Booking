using COMP2139_Assignment.Data;
using COMP2139_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace COMP2139_Assignment.Controllers {
    public class TasksController : Controller {
        private ApplicationDbContext _database;

        // dependency injection
        public TasksController(ApplicationDbContext applicationDbContext) {
            _database = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index(int id) {
            var tasks = _database.ProjectsTasks.Where(t => t.ProjectId == id).ToList();
            ViewBag.ProjectId = id;
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Details(int id) {
            var task = _database.ProjectsTasks.Include(t => t.Project).FirstOrDefault(t => t.ProjectTaskId == id);

            if (task == null) {
                return NotFound();
            }

            return View(task);
        }
        [HttpGet]
        public IActionResult Create(int id) {
            var project = _database.Projects.Find(id);
            if (project == null) {
                return NotFound();
            }

            var task = new ProjectTask { ProjectId = id };
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title", "Description", "ProjectId")] ProjectTask task) {
            if (ModelState.IsValid) {
                _database.ProjectsTasks.Add(task);
                _database.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = task.ProjectId });
            }
            return View(task);
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            var task = _database.ProjectsTasks.Include(t => t.Project).FirstOrDefault(t => t.ProjectTaskId == id);

            if (task == null) {
                return NotFound();
            }

            ViewBag.Projects = new SelectList(_database.Projects, "ProjectId", "Name", task.ProjectId);
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProjectTaskId", "Title", "Description", "ProjectId")] ProjectTask task) {
            if (id != task.ProjectTaskId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                _database.Update(task);
                _database.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = task.ProjectId });
            }

            ViewBag.Projects = new SelectList(_database.Projects, "ProjectId", "Name", task.ProjectId);
            return View(task);
        }

        [HttpGet]
        public IActionResult Delete(int id) {

            var task = _database.ProjectsTasks.Include(t => t.Project).FirstOrDefault(t => t.ProjectTaskId == id);

            if (task == null) {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ProjectTaskId) {
            var task = _database.ProjectsTasks.Find(ProjectTaskId);

            if (task != null) {
                _database.ProjectsTasks.Remove(task);
                _database.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = task.ProjectId });
            }

            return NotFound();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2139_Assignment.Data;
using COMP2139_Assignment.Models;




namespace COMP2139_Assignment.Controllers
{
    public class CarRentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarRentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CarRentals.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = await _context.CarRentals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carRental == null)
            {
                return NotFound();
            }

            return View(carRental);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,Year,Color,PricePerDay,IsAvailable,AvailableFrom,AvailableUntil")] CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carRental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carRental);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = await _context.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }
            return View(carRental);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Year,Color,PricePerDay,IsAvailable,AvailableFrom,AvailableUntil")] CarRental carRental)
        {
            if (id != carRental.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carRental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarRentalExists(carRental.Id))
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
            return View(carRental);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = await _context.CarRentals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carRental == null)
            {
                return NotFound();
            }

            return View(carRental);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carRental = await _context.CarRentals.FindAsync(id);
            _context.CarRentals.Remove(carRental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarRentalExists(int id)
        {
            return _context.CarRentals.Any(e => e.Id == id);
        }
        [HttpGet("CarRentals/Search")]
        public async Task<IActionResult> Search(DateTime departureDate, DateTime returnDate, decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.CarRentals.AsQueryable();

            // Filter by availability dates
            query = query.Where(c => c.AvailableFrom <= departureDate && c.AvailableUntil >= returnDate);

            //  filters for price per day if they are provided
            if (minPrice.HasValue)
            {
                query = query.Where(c => c.PricePerDay >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(c => c.PricePerDay <= maxPrice.Value);
            }

            var cars = await query.ToListAsync();
            ViewBag.DepartureDate = departureDate.ToString("yyyy-MM-dd");
            ViewBag.ReturnDate = returnDate.ToString("yyyy-MM-dd");
            //  search parameters to use in the view
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            return View("Index", cars);
        }
    }
}

using CabManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CabManagementSystem.Areas.Admin.Controllers
{
    
       
        [Area("Admin")]
        [Authorize(Roles = "Admin")]
        public class HomeController : Controller
        {
            private readonly ApplicationDbContext _db;

            public HomeController(ApplicationDbContext db)
            {
                _db = db;
            }
       

            public IActionResult Index()
            {
                return View(_db.BookDrivers.ToList());
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

        [HttpPost]
        public async Task<IActionResult> Create(BookDriverViewModel model)
            {
                if (!ModelState.IsValid)
                    return View(model);

                _db.BookDrivers.Add(new BookDriver()
                {
                    Vehicles = model.Vehicles,
                    DriverName = model.DriverName,
                    CabNumber=model.CabNumber,
                    Languages = model.Languages,
                    Charge=model.Charge,
                    Contact=model.Contact,  
                    Summary = model.Summary,
                });
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            [HttpGet]
            public async Task<IActionResult> Edit(int Id)
            {
                var model = await _db.BookDrivers.FindAsync( Id);
                if (model == null)
                    return NotFound();

                return View(new BookDriverViewModel()
                {
                    Vehicles = model.Vehicles,
                    DriverName = model.DriverName,
                    CabNumber = model.CabNumber,
                    Languages = model.Languages,
                   Charge = model.Charge,
                    Contact = model.Contact,
                    Summary = model.Summary
                });
        }
        [HttpPost]
            public async Task<IActionResult> Edit(int id, BookDriverViewModel model)
            {
                var movie = await _db.BookDrivers.FindAsync(id);
                if (movie == null)
                    return NotFound();

                if (!ModelState.IsValid)
                    return View(model);


                movie.Vehicles = model.Vehicles;
                movie.DriverName = model.DriverName;
                movie.Languages = model.Languages;
                movie.CabNumber=model.CabNumber;
            movie.Charge=model.Charge;
                movie.Contact=model.Contact; 
                movie.Summary = model.Summary;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Delete(int id, BookDriverViewModel model)
            {
                var movie = await _db.BookDrivers.FindAsync(id);
                if (movie == null)
                    return NotFound();

                _db.BookDrivers.Remove(movie);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }



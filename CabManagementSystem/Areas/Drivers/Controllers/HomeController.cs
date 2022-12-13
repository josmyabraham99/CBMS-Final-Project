using CabManagementSystem.Models;
using CabManagementSystem.Models.ViewModels;

namespace CabManagementSystem.Areas.Drivers.Controllers
{
    [Area("Drivers")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        
        public IActionResult Index()
        {
            return View(db.BookDrivers.ToList());
        }

        [HttpGet]
        public IActionResult DriverRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DriverRegister(DriverViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var driver = new Driver()
            {

                Number = model.Number,
                Liscense = model.Liscense,
                Contact = model.Contact
                
            };

            db.Drivers.Add(driver);
            await db.SaveChangesAsync();
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
        }

            [HttpGet]
            public IActionResult DriverTable()
            {
                return View(db.BookDrivers.ToList());
            }

            [HttpPost]
            public async Task<IActionResult> DriverTable(BookDriverViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var movie = new
                {
                    Vehicles = model.Vehicles,
                    DriverName = model.DriverName,
                    Languages = model.Languages,
                   
                    Contact = model.Contact,
                    Summary = model.Summary

                };
                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Home", new { Area = "" });
            }
        }
    }

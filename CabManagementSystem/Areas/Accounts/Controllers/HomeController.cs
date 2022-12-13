using Microsoft.AspNetCore.Identity;

namespace CabManagementSystem.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole>roleManager)
 
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid details");
                return View(model);
            }

            var res = await signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (res.Succeeded)
            {
                if(await userManager.IsInRoleAsync(user, "Admin")) 
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else if(await userManager.IsInRoleAsync(user, "Cab_Driver"))
                {
                       return RedirectToAction("DriverRegister", "Home", new { Area = "Drivers" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { Area = "" });
                }
               
                //return Redirect(nameof(Index));
            }
            

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
          //  return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> GenerateData()
        {
          
            await roleManager.CreateAsync(new IdentityRole() { Name = "Cab_Customer" });
            await roleManager.CreateAsync(new IdentityRole() { Name = "Cab_Driver" });

            return Ok("Data generated");
        }

        //public async Task<IActionResult> GenerateData()
        //{
        //    //await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" };
        //    //await _roleManager.CreateAsync(new IdentityRole() { Name = "User" });



        //    var users = await userManager.GetUsersInRoleAsync("Admin");
        //    if (users.Count == 0)
        //    {
        //        var appUser = new ApplicationUser()
        //        {
        //            FirstName = "Admin",
        //            LastName = "User",
        //            Email = "admin@admin.com",
        //          UserName = "admin",
        //        };
        //        var res = await userManager.CreateAsync(appUser, "Pass@123");
        //        await userManager.AddToRoleAsync(appUser, "Admin");
        //    }
        //    return Ok("Data generated");
        //}


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

           
                if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
               
                UserName = Guid.NewGuid().ToString().Replace("-", "")
            };
            var role = Convert.ToString(model.UserType);
            var res = await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, role);

            if  (res.Succeeded)
            {
               
                return RedirectToAction(nameof(Login));
            }

            foreach (var item in res.Errors)

            {
                ModelState.AddModelError("", item.Description);

            }

            return View(model);


        }
        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookViewModel model)
        {
            if (model.PickUp == model.DropDown)
            {
                ModelState.AddModelError(nameof(model.DropDown),"Incorrect Location");
            }
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           db.Book.Add(new Book()
           {PickUp = model.PickUp,
           DropDown=model.DropDown,
           Vehicle=model.Vehicle,
           Date = model.Date
           });
            await db.SaveChangesAsync();

            return RedirectToAction("BookDriver", "Home", new { Area = "Accounts" });
        }
        [HttpGet]
        public IActionResult BookDriver()
        {
            return View(db.BookDrivers.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> BookDriver(BookDriverViewModel model)
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

            return RedirectToAction("Payment", "Home", new {Area="Accounts"});

        }
       
        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Payment(BookDriverViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           

            return RedirectToAction("Index", "Home", new { Area = "" });
        }
        [HttpGet]
        public IActionResult CustomerTable()
        {
            return View(db.ApplicationUsers.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> CustomerTable(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var movie = new
            {
                CustomerName = model.FirstName,
                Email = model.Email,
              LastName=model.LastName

                

            };
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Home", new { Area = "" });
        }
        public async Task<IActionResult> Delete(string id, BookDriverViewModel model)
        {
            var Movie = await db.ApplicationUsers.FindAsync(id);
            if (Movie == null)
                return NotFound();

            db.ApplicationUsers.Remove(Movie);
            await db.SaveChangesAsync();
            return RedirectToAction("CustomerTable", "Home", new { Area = "Accounts" });
        }
        public IActionResult BookingHistory()
        {
            return View(db.Book.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> BookingHistory(BookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var movie = new
            {
                PickUp = model.PickUp,
                DropDown = model.DropDown,
                Vehicle = model.Vehicle,
                Date = model.Date



            };
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Home", new { Area = "" });
        }
       
            //[HttpPost]


            //public async Task<IActionResult> BookViews(BookViewModel model)
            //    {

            //        var Book = new Schedule
            //        {

            //            Date = model.Date,

            //            UserName = Guid.NewGuid().ToString().Replace("-", "")
            //        };
            //    if (Book.Succeeded)
            //    {
            //        return RedirectToAction("Index", "Home", new { Area = "" });
            //        //return Redirect(nameof(Index));
            //    }


           //    return View(model);

            
            public async Task<IActionResult> Generate()

            {   //await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            //await roleManager.CreateAsync(new IdentityRole() { Name = "Cab_Customer" });
            //await roleManager.CreateAsync(new IdentityRole() { Name = "Cab_Driver" });

            await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });

            var users = await userManager.GetUsersInRoleAsync("Admin");
            if (users.Count == 0)
            {
                var appUser = new ApplicationUser()
                {
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@admin.com",
                    UserName = "admin",
                };
                var res = await userManager.CreateAsync(appUser, "Pass@123");
                await userManager.AddToRoleAsync(appUser, "Admin");
            }
            return Ok("Data generated");
        }


    }
    }



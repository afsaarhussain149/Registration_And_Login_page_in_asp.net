using DBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace DBFirst.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly TeacherDbContext context;

        public HomeController(TeacherDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.teachers.ToList();
            return View(result);
        }

        public IActionResult Login()
        {

            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("In");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(Teacher user)
        {
            var myUser = context.teachers.Where(x => x.email == user.email && x.password == user.password).FirstOrDefault();
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.email);
                return RedirectToAction("In");
            }
            else 
            {
                ViewBag.Message = "Login Failed..";
            }
            return View();
        }
        public IActionResult In()
        {

            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            var result = context.teachers.ToList();
            return View(result);

        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(Teacher user)
        {
            if (ModelState.IsValid) 
            {
                await context.teachers.AddAsync(user);
                await context.SaveChangesAsync();
                TempData["Success"] = "Registered Successfully";
                return RedirectToAction("Login");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

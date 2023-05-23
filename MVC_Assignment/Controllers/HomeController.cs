using Microsoft.AspNetCore.Mvc;
using MVC_Assignment.Context;
using MVC_Assignment.Models;
using System.Diagnostics;

namespace MVC_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TrainingDbContext db;

        
        public HomeController(ILogger<HomeController> logger, TrainingDbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string useremail,string password)
        {
            User obj = db.Users.FirstOrDefault(x => x.UserEmail.Equals(useremail) && x.Password.Equals(password));

            if(obj != null)
            {
                Role role = obj.UserRole;
                if((int)role == 0)//admin
                {
                    return RedirectToAction("Login","User");
                }
                else if((int)role == 1)//manager
                {
                    return RedirectToAction("Index", "Request");
                }
                else//employee
                {
                    return RedirectToAction("Index","employee");
                }

            }

            return View();
        }
        
    }
}
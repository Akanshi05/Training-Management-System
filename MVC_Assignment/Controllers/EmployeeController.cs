using Microsoft.AspNetCore.Mvc;
using MVC_Assignment.Context;
using MVC_Assignment.Models;

namespace MVC_Assignment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly TrainingDbContext db;

        public EmployeeController(TrainingDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            List<Request> list = db.Requests.ToList();
            return View(list);
        }
    }
}

using BizLandTask.DAL;
using BizLandTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace BizLandTask.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context { get; }

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }
    }
}

using BizLandTask.DAL;
using BizLandTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace BizLandTask.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class EmployeeController : Controller
    {

        AppDbContext _context { get; }

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }


        public IActionResult Create()
		{
            return View();
		}
		[HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)return View();
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
		{
            if (id is null) return BadRequest();
            Employee employee = _context.Employees.Find(id);
            if (employee is null) return NotFound();
            return View(employee);
		}

		[HttpPost]
        public IActionResult Update(int? id,Employee employee)
        {
            if (!ModelState.IsValid) return View();
            if (id is null || id != employee.Id) return BadRequest();
            Employee exist = _context.Employees.Find(id);
            if(employee is null) return NotFound();
            exist.Name = employee.Name;
            exist.Surname = employee.Surname;
            exist.ImageUrl = employee.ImageUrl;
            exist.Position = employee.Position;
            exist.Description = employee.Description;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
		{
			Employee employee = _context.Employees.Find(id);
            if (employee is null) return NotFound();
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

		}
	}
}

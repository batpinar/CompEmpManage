using CompanyEmployeeManagement.Web.Context;
using CompanyEmployeeManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployeeManagement.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> obj = _dbContext.Employees;
            return View(obj);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            var emp = _dbContext.Companies.Single(i => i.Id == obj.CompanyId);


            if (emp.Id != obj.CompanyId )
            {
                ModelState.AddModelError("CompanyId", "The Company Id cannot exactly match the EmployeeCompanyId .");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}

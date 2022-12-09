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
            IEnumerable<Employee> objEmployeeList = _dbContext.Employees;
            return View(objEmployeeList);
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
            if (obj.IdentityNumber == obj.CompanyId.ToString())
            {
                ModelState.AddModelError("name", "The CompanyId cannot exactly match the IdentityNumber.");
            }

            _dbContext.Employees.Add(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Employee created successfully";
            return RedirectToAction("Index");

        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeeFromDb = _dbContext.Employees.Find(id);


            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if (obj.IdentityNumber == obj.CompanyId.ToString())
            {
                ModelState.AddModelError("name", "The CompanyId cannot exactly match the IdentityNumber.");
            }

            _dbContext.Employees.Update(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Employee updated successfully";
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeeFromDb = _dbContext.Employees.Find(id);

            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _dbContext.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.Employees.Remove(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Employee deleted successfully";
            return RedirectToAction("Index");

        }
    }
}

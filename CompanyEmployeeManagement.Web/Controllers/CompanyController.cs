using CompanyEmployeeManagement.Web.Context;
using CompanyEmployeeManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployeeManagement.Web.Controllers;

public class CompanyController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public CompanyController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        IEnumerable<Company> objCompanyList = _dbContext.Companies;
        return View(objCompanyList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Company obj)
    {
        if (obj.CompanyName == obj.TaxOffice.ToString())
        {
            ModelState.AddModelError("name", "The TaxOffice cannot exactly match the CompanyName.");
        }
        
            _dbContext.Companies.Add(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Company created successfully";
            return RedirectToAction("Index");

    }
    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var companyFromDb = _dbContext.Companies.Find(id);


        if (companyFromDb == null)
        {
            return NotFound();
        }

        return View(companyFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Company obj)
    {
        if (obj.CompanyName == obj.TaxOffice.ToString())
        {
            ModelState.AddModelError("name", "The TaxOffice cannot exactly match the CompanyName.");
        }
        
            _dbContext.Companies.Update(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Company updated successfully";
            return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var companyFromDb = _dbContext.Companies.Find(id);

        if (companyFromDb == null)
        {
            return NotFound();
        }

        return View(companyFromDb);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _dbContext.Companies.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _dbContext.Companies.Remove(obj);
        _dbContext.SaveChanges();
        TempData["success"] = "Company deleted successfully";
        return RedirectToAction("Index");

    }
}

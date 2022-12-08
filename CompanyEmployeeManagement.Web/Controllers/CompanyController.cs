

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
        IEnumerable<Company> obj = _dbContext.Companies;
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
    public IActionResult Create(Company obj)
    {
        //if (obj.CompanyName == obj.TaxOffice.ToString())
        //{
        //    ModelState.AddModelError("CompanyName", "The Company Name cannot exactly match the TaxOffice Name.");
        //}
        if (ModelState.IsValid)
        {
            _dbContext.Companies.Add(obj);
            _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
        return View(obj);
    }


    //GET
    //public IActionResult Edit(int? id)
    //{

    //    if (id == null )
    //    {
    //        return NotFound();
    //    }
    //    var companyFormDb = _dbContext.Companies.Find(id);
    //    if (companyFormDb == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(companyFormDb);
    //}

    ////POST
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public IActionResult Edit(Company obj)
    //{
    //    if (obj.CompanyName == obj.TaxOffice.ToString())
    //    {
    //        ModelState.AddModelError("CompanyName", "The Company Name cannot exactly match the TaxOffice Name.");
    //    }
    //    if (ModelState.IsValid)
    //    {
    //        _dbContext.Companies.Add(obj);
    //        _dbContext.SaveChanges();
    //        return RedirectToAction("Index");
    //    }
    //    return View(obj);
    //}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using website.Models;
using website.Data;

public class MedicineController : Controller
{
    private readonly WebsiteDbContext _context;
    public MedicineController(WebsiteDbContext context)
    {
        _context = context;
    }
    public IActionResult Index(bool ispopup=false)
    {
        this.ViewBag.ispopup = ispopup;
        return View(_context.Medicines.ToList());
    }
    public IActionResult Create(int? Id)
    {
        return View(_context.Medicines.Find(Id));
    }
    [HttpPost]
    public IActionResult Create(Medicine medicine,int? Id)
    {
        if (Id == null)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        else
        {
            if (ModelState.IsValid){
                _context.Update(medicine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        return View(medicine);
    }
    public IActionResult Delete(int? Id) 
    {
        Medicine medi = _context.Medicines.Find(Id);
        if (Id == null)
        {
            return NotFound();
        }
        else
        {
            _context.Medicines.Remove(medi);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    public IActionResult Detail(int? Id)
    {
        if (Id == null)
        {
            return NotFound();
        }
        var data = _context.Medicines.Find(Id);
        ViewBag.Admin=_context.Admins.Find(data.Admin_Id).Username;
        if (data == null)
        {
            return NotFound();
        }
        return View(data);
    }
}



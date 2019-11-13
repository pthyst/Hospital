using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using website.Data;
using website.Models;

namespace website.Controllers
{
    public class MedicineController : Controller
    {
        private readonly WebsiteDbContext _context;
        public MedicineController(WebsiteDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Medicines.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicine);
        }
    }
}
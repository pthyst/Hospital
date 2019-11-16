using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using website.Data;
using website.ViewModels;
using website.Helper;
using Microsoft.AspNetCore.Authorization;

namespace website.Controllers
{
    //[Authorize]
    public class DoctorController : Controller
    {
        private readonly WebsiteDbContext _context;
        public DoctorController(WebsiteDbContext context)
        {
            _context = context;
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
        [AllowAnonymous]
        public IActionResult Login(DoctorLoginViewModel model)
        {
            var dr = _context.Doctors.SingleOrDefault(p => p.Username == model.Username && p.Password == model.Password);
            if (dr != null)
            {
                HttpContext.Session.Set("doctor", dr);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
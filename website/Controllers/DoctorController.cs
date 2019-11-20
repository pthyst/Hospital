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
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using website.Models;

namespace website.Controllers
{

    public class DoctorController : Controller
    {
        private readonly WebsiteDbContext _context;
        public DoctorController(WebsiteDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchstring)
        {
            
            if (!string.IsNullOrEmpty(searchstring))
            {
                var medicine = _context.Medicines.AsQueryable();
                medicine = medicine.Where(s => s.Name.Contains(searchstring));
                return View(medicine.ToList());
            }
            return View(_context.Medicines);
        }
        
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(DoctorLoginViewModel model)
        {
            var dr = _context.Doctors.Where(p => p.Username == model.Username && p.Password == model.Password).FirstOrDefault();
            if (dr != null)
            {
                HttpContext.Session.Set("doctor", dr);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dr.NameFirst),
                    new Claim(ClaimTypes.Role, "doctor")
                };

                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Doctor");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("doctor");
            await HttpContext.SignOutAsync();
            return View("Login");
        }

    }
}
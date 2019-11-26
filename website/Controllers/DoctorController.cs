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
    //[Authorize]
    public class DoctorController : Controller
    {
        private readonly WebsiteDbContext _context;
        public DoctorController(WebsiteDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(/*string searchstring*/)
        {

            //if (!string.IsNullOrEmpty(searchstring))
            //{
            //    var medicine = _context.Medicines.AsQueryable();
            //    medicine = medicine.Where(s => s.Name.Contains(searchstring));
            //    return View(medicine.ToList());
            //}
            return View(_context.Medicines);
        }
        [HttpPost]
        public IActionResult search([FromBody]string searchstring)
        {
            var medicine = _context.Medicines.AsQueryable();
            if (!string.IsNullOrEmpty(searchstring))
            {
                
                medicine = medicine.Where(s => s.Name.Contains(searchstring));
                return Ok(medicine.ToList());
            }
            return Ok(medicine.ToList()) ;
        }

        //public IActionResult Getmedic()
        //{

        //    return new JsonResult();
        //}
        [HttpPost]
        public IActionResult waitingline([FromBody]int stt)
        {
            DateTime datenow = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime hournow = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
            //var dr = HttpContext.Session.Get<Doctor>("doctor");
            var shiftplan = _context.ShiftPlans.Where(r => r.Doctor_Id == 4 && DateTime.Parse(r.DateStart.ToString("yyyy-MM-dd")) <= datenow && DateTime.Parse(r.DateEnd.ToString("yyyy-MM-dd")) >= datenow);
            var shiftPl=new ShiftPlan();
            foreach (var sp in shiftplan)
            {
                var shift = _context.Shifts.Where(s => s.Id == sp.Shift_Id).FirstOrDefault();
                if(shift.TimeStart<=hournow && shift.TimeEnd >= hournow)
                {
                    shiftPl = sp;
                }
            }
            var waitinginroom = _context.WaitingLines.Where(s => s.Room_Id == shiftPl.Room_Id);
            var waitingpa = waitinginroom.Where(p => p.Number == stt + 1).FirstOrDefault();
            var pa = _context.Patients.Where(p => p.Id == waitingpa.Patient_Id).FirstOrDefault();
            return Ok(pa);
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
            return View("Login");
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("doctor");
            await HttpContext.SignOutAsync();
            return View("Login");
        }

    }
}
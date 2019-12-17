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
using Microsoft.AspNetCore.Http;

namespace website.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly WebsiteDbContext _context;
        public DoctorController(WebsiteDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Medicines);
        }
        [HttpPost]
        public IActionResult search(string searchstring)
        {
            List<Medicine> me = new List<Medicine>();
            var per = new PercriptionViewModel();
            if (!string.IsNullOrEmpty(searchstring))
            {
                me = _context.Medicines.Where(s => s.Name.Contains(searchstring)).ToList();
                foreach (var item in me)
                {
                    per.medicine.Add(item);
                }
                return PartialView("Doctor/_MedicinePartialView", per);
            }
            
            return PartialView("Doctor/_MedicinePartialView", per) ;
        }
        [HttpPost]
        public IActionResult SearchAPI(string searchstring)
        {

            var medicine = new { };
            List<Medicine> me = new List<Medicine>();
            var per = new PercriptionViewModel();
            if (!string.IsNullOrEmpty(searchstring))
            {
                me = _context.Medicines.Where(s => s.Name.Contains(searchstring)).ToList();
                foreach (var item in me)
                {
                    per.medicine.Add(item);
                }
            }

            return Ok(per.medicine);

        }
        [HttpPost]
        public IActionResult addmedic(int id)
        {
            var medicine = _context.Medicines.Where(m => m.Id == id).FirstOrDefault();
            return Ok(Json(medicine));
        }
        [HttpPost]
        public IActionResult SavePerscription(PercriptionViewModel per) {
            DateTime now = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (ModelState.IsValid && per.perscription.Patient_Id!=0)
            {
                per.perscription.DateCreate = now;
                per.perscription.DateModify = now;
                _context.Add(per.perscription);
                _context.SaveChanges();
            }
            var p = _context.Perscriptions.Where(x => x.DateCreate == now).FirstOrDefault();
            foreach(var item in per.perscriptionmedicinedetails)
            {
                var perr = new PerscriptionDetail();
                perr.Medicine_Id = item.id;
                perr.Morning = item.sang;
                perr.Noon = item.trua;
                perr.Evening = item.toi;
                perr.Days = item.ngay;
                perr.Quantity = (perr.Morning + perr.Noon + perr.Evening) * perr.Days;
                perr.Perscription_Id = p.Id;
                _context.Add(perr);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult waitingline([FromBody]int stt)
        {
            var per = new PercriptionViewModel();
            DateTime datenow = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime hournow = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
            var dr = HttpContext.Session.Get<Doctor>("doctor");
            var shiftplan = _context.ShiftPlans.Where(r => r.Doctor_Id == dr.Id && DateTime.Parse(r.DateStart.ToString("yyyy-MM-dd")) <= datenow && DateTime.Parse(r.DateEnd.ToString("yyyy-MM-dd")) >= datenow);
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
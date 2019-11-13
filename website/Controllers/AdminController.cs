using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using website.Models;
using website.Data;
using website.ViewModels;

namespace website.Controllers
{
    public class AdminController : Controller
    {
        private WebsiteDbContext _context;

        public AdminController(WebsiteDbContext context)
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

        #region Nhóm trang nhân viên
        // Bác sĩ
        public IActionResult Doctors()
        {
            AdminDoctorsViewModel viewmodel = new AdminDoctorsViewModel()
            {
                Doctors = _context.Doctors.ToList(),
                Faculties = _context.Faculties.ToList()
            };
            return View(viewmodel);
        }

        public IActionResult DoctorNew()
        {
            AdminDoctorNewViewModel viewmodel = new AdminDoctorNewViewModel()
            {
                Doctor = new Doctor(),
                Faculties = _context.Faculties.ToList()
            };
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult DoctorCreate(AdminDoctorNewViewModel viewmodel)
        {
            Doctor newdoctor = viewmodel.Doctor;
            newdoctor.Role_Id = 2;
            _context.Doctors.Add(newdoctor);
            _context.SaveChanges();


        [HttpPost]
         public IActionResult AdminDetail(Admin model)
        {
           if (ModelState.IsValid)
           {
               Admin up = _context.Admins.Where(ad => ad.Id == model.Id).FirstOrDefault();

               up.NameLast    = model.NameLast;
               up.NameMiddle  = model.NameMiddle;
               up.NameFirst   = model.NameFirst;
               up.Email       = model.Email;
               up.PhoneNumber = model.PhoneNumber;
               
               _context.SaveChanges();
               return RedirectToAction("Admins","Admin");
           }
           else
           {
               return View(model);
           }
        }

        [HttpGet]
        public IActionResult AdminDelete(int id)
        {
            Admin delete = _context.Admins.Where(ad => ad.Id == id).FirstOrDefault();
            if (delete != null)
            {
                _context.Remove(delete);
                _context.SaveChanges();
               
            }   
            return RedirectToAction("Admins","Admin");
        }
        #endregion
        #endregion

        #region Nhóm Action cho Phòng/Khoa
        #region Khoa
        public IActionResult Faculties()
        {
            AdminFacultiesViewModel viewmodel = new AdminFacultiesViewModel()
            {
                Faculty = new Faculty(),
                Faculties = _context.Faculties.ToList(),
                Doctors = _context.Doctors.ToList()
            };
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Faculties(AdminFacultiesViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Faculties.Add(viewmodel.Faculty);
                _context.SaveChanges();
                return RedirectToAction("Faculties","Admin");
            }
            else
            {
                return View(
                    new AdminFacultiesViewModel()
                    {
                        Faculty = viewmodel.Faculty,
                        Faculties = _context.Faculties.ToList(),
                        Doctors = _context.Doctors.ToList()
                    }
                );
            }
        }

        [HttpGet]
        public IActionResult Faculties(int id)
        {
            Faculty detail = _context.Faculties.Where(fa => fa.Id == id).FirstOrDefault();
            if (detail != null)
            {
                AdminFacultiesViewModel viewmodel = new AdminFacultiesViewModel()
                {
                    Faculty = detail,
                    Faculties = _context.Faculties.ToList(),
                    Doctors = _context.Doctors.ToList()
                };
                return View(viewmodel);
            }
            else
            {
                return RedirectToAction("Faculties","Admin",1);
            }

        }

        public IActionResult Pharmacists()
        {


            if (ModelState.IsValid)
            {
                Faculty up = _context.Faculties.Where(fa => fa.Id == viewmodel.Faculty.Id).FirstOrDefault();
                up.Name = viewmodel.Faculty.Name;
                up.Fee = viewmodel.Faculty.Fee;
                _context.SaveChanges();
                return RedirectToAction("Faculties","Admin");
            }
            else
            {
                return View(viewmodel);
            }
        }
        public IActionResult Administrators()
        {
            return View();
        }
        #endregion

        public IActionResult Logout()
        {
            return RedirectToAction("Admin","Login");
        }
    }
}
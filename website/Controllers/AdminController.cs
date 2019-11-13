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
using website.Models;

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

        public IActionResult Logout()
        {
            return RedirectToAction("Admin","Login");
        }

        #region Nhóm nhân viên
            #region Bác sĩ
            public IActionResult Doctors()
            {
                AdminDoctorsViewModel vm = new AdminDoctorsViewModel()
                {
                    Doctors = _context.Doctors.OrderByDescending(d => d.Id).ToList(),
                    Faculties = _context.Faculties.ToList()
                };
                return View(vm);
            }
            public IActionResult DoctorNew()
            {
                AdminDoctorNewViewModel vm = new AdminDoctorNewViewModel()
                {
                    Doctor = new Doctor(),
                    Faculties = _context.Faculties.ToList()
                };
                return View(vm);
            }

            [HttpPost]
            public IActionResult DoctorNew(AdminDoctorNewViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    vm.Doctor.Role_Id = 2; // Bác sĩ có Role_Id cố định là 2
                    _context.Doctors.Add(vm.Doctor);
                    _context.SaveChanges();
                    return RedirectToAction("Doctors","Admin");
                }
                return View(vm);
            }

            [HttpGet]
            public IActionResult DoctorEdit(int id)
            {
                Doctor edit = _context.Doctors.Where(d => d.Id == id).FirstOrDefault();
                if (edit != null)
                {
                    AdminDoctorEditViewModel vm = new AdminDoctorEditViewModel()
                    {
                        Doctor = edit,
                        Doctors = _context.Doctors.OrderByDescending(d => d.Id).ToList(),
                        Faculties = _context.Faculties.ToList()
                    };
                    return View(vm);
                }                
                return RedirectToAction("Doctors","Admin");
            }

            [HttpPost]
            public IActionResult DoctorEdit(AdminDoctorEditViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    Doctor data = vm.Doctor;
                    Doctor up = _context.Doctors.Where(d => d.Id == data.Id).FirstOrDefault();

                    up.NameFirst   = data.NameFirst;
                    up.NameMiddle  = data.NameMiddle;
                    up.NameLast    = data.NameLast;
                    up.Faculty_Id  = data.Faculty_Id;
                    up.Password    = data.Password;
                    up.Email       = data.Email;
                    up.PhoneNumber = data.PhoneNumber;
                
                    _context.SaveChanges();
                }
                return View(
                    new AdminDoctorEditViewModel()
                    {
                        Doctor = vm.Doctor,
                        Doctors = _context.Doctors.OrderByDescending(d => d.Id).ToList(),
                        Faculties = _context.Faculties.ToList()
                    }
                );
            }

            [HttpGet]
            public IActionResult DoctorDelete(int id)
            {
                Doctor delete = _context.Doctors.Where(d => d.Id == id).FirstOrDefault();
                if (delete != null)
                {
                    _context.Doctors.Remove(delete);
                    _context.SaveChanges();
                }
                return RedirectToAction("Doctors","Admin");
            }
            #endregion

        #endregion

        #region Nhóm Phòng/Khoa

        #endregion

    }
}
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
                    Doctors   = _context.Doctors.OrderByDescending(d => d.Id).ToList(),
                    Faculties = _context.Faculties.ToList()
                };
                return View(vm);
            }
            public IActionResult DoctorNew()
            {
                AdminDoctorNewViewModel vm = new AdminDoctorNewViewModel()
                {
                    Doctor    = new Doctor(),
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
                        Doctor    = edit,
                        Doctors   = _context.Doctors.OrderByDescending(d => d.Id).ToList(),
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
                    Doctor data    = vm.Doctor;
                    Doctor up      = _context.Doctors.Where(d => d.Id == data.Id).FirstOrDefault();

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
                        Doctor     = vm.Doctor,
                        Doctors    = _context.Doctors.OrderByDescending(d => d.Id).ToList(),
                        Faculties  = _context.Faculties.ToList()
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
            #region Dược sĩ
            public IActionResult Pharas()
            {
                AdminPharasViewModel vm = new AdminPharasViewModel()
                {
                    Pharas = _context.Pharamacists.ToList()
                };
                return View(vm);
            }
            
            public IActionResult PharaNew()
            {
                return View(new Pharamacist());
            }

            [HttpPost]
            public IActionResult PharaNew(Pharamacist m)
            {
                if (ModelState.IsValid)
                {
                    m.Role_Id = 3; // Dược sĩ có Role_Id cố định là 3
                    _context.Pharamacists.Add(m);
                    _context.SaveChanges();
                    return RedirectToAction("Pharas","Admin");
                }
                return View(m);
            }

            [HttpGet]
            public IActionResult PharaEdit(int id)
            {
                Pharamacist edit = _context.Pharamacists.Where(p => p.Id == id).FirstOrDefault();
                if (edit != null)
                {
                    AdminPharaEditViewModel vm = new AdminPharaEditViewModel()
                    {
                        Phara  = edit,
                        Pharas = _context.Pharamacists.OrderByDescending(p => p.Id).ToList()
                    };
                    return View(vm);
                }                
                return RedirectToAction("Pharas","Admin");
            }

            [HttpPost]
            public IActionResult PharaEdit(AdminPharaEditViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    Pharamacist data = vm.Phara;
                    Pharamacist up   = _context.Pharamacists.Where(p=> p.Id == data.Id).FirstOrDefault();

                    up.NameFirst     = data.NameFirst;
                    up.NameMiddle    = data.NameMiddle;
                    up.NameLast      = data.NameLast;
                    up.Password      = data.Password;
                    up.Email         = data.Email;
                    up.PhoneNumber   = data.PhoneNumber;
                
                    _context.SaveChanges();
                }
                return View(
                    new AdminPharaEditViewModel()
                    {
                        Phara     = vm.Phara,
                        Pharas    = _context.Pharamacists.OrderByDescending(p => p.Id).ToList()
                    }
                );
            }

            [HttpGet]
            public IActionResult PharaDelete(int id)
            {
                Pharamacist delete = _context.Pharamacists.Where(p => p.Id == id).FirstOrDefault();
                if (delete != null)
                {
                    _context.Pharamacists.Remove(delete);
                    _context.SaveChanges();
                }
                return RedirectToAction("Pharas","Admin");
            }
            #endregion

            #region Quản trị viên
            public IActionResult Admins()
            {   
                AdminAdminsViewModel vm = new AdminAdminsViewModel()
                {
                    Admins = _context.Admins.OrderByDescending(a => a.NameLast).ToList()
                };
                return View(vm);
            }

            public IActionResult AdminNew()
            {
                return View(new Admin());
            }

            [HttpPost]
            public IActionResult AdminNew(Admin m)
            {
                if (ModelState.IsValid)
                {
                    m.Role_Id = 4; // Role_Id của quản trị viên cố định là 4
                    _context.Admins.Add(m);
                    _context.SaveChanges();
                    return RedirectToAction("Admins","Admin");
                }
                else
                {
                    return View(m);
                }
            }

            [HttpGet]
            public IActionResult AdminEdit(int id)
            {
                Admin edit = _context.Admins.Where(a => a.Id == id).FirstOrDefault();
                if (edit != null)
                {
                    AdminAdminEditViewModel vm = new AdminAdminEditViewModel()
                    {
                        Admin  = edit,
                        Admins = _context.Admins.OrderByDescending(a => a.NameLast).ToList()
                    };
                    return View(vm);
                }
                else
                {
                    return RedirectToAction("Admins","Admin");
                }

            }

            [HttpPost]
            public IActionResult AdminEdit(AdminAdminEditViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    Admin data       = vm.Admin;
                    Admin up         = _context.Admins.Where(a => a.Id == data.Id).FirstOrDefault();

                    up.NameFirst     = data.NameFirst;
                    up.NameMiddle    = data.NameMiddle;
                    up.NameLast      = data.NameLast;
                    up.Password      = data.Password;
                    up.Email         = data.Email;
                    up.PhoneNumber   = data.PhoneNumber;

                    _context.SaveChanges();
                    return RedirectToAction("Admins","Admin");
                }
                else
                {
                    return View(
                        new AdminAdminEditViewModel()
                        {
                            Admin = vm.Admin,
                            Admins = _context.Admins.OrderByDescending(a => a.NameLast).ToList()
                        }
                    );
                }
            }

            [HttpGet]
            public IActionResult AdminDelete(int id)
            {
                Admin delete = _context.Admins.Where(a => a.Id == id).FirstOrDefault();
                if (delete != null)
                {
                    _context.Admins.Remove(delete);
                    _context.SaveChanges();
                }
                return RedirectToAction("Admins","Admin");
            }
            #endregion


        #endregion

        #region Nhóm Phòng/Khoa

        #endregion

    }
}
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
                    Faculties = _context.Faculties.OrderBy(f => f.Name).ToList()
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
                return View(
                    new AdminDoctorNewViewModel()
                    {
                        Doctor = vm.Doctor,
                        Faculties = _context.Faculties.OrderBy(f => f.Name).ToList()
                    }
                );
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
            #region Khoa
            public IActionResult Faculties()
            {
                AdminFacultiesViewModel vm = new AdminFacultiesViewModel()
                {
                    Faculty   = new Faculty(),
                    Faculties = _context.Faculties.OrderBy(f => f.Name).ToList(),
                    Doctors   = _context.Doctors.ToList() 
                };
                return View(vm);
            }

            [HttpPost]
            public IActionResult Faculties(AdminFacultiesViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    _context.Faculties.Add(vm.Faculty);
                    _context.SaveChanges();
                    return RedirectToAction("Faculties","Admin");
                }
                else
                {
                    return View(
                        new AdminFacultiesViewModel()
                        {
                            Faculty   = vm.Faculty,
                            Faculties = _context.Faculties.OrderBy(f => f.Name).ToList(),
                            Doctors   = _context.Doctors.ToList() 
                        }
                    );
                }
            }

            [HttpGet]
            public IActionResult FacultyEdit(int id)
            {
                Faculty edit = _context.Faculties.Where(f => f.Id == id).FirstOrDefault();
                if (edit != null)
                {
                    AdminFacultiesViewModel vm = new AdminFacultiesViewModel()
                    {
                        Faculty = edit,
                        Faculties = _context.Faculties.OrderBy(f => f.Name).ToList(),
                        Doctors   = _context.Doctors.ToList() 
                    };
                    return View(vm);
                }
                else
                {
                    return RedirectToAction("Faculties","Admin");
                }
            }

            [HttpPost]
            public IActionResult FacultyEdit(AdminFacultiesViewModel vm) 
            {
                if (ModelState.IsValid)
                {
                    Faculty data = vm.Faculty;
                    Faculty up   = _context.Faculties.Where(f => f.Id == data.Id).FirstOrDefault();

                    up.Name      = data.Name;
                    up.Fee       = data.Fee;

                    _context.SaveChanges();
                }
                return View(
                    new AdminFacultiesViewModel()
                    {
                        Faculty   = vm.Faculty,
                        Faculties = _context.Faculties.OrderBy(f => f.Name).ToList(),
                        Doctors   = _context.Doctors.ToList() 
                    }
                );
            }

            [HttpGet]
            public IActionResult FacultyDelete(int id)
            {
                Faculty delete = _context.Faculties.Where(f => f.Id == id).FirstOrDefault();
                if (delete != null)
                {
                    _context.Faculties.Remove(delete);
                    _context.SaveChanges();
                }
                return RedirectToAction("Faculties","Admin");
            }
            #endregion
            #region Phòng
            public IActionResult Rooms()
            {
                AdminRoomsViewModel vm = new AdminRoomsViewModel()
                {
                    Room   = new Room(),
                    Faculties = _context.Faculties.OrderBy(f => f.Name).ToList(),
                    Rooms   = _context.Rooms.OrderBy(r => r.ShortCode).ToList() 
                };
                return View(vm);
            }

            [HttpPost]
            public IActionResult Rooms(AdminRoomsViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    _context.Rooms.Add(vm.Room);
                    _context.SaveChanges();
                    return RedirectToAction("Rooms","Admin");
                }
                else
                {
                    return View(
                        new AdminRoomsViewModel()
                        {
                            Room   = vm.Room,
                            Faculties = _context.Faculties.OrderBy(f => f.Name).ToList(),
                            Rooms   = _context.Rooms.OrderBy(r => r.ShortCode).ToList() 
                        }
                    );
                }
            }

            [HttpGet]
            public IActionResult RoomEdit(int id)
            {
                Room edit = _context.Rooms.Where(f => f.Id == id).FirstOrDefault();
                if (edit != null)
                {
                    AdminRoomsViewModel vm = new AdminRoomsViewModel()
                    {
                        Room = edit,
                        Faculties = _context.Faculties.OrderBy(f => f.Name).ToList(),
                        Rooms   = _context.Rooms.OrderBy(r => r.ShortCode).ToList() 
                    };
                    return View(vm);
                }
                else
                {
                    return RedirectToAction("Rooms","Admin");
                }
            }

            [HttpPost]
            public IActionResult RoomEdit(AdminRoomsViewModel vm) 
            {
                if (ModelState.IsValid)
                {
                    Room data     = vm.Room;
                    Room up       = _context.Rooms.Where(f => f.Id == data.Id).FirstOrDefault();

                    up.Name       = data.Name;
                    up.ShortCode  = data.ShortCode;
                    up.Faculty_Id = data.Faculty_Id;

                    _context.SaveChanges();
                }
                return View(
                    new AdminRoomsViewModel()
                    {
                        Room   = vm.Room,
                        Faculties = _context.Faculties.OrderBy(f => f.Name).ToList(),
                        Rooms   = _context.Rooms.OrderBy(r => r.ShortCode).ToList() 
                    }
                );
            }

            [HttpGet]
            public IActionResult RoomDelete(int id)
            {
                Room delete = _context.Rooms.Where(f => f.Id == id).FirstOrDefault();
                if (delete != null)
                {
                    _context.Rooms.Remove(delete);
                    _context.SaveChanges();
                }
                return RedirectToAction("Rooms","Admin");
            }
            #endregion
        #endregion
        #region Nhóm thuốc
            #region Thuốc
            public IActionResult Medicines()
            {
                AdminMedicinesViewModel vm = new AdminMedicinesViewModel()
                {
                    Medicines     = _context.Medicines.OrderBy(m => m.Name).ToList(),
                    MedicineUnits = _context.MedicineUnits.ToList()
                };
                return View(vm);
            }

            public IActionResult MedicineNew()
            {
                AdminMedicineNewViewModel vm = new AdminMedicineNewViewModel()
                {
                    Medicine      = new Medicine(),
                    MedicineUnits = _context.MedicineUnits.OrderBy(u => u.Unit).ToList()
                };
                return View(vm);
            }

            [HttpPost]
            public IActionResult MedicineNew(AdminMedicineNewViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    string rename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + Path.GetExtension(vm.Thumbnail.FileName);
                    
                    if (vm.Thumbnail != null)
                    {            
                        string newpath    = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads", rename); // Trỏ đường dẫn đến thư mục wwwroot/uploads/file mới
                        vm.Thumbnail.CopyTo(new FileStream(newpath,FileMode.Create)); // Copy hình từ nguồn sang wwwroot/uploads/file mới
                        vm.Medicine.Thumbnail = rename;
                    }

                    _context.Medicines.Add(vm.Medicine);
                    _context.SaveChanges();
                    return RedirectToAction("Medicines","Admin");
                }
                else
                {
                    return View(
                        new AdminMedicineNewViewModel()
                        {
                            Medicine      = vm.Medicine,
                            MedicineUnits = _context.MedicineUnits.OrderBy(u => u.Unit).ToList()
                        }
                    );
                }
            }

            [HttpGet]
            public IActionResult MedicineEdit(int id)
            {
                Medicine edit = _context.Medicines.Where(m => m.Id == id).FirstOrDefault();
                if (edit != null)
                {
                    AdminMedicineEditViewModel vm = new AdminMedicineEditViewModel()
                    {
                        Medicine      = edit,
                        MedicineUnits = _context.MedicineUnits.OrderBy(u => u.Unit).ToList(),
                        Medicines     = _context.Medicines.OrderBy(m => m.Name).ToList()
                    };
                    return View(vm);
                }
                else
                {
                    return RedirectToAction("Medicines","Admin");
                }
            }

            [HttpPost]
            public IActionResult MedicineEdit(AdminMedicineEditViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    Medicine data      = vm.Medicine;
                    Medicine up        = _context.Medicines.Where(m => m.Id == data.Id).FirstOrDefault();

                    up.Name            = data.Name;
                    up.Price           = data.Price;
                    up.Instore         = data.Instore;
                    up.Thumbnail       = data.Thumbnail;
                    up.MedicineUnit_Id = data.MedicineUnit_Id; 

                    _context.SaveChanges();
                }
                return View(
                    new AdminMedicineEditViewModel()
                    {
                        Medicine      = vm.Medicine,
                        Medicines     = _context.Medicines.OrderBy(m => m.Name).ToList(),
                        MedicineUnits = _context.MedicineUnits.OrderBy(u => u.Unit).ToList()
                    }
                );
            }

            [HttpGet]
            public IActionResult MedicineDelete(int id)
            {
                Medicine delete = _context.Medicines.Where(m => m.Id == id).FirstOrDefault();
                if (delete != null)
                {
                    // Xóa hình ảnh đại diện trong thư mục wwwroot/uploads
                    string path_delete = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads",delete.Thumbnail);
                    // Phải sử dụng System.IO thì mới xài được File

                    if (System.IO.File.Exists(path_delete))
                    {
                        System.IO.File.Delete(path_delete);
                    }
                    _context.Medicines.Remove(delete);
                    _context.SaveChanges();
                }
                return RedirectToAction("Medicines","Admin");
            }
            #endregion
        #endregion
    }
}
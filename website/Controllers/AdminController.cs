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
                    up.MedicineUnit_Id = data.MedicineUnit_Id; 

                    if (vm.Thumbnail != null)
                    {
                        // Xóa ảnh cũ
                        string old_image = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads",vm.Medicine.Thumbnail);
                        if (System.IO.File.Exists(old_image))
                        {
                            System.IO.File.Delete(old_image);
                        }
                
                        // Lưu ảnh mới
                        string rename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + Path.GetExtension(vm.Thumbnail.FileName);
                        string new_image = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads", rename);
                        vm.Thumbnail.CopyTo(new FileStream(new_image,FileMode.Create));
                        up.Thumbnail = rename;

                    }

                    _context.SaveChanges();
                    return View(
                        new AdminMedicineEditViewModel()
                        {
                            Medicine      = _context.Medicines.Where(m => m.Id == vm.Medicine.Id).FirstOrDefault(),
                            Medicines     = _context.Medicines.OrderBy(m => m.Name).ToList(),
                            MedicineUnits = _context.MedicineUnits.OrderBy(u => u.Unit).ToList()
                        }
                    );
                }
                else
                {
                    return View(
                        new AdminMedicineEditViewModel()
                        {
                            Medicine      = vm.Medicine,
                            Medicines     = _context.Medicines.OrderBy(m => m.Name).ToList(),
                            MedicineUnits = _context.MedicineUnits.OrderBy(u => u.Unit).ToList()
                        }
                    );
                }
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
            #region Đơn vị thuốc
            public IActionResult MedicineUnits()
            {
                AdminMedicineUnitsViewModel vm = new AdminMedicineUnitsViewModel()
                {
                    MedicineUnits = _context.MedicineUnits.ToList(),
                    MedicineUnit = new MedicineUnit()
                };
                return View(vm);
            }
            
            [HttpPost]
            public IActionResult MedicineUnits(AdminMedicineUnitsViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    _context.MedicineUnits.Add(vm.MedicineUnit);
                    _context.SaveChanges();
                }
                
                return View(
                    new AdminMedicineUnitsViewModel()
                    {
                        MedicineUnits = _context.MedicineUnits.OrderBy(m => m.Unit).ToList(),
                        MedicineUnit = new MedicineUnit()
                    }
                );
                
            }

            [HttpGet]
            public IActionResult MedicineUnitEdit(int id)
            {
                MedicineUnit edit = _context.MedicineUnits.Where(m => m.Id == id).FirstOrDefault();

                if (edit != null)
                {
                    AdminMedicineUnitsViewModel vm = new AdminMedicineUnitsViewModel()
                    {
                        MedicineUnit  = edit,
                        MedicineUnits = _context.MedicineUnits.OrderBy(m => m.Unit).ToList()
                    };
                    return View(vm);
                }
                else
                {
                    return RedirectToAction("MedicineUnits","Admin");
                }
            }

            [HttpPost]
            public IActionResult MedicineUnitEdit(AdminMedicineUnitsViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    MedicineUnit data = vm.MedicineUnit;
                    MedicineUnit up   = _context.MedicineUnits.Where(m => m.Id == vm.MedicineUnit.Id).FirstOrDefault();

                    up.Unit = data.Unit;
                    _context.SaveChanges();

            
                }
                return View(
                    new AdminMedicineUnitsViewModel()
                    {
                        MedicineUnit  = vm.MedicineUnit,
                        MedicineUnits  = _context.MedicineUnits.OrderBy(m => m.Unit).ToList()
                    }
                );
            }

            [HttpGet]
            public IActionResult MedicineUnitDelete(int id)
            {
                MedicineUnit delete = _context.MedicineUnits.Where(m => m.Id == id).FirstOrDefault();

                if (delete != null)
                {
                    _context.MedicineUnits.Remove(delete);
                    _context.SaveChanges();
                }

                return RedirectToAction("MedicineUnits","Admin");
            }
            #endregion
        #endregion
        #region Nhóm bệnh nhân
            #region Bệnh nhân
            public IActionResult Patients()
            {
                AdminPatientsViewModel vm = new AdminPatientsViewModel()
                {
                    Patients = _context.Patients.OrderBy(p => p.NameLast).ThenBy(p => p.NameMiddle).ThenBy(p => p.NameFirst).ToList()
                };
                return View(vm);
            }

            public IActionResult PatientNew()
            {
                AdminPatientNewViewModel vm = new AdminPatientNewViewModel()
                {
                    Patient = new Patient(),
                    InsuranceTypes = _context.InsuranceTypes.OrderBy(i => i.Type).ToList()
                };
                return View(vm);
            }

            [HttpPost]
            public IActionResult PatientNew(AdminPatientNewViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    Patient data = vm.Patient;

                    // Tạo thẻ bhyt mới nếu có đăng kí bhyt
                    if (vm.InsuranceType_Id != 0)
                    {
                        Insurance nin = new Insurance()
                        {
                            NameFirst           = data.NameFirst,
                            NameMiddle          = data.NameMiddle,
                            NameLast            = data.NameLast,
                            DateBirth           = data.DateBirth,
                            Gender              = data.Gender,
                            AddressApartment    = data.AddressApartment,
                            AddressStreet       = data.AddressStreet,
                            AddressDistrict     = data.AddressDistrict,
                            AddressCity         = data.AddressCity,
                            PhoneNumberPersonal = data.PhoneNumber,
                            PhoneNumberHome     = data.PhoneNumber,
                            InsuranceType_Id    = vm.InsuranceType_Id
                        };
                        _context.Insurances.Add(nin);
                        _context.SaveChanges();

                        // Lấy Id của cái bhyt vừa mới tạo
                        Insurance oin = _context.Insurances.Where(i => 
                            i.NameFirst == data.NameFirst && i.NameMiddle == data.NameMiddle && i.NameLast == data.NameLast
                            && i.DateBirth == data.DateBirth && i.Gender == data.Gender 
                        ).FirstOrDefault();
                        data.Insurance_Id = oin.Id;
                    }
                    else
                    {
                        data.Insurance_Id = 0;
                    }

                    // Lưu thông tin bệnh nhân
                    data.Role_Id = 1; // Bệnh nhân có Role_Id mặc định là 1
                    _context.Patients.Add(data);
                    _context.SaveChanges();
                    return RedirectToAction("Patients","Admin");
                }
                else
                {
                    return View(
                        new AdminPatientNewViewModel()
                        {
                            Patient = vm.Patient,
                            InsuranceTypes = _context.InsuranceTypes.OrderBy(i => i.Type).ToList()
                        }
                    );
                }
            }

            [HttpGet]
            public IActionResult PatientEdit(int id)
            {
                Patient edit = _context.Patients.Where(p => p.Id == id).FirstOrDefault();
                if (edit != null)
                {
                    AdminPatientEditViewModel vm = new AdminPatientEditViewModel()
                    {
                        Patient  = edit,
                        Patients = _context.Patients.OrderBy(p => p.NameLast).ThenBy(p => p.NameMiddle).ThenBy(p => p.NameFirst).ToList()
                    };
                    return View(vm);
                }
                else
                {
                    return RedirectToAction("Patients","Admin");
                }
            }

            [HttpPost]
            public IActionResult PatientEdit(AdminPatientEditViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    Patient data = vm.Patient;
                    Patient up   = _context.Patients.Where(p => p.Id == data.Id).FirstOrDefault();

                    up.NameFirst           = data.NameFirst;
                    up.NameMiddle          = data.NameMiddle;
                    up.NameLast            = data.NameLast;
                    up.DateBirth           = data.DateBirth;
                    up.Gender              = data.Gender;
                    up.AddressApartment    = data.AddressApartment;
                    up.AddressStreet       = data.AddressStreet;
                    up.AddressDistrict     = data.AddressDistrict;
                    up.AddressCity         = data.AddressCity;
                    up.PhoneNumber         = data.PhoneNumber;
                    up.Weight              = data.Weight;
                    up.Height              = data.Height;
                    up.Blood_Type          = data.Blood_Type;
                    up.Rh                  = data.Rh;
                    up.BMP                 = data.BMP;

                    _context.SaveChanges();

                    // Thay đổi thông tin trên thẻ bhyt
                    if (data.Insurance_Id != 0)
                    {
                        Insurance uin = _context.Insurances.Where(i => i.Id == data.Insurance_Id).FirstOrDefault();
                        if (uin != null)
                        {
                            uin.NameFirst           = data.NameFirst;
                            uin.NameMiddle          = data.NameMiddle;
                            uin.NameLast            = data.NameLast;
                            uin.DateBirth           = data.DateBirth;
                            uin.Gender              = data.Gender;
                            uin.AddressApartment    = data.AddressApartment;
                            uin.AddressStreet       = data.AddressStreet;
                            uin.AddressDistrict     = data.AddressDistrict;
                            uin.AddressCity         = data.AddressCity;
                            uin.PhoneNumberPersonal = data.PhoneNumber;
                            uin.PhoneNumberHome     = data.PhoneNumber;
                            _context.SaveChanges();
                        }
                    }
                } 
                return View(
                    new AdminPatientEditViewModel()
                    {
                        Patient  = vm.Patient,
                        Patients = _context.Patients.OrderBy(p => p.NameLast).ThenBy(p => p.NameMiddle).ThenBy(p => p.NameFirst).ToList()
                    }
                ); 
            }

            [HttpGet]
            public IActionResult PatientDelete(int id)
            {
                Patient delete = _context.Patients.Where(p => p.Id == id).FirstOrDefault();

                if (delete != null)
                {
                    // Xóa thẻ bhyt kèm theo
                    if (delete.Insurance_Id != 0)
                    {
                        Insurance delin = _context.Insurances.Where(i => i.Id == delete.Insurance_Id).FirstOrDefault();
                        if (delin != null)
                        {
                            _context.Insurances.Remove(delin);
                            _context.SaveChanges();
                        }
                    }

                    _context.Patients.Remove(delete);
                    _context.SaveChanges();
                }

                return RedirectToAction("Patients","Admin");
            }
            #endregion
            #region BHYT
            public IActionResult Insurances()
            {   
                AdminInsurancesViewModel vm = new AdminInsurancesViewModel()
                {
                    Insurances     = _context.Insurances.OrderByDescending(i => i.Id).ToList(),
                    InsuranceTypes = _context.InsuranceTypes.ToList()
                };
                return View(vm);
            }

            [HttpGet]
            public IActionResult InsuranceEdit(int id)
            {
                Insurance edit = _context.Insurances.Where(i => i.Id == id).FirstOrDefault();
                if (edit != null)
                {
                    AdminInsuranceEditViewModel vm = new AdminInsuranceEditViewModel()
                    {
                        Insurance      = edit,
                        Insurances     = _context.Insurances.OrderByDescending(i => i.Id).ToList(),
                        InsuranceTypes = _context.InsuranceTypes.ToList() 
                    };
                    return View(vm);
                }
                else
                {
                    return RedirectToAction("Insurances","Admin");
                }
            }

            [HttpPost]
            public IActionResult InsuranceEdit(AdminInsuranceEditViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    Insurance up = _context.Insurances.Where(i => i.Id == vm.Insurance.Id).FirstOrDefault();
                    if (up != null)
                    {
                        up.DateExpire = vm.Insurance.DateExpire;
                        _context.SaveChanges();
                    }
                }
                return View(
                    new AdminInsuranceEditViewModel()
                    {
                        Insurance = vm.Insurance,
                        Insurances     = _context.Insurances.OrderByDescending(i => i.Id).ToList(),
                        InsuranceTypes = _context.InsuranceTypes.ToList()
                    }
                );
            }

            [HttpGet]
            public IActionResult InsuranceDelete(int id)
            {
                Insurance delete = _context.Insurances.Where(i => i.Id == id).FirstOrDefault();
                if (delete != null)
                {
                    // Chỉnh sửa thông tin người bệnh sở hữu thẻ BHYT
                    Patient owner = _context.Patients.Where(p => p.Insurance_Id == id).FirstOrDefault();
                    if (owner != null)
                    {
                        owner.Insurance_Id = 0;
                    }

                    _context.Insurances.Remove(delete);
                    _context.SaveChanges();
                }
                return RedirectToAction("Insurances","Admin");
            }
            #endregion
            #region Loại BHYT
            public IActionResult InsuranceTypes()
            {
                AdminInsuranceTypesViewModel vm = new AdminInsuranceTypesViewModel()
                {
                    Insurances = _context.Insurances.ToList(),
                    InsuranceType = new InsuranceType(),
                    InsuranceTypes = _context.InsuranceTypes.OrderBy(i => i.Type).ToList()
                };
                return View(vm);
            }

            [HttpPost]
            public IActionResult InsuranceTypes(AdminInsuranceTypesViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    _context.InsuranceTypes.Add(vm.InsuranceType);
                    _context.SaveChanges();
                    return View(
                        new AdminInsuranceTypesViewModel()
                        {
                            Insurances = _context.Insurances.ToList(),
                            InsuranceType = new InsuranceType(),
                            InsuranceTypes = _context.InsuranceTypes.OrderBy(i => i.Type).ToList()
                        } 
                    );
                }
                else
                {
                    return View(
                        new AdminInsuranceTypesViewModel()
                        {
                            Insurances = _context.Insurances.ToList(),
                            InsuranceType = vm.InsuranceType,
                            InsuranceTypes = _context.InsuranceTypes.OrderBy(i => i.Type).ToList()
                        } 
                    );
                }
            }

            [HttpGet]
            public IActionResult InsuranceTypeEdit(int id)
            {
                InsuranceType edit = _context.InsuranceTypes.Where(i => i.Id == id).FirstOrDefault();
                if (edit != null)
                {
                    return View(
                        new AdminInsuranceTypesViewModel()
                        {
                            Insurances = _context.Insurances.ToList(),
                            InsuranceType = edit,
                            InsuranceTypes = _context.InsuranceTypes.OrderBy(i => i.Type).ToList()
                        } 
                    );
                }
                else
                {
                    return RedirectToAction("InsuranceTypes","Admin");
                }
            }

            [HttpPost]
            public IActionResult InsuranceTypeEdit(AdminInsuranceTypesViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    InsuranceType up = _context.InsuranceTypes.Where(i => i.Id == vm.InsuranceType.Id).FirstOrDefault();
                    if (up != null)
                    {
                        up.Type       = vm.InsuranceType.Type;
                        up.Fee        = vm.InsuranceType.Fee;
                        up.PayLimit   = vm.InsuranceType.PayLimit;
                        up.PayPercent = vm.InsuranceType.PayPercent;
                        _context.SaveChanges();
                    }
                }
                return View(
                    new AdminInsuranceTypesViewModel()
                        {
                            Insurances     = _context.Insurances.ToList(),
                            InsuranceType  = vm.InsuranceType,
                            InsuranceTypes = _context.InsuranceTypes.OrderBy(i => i.Type).ToList()
                        }
                );
            }

            [HttpGet]
            public IActionResult InsuranceTypeDelete(int id)
            {
                InsuranceType delete = _context.InsuranceTypes.Where(i => i.Id == id).FirstOrDefault();
                if (delete != null)
                {
                    _context.InsuranceTypes.Remove(delete);
                    _context.SaveChanges();
                }
                return RedirectToAction("InsuranceTypes","Admin");
            }
            #endregion
        #endregion
        #region Nhóm ca trực
        #region Ca trực
        public IActionResult Shifts()
        {
            AdminShiftsViewModel vm = new AdminShiftsViewModel()
            {
                Shift  = new Shift(),
                Shifts = _context.Shifts.OrderBy(s => s.TimeStart.Hour).ThenBy(s => s.TimeStart.Minute).ThenBy(s => s.Session).ToList()
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Shifts(AdminShiftsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Shifts.Add(vm.Shift);
                _context.SaveChanges();
                return View(
                    new AdminShiftsViewModel()
                    {
                        Shift  = new Shift(),
                        Shifts = _context.Shifts.OrderByDescending(s => s.Session).ToList()
                    }
                );
            }
            else
            {
                return View(
                    new AdminShiftsViewModel()
                    {
                        Shift  = vm.Shift,
                        Shifts = _context.Shifts.OrderByDescending(s => s.Session).ToList()
                    }
                );
            }
        }
        [HttpGet]
        public IActionResult ShiftEdit(int id)
        {
            Shift edit = _context.Shifts.Where(s => s.Id == id).FirstOrDefault();
            if (edit != null)
            {
                return View(
                    new AdminShiftsViewModel()
                    {
                        Shift  = edit,
                        Shifts = _context.Shifts.OrderByDescending(s => s.Session).ToList()
                    }
                );
            }
            else
            {
                return RedirectToAction("Shifts","Admin");
            }
        }
        [HttpPost]
        public IActionResult ShiftEdit(AdminShiftsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Shift up = _context.Shifts.Where(s => s.Id == vm.Shift.Id).FirstOrDefault();
                if (up != null)
                {
                    up.Session   = vm.Shift.Session;
                    up.TimeStart = vm.Shift.TimeStart;
                    up.TimeEnd   = vm.Shift.TimeEnd;
                    _context.SaveChanges();
                }
            }
            return View(
                new AdminShiftsViewModel()
                    {
                        Shift  = vm.Shift,
                        Shifts = _context.Shifts.OrderByDescending(s => s.Session).ToList()
                    }
            );
        }
        [HttpGet]
        public IActionResult ShiftDelete(int id)
        {
            Shift delete = _context.Shifts.Where(s => s.Id == id).FirstOrDefault();
            if (delete != null)
            {
                _context.Shifts.Remove(delete);
                _context.SaveChanges();
            }
            return RedirectToAction("Shifts","Admin");
        }
        #endregion
        #region Lịch trực
        public IActionResult ShiftPlans()
        {
            AdminShiftPlansViewModel vm = new AdminShiftPlansViewModel()
            {
                ShiftPlans = _context.ShiftPlans.OrderByDescending(sp => sp.DateStart).ToList(),
                Shifts = _context.Shifts.OrderByDescending(s => s.Session).ThenBy(s => s.TimeStart).ToList(),
                Rooms = _context.Rooms.OrderBy(r => r.ShortCode).ToList(),
                Doctors = _context.Doctors.OrderBy(d => d.NameLast).ThenBy(d => d.NameMiddle).ThenBy(d => d.NameFirst).ToList()
            };
            return View(vm);
        }

        public IActionResult ShiftPlanNew()
        {
            List<ShiftPlan> plans = new List<ShiftPlan>();
            foreach (ShiftPlan sp in _context.ShiftPlans.ToList())
            {
                int nowD = DateTime.Now.Day;
                int nowM = DateTime.Now.Month;

                if (nowM == sp.DateStart.Month)
                {
                    if (sp.DateStart.Day <= nowD && sp.DateEnd.Day >= nowD)
                    {
                        plans.Add(sp);
                    }
                }
            }

            AdminShiftPlanNewViewModel vm = new AdminShiftPlanNewViewModel()
            {
                ShiftPlan = new ShiftPlan(),
                Shifts = _context.Shifts.OrderByDescending(s => s.Session).ThenBy(s => s.TimeStart).ToList(),
                ShiftPlans = plans,
                Rooms = _context.Rooms.OrderBy(r => r.ShortCode).ToList(),
                Doctors = _context.Doctors.OrderBy(d => d.NameLast).ThenBy(d => d.NameMiddle).ThenBy(d => d.NameFirst).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult ShiftPlanNew(AdminShiftPlanNewViewModel vm)
        {
            List<ShiftPlan> plans = new List<ShiftPlan>();
            foreach (ShiftPlan sp in _context.ShiftPlans.ToList())
            {
                int nowD = DateTime.Now.Day;
                int nowM = DateTime.Now.Month;

                if (nowM == sp.DateStart.Month)
                {
                    if (sp.DateStart.Day <= nowD && sp.DateEnd.Day >= nowD)
                    {
                        plans.Add(sp);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                _context.ShiftPlans.Add(vm.ShiftPlan);
                _context.SaveChanges();
                
                return View(
                    new AdminShiftPlanNewViewModel()
                    {
                        ShiftPlan = new ShiftPlan(),
                        Shifts = _context.Shifts.OrderByDescending(s => s.Session).ThenBy(s => s.TimeStart).ToList(),
                        ShiftPlans = plans,
                        Rooms = _context.Rooms.OrderBy(r => r.ShortCode).ToList(),
                        Doctors = _context.Doctors.OrderBy(d => d.NameLast).ThenBy(d => d.NameMiddle).ThenBy(d => d.NameFirst).ToList()
                    }
                );
            }
            else
            {
                return View(
                    new AdminShiftPlanNewViewModel()
                    {
                        ShiftPlan = vm.ShiftPlan,
                        Shifts = _context.Shifts.OrderByDescending(s => s.Session).ThenBy(s => s.TimeStart).ToList(),
                        ShiftPlans = plans,
                        Rooms = _context.Rooms.OrderBy(r => r.ShortCode).ToList(),
                        Doctors = _context.Doctors.OrderBy(d => d.NameLast).ThenBy(d => d.NameMiddle).ThenBy(d => d.NameFirst).ToList()
                    }
                );
            }
        } 

        [HttpGet]
        public IActionResult ShiftPlanEdit(int id)
        {
            ShiftPlan edit = _context.ShiftPlans.Where(sp => sp.Id == id).FirstOrDefault();
            List<ShiftPlan> plans = new List<ShiftPlan>();
            foreach (ShiftPlan sp in _context.ShiftPlans.ToList())
            {
                int nowD = DateTime.Now.Day;
                int nowM = DateTime.Now.Month;

                if (nowM == sp.DateStart.Month)
                {
                    if (sp.DateStart.Day <= nowD && sp.DateEnd.Day >= nowD)
                    {
                        plans.Add(sp);
                    }
                }
            }
            if (edit != null)
            {
                return View(
                    new AdminShiftPlanNewViewModel()
                    {
                        ShiftPlan = edit,
                        Shifts = _context.Shifts.OrderByDescending(s => s.Session).ThenBy(s => s.TimeStart).ToList(),
                        ShiftPlans = plans,
                        Rooms = _context.Rooms.OrderBy(r => r.ShortCode).ToList(),
                        Doctors = _context.Doctors.OrderBy(d => d.NameLast).ThenBy(d => d.NameMiddle).ThenBy(d => d.NameFirst).ToList()
                    }
                );
            }
            return RedirectToAction("ShiftPlans","Admin");
        }
        [HttpPost]
        public IActionResult ShiftPlanEdit(AdminShiftPlanNewViewModel vm)
        {
            if (ModelState.IsValid)
            {
                ShiftPlan up = _context.ShiftPlans.Where(sp => sp.Id == vm.ShiftPlan.Id).FirstOrDefault();
                if (up != null)
                {
                    up.Room_Id = vm.ShiftPlan.Room_Id;
                    up.Doctor_Id = vm.ShiftPlan.Doctor_Id;
                    up.Shift_Id = vm.ShiftPlan.Shift_Id;
                    up.DateStart = vm.ShiftPlan.DateStart;
                    up.DateEnd = vm.ShiftPlan.DateEnd;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("ShiftPlans","Admin");
        }
        [HttpGet]
        public IActionResult ShiftPlanDelete(int id)
        {
            ShiftPlan delete = _context.ShiftPlans.Where(sp => sp.Id == id).FirstOrDefault();
            if (delete != null)
            {
                _context.ShiftPlans.Remove(delete);
                _context.SaveChanges();
            }
            return RedirectToAction("ShiftPlans","Admin");
        }
        #endregion
        #endregion
    }
}
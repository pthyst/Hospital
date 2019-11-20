using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using website.Data;
using website.Models;
using website.ViewModels;

namespace website.Controllers
{
    public class VictimController : Controller
    {
        private WebsiteDbContext _context;

        public VictimController(WebsiteDbContext context)
        {
            _context = context;
        }
        // Màn hình chờ
        public IActionResult Index()
        {
            return View();
        }
        
        // Màn hình quét thẻ/nhập mã
        public IActionResult Login()
        {
            VictimLoginViewModel vm = new VictimLoginViewModel()
            {
                InsuranceId = 0
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Login(VictimLoginViewModel vm)
        {
            Insurance check = _context.Insurances.Where(i => i.Id == vm.InsuranceId).FirstOrDefault();
            if (check != null)
            {
                return RedirectToAction("Registration","Victim", new {insuranceId = vm.InsuranceId});
            }
            else
            {
                return View(
                    new VictimLoginViewModel()
                    {
                        InsuranceId = vm.InsuranceId
                    }
                );
            }
        }

        // Màn hình đăng ký khám bệnh theo khoa
        [HttpGet]
        public IActionResult Registration(int insuranceId)
        {
            VictimRegistrationViewModel vm = new VictimRegistrationViewModel()
            {
                Insurance = _context.Insurances.Where(i => i.Id == insuranceId).FirstOrDefault(),
                Faculties = _context.Faculties.OrderBy(f => f.Name).ToList()
            };
            return View(vm);
        }

        // Màn hình chọn bác sĩ 
        [HttpGet]
        public IActionResult Doctors(int insuranceId,int facultyId)
        {
            VictimDoctorsViewModel vm = new VictimDoctorsViewModel()
            {
                InsuranceId = insuranceId,
                FacultyName = _context.Faculties.Where(f => f.Id == facultyId).FirstOrDefault().Name,
                Doctors     = _context.Doctors.Where(d => d.Faculty_Id == facultyId).OrderBy(d => d.NameLast).ThenBy(d => d.NameMiddle).ThenBy(d => d.NameFirst).ToList()
            };
            return View(vm);
        }

        // Màn hình thông báo hoàn tất đăng ký
        [HttpGet]
        public IActionResult Complete(int insuranceId,int doctorId)
        {
            // Lấy lịch trực hôm nay 
            // nullhere
            var queryable = _context.ShiftPlans.Where(sp => sp.Doctor_Id == doctorId);
            ShiftPlan shiftplan = queryable.Where(sp => sp.DateStart.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy")).FirstOrDefault();
            
            // Lấy mã phòng
            Room room = _context.Rooms.Where(r => r.Id == shiftplan.Id).FirstOrDefault();
            string roomshortcode = room.ShortCode;

            // Lấy tên bác sĩ
            Doctor doc = _context.Doctors.Where(d => d.Id == doctorId).FirstOrDefault();
            string doctorname = doc.NameLast + " " + doc.NameMiddle + " " + doc.NameFirst;

            // Lấy tên khoa
            string facultyname = _context.Faculties.Where(f => f.Id == doc.Faculty_Id).FirstOrDefault().Name;

            // Lấy số thứ tự
            //nullhere
            int waitnumber = 0;
            var ifnull = _context.WaitingLines.Where(w => w.Room_Id == room.Id).LastOrDefault();
            if (ifnull == null)
            {
                waitnumber = 1;
            }
            else
            {
                waitnumber = ifnull.Number + 1;
            }
           

            // Thêm vào hàng chờ
            WaitingLine new_wait = new WaitingLine()
            {
                Room_Id    = room.Id,
                Patient_Id = _context.Patients.Where(p => p.Insurance_Id == insuranceId).FirstOrDefault().Id,
                Number     = waitnumber
            };

            _context.WaitingLines.Add(new_wait);
            _context.SaveChanges();

            VictimCompleteViewModel vm = new VictimCompleteViewModel()
            {
                RoomShortCode = roomshortcode,
                DoctorName    = doctorname,
                FacultyName   = facultyname,
                WaitNumber    = waitnumber
            };

            return View(vm);
        }
    }
}
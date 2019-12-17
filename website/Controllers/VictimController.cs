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
            List<Doctor> ready = new List<Doctor>();
            foreach(Doctor doc in _context.Doctors.Where(d => d.Faculty_Id == facultyId).ToList())
            {
                if (IsInShift(doc.Id) == true)
                {
                    ready.Add(doc);
                }
            }

            VictimDoctorsViewModel vm = new VictimDoctorsViewModel()
            {
                InsuranceId = insuranceId,
                FacultyName = _context.Faculties.Where(f => f.Id == facultyId).FirstOrDefault().Name,
                Doctors     = ready
            };
            return View(vm);
        }

        // Hàm kiểm tra xem bác sĩ có trong ca trực hiện tại hay không
        public bool IsInShift(int doctorId)
        {
            bool flag = false;
            int now_to_int = (DateTime.Now.Hour * 60) + DateTime.Now.Minute;

            // Lấy lịch trực của bác sĩ trong ngày
            List<ShiftPlan> plans = new List<ShiftPlan>();
            foreach (ShiftPlan sp in _context.ShiftPlans.ToList())
            {
                int nowD = DateTime.Now.Day;
                int nowM = DateTime.Now.Month;

                if (nowM == sp.DateStart.Month)
                {
                    if (sp.DateStart.Day <= nowD && sp.DateEnd.Day >= nowD && sp.Doctor_Id == doctorId)
                    {
                        plans.Add(sp);
                    }
                }
            }

            if (plans.Count == 0){ return false;}
            else
            {
                foreach (ShiftPlan plan in plans)
                {
                    Shift shift = _context.Shifts.Where(sp => sp.Id == plan.Shift_Id).FirstOrDefault();
                    int start_to_int = (shift.TimeStart.Hour*60 + shift.TimeStart.Minute);
                    int end_to_int = (shift.TimeEnd.Hour*60 + shift.TimeEnd.Minute);
                    if (start_to_int <= now_to_int && end_to_int > now_to_int)
                    { flag = true;}
                }
            }
            return flag;
        }

        // Return a shiftplans
        public ShiftPlan GetShiftPlanFromDoctorId(int doctorId)
        {
            if (IsInShift(doctorId) == true)
            {
                ShiftPlan result = new ShiftPlan();
                int now_to_int = (DateTime.Now.Hour * 60) + DateTime.Now.Minute;
                // Lấy lịch trực của bác sĩ trong ngày
                List<ShiftPlan> plans = new List<ShiftPlan>();
                foreach (ShiftPlan sp in _context.ShiftPlans.ToList())
                {
                    int nowD = DateTime.Now.Day;
                    int nowM = DateTime.Now.Month;

                    if (nowM == sp.DateStart.Month)
                    {
                        if (sp.DateStart.Day <= nowD && sp.DateEnd.Day >= nowD && sp.Doctor_Id == doctorId)
                        {
                            plans.Add(sp);
                        }
                    }
                }

                foreach (ShiftPlan plan in plans)
                {
                    Shift shift = _context.Shifts.Where(sp => sp.Id == plan.Shift_Id).FirstOrDefault();
                    int start_to_int = (shift.TimeStart.Hour * 60 + shift.TimeStart.Minute);
                    int end_to_int = (shift.TimeEnd.Hour * 60 + shift.TimeEnd.Minute);
                    if (start_to_int <= now_to_int && end_to_int > now_to_int) { result = plan; }
                }
                return result;
            }

            return null;
        }

        // Màn hình thông báo hoàn tất đăng ký
        [HttpGet]
        public IActionResult Complete(int insuranceId,int doctorId)
        {
            ShiftPlan shiftplan = GetShiftPlanFromDoctorId(doctorId);
            
            // Lấy mã phòng
            Room room = _context.Rooms.Where(r => r.Id == shiftplan.Room_Id).FirstOrDefault();
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
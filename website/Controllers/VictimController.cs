using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace website.Controllers
{
    public class VictimController : Controller
    {
        // Màn hình chờ
        public IActionResult Index()
        {
            return View();
        }
        
        // Màn hình quét thẻ/nhập mã
        public IActionResult Login()
        {
            return View();
        }

        // Màn hình đăng ký khám bệnh theo khoa
        public IActionResult Registration()
        {
            return View();
        }

        // Màn hình chọn bác sĩ 
        public IActionResult Doctor()
        {
            return View();
        }

        // Màn hình thông báo hoàn tất đăng ký
        public IActionResult Complete()
        {
            return View();
        }
    }
}
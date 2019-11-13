﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Role")]
        public int Role_Id { get; set; }
        public Role Role { get; set; }

        [ForeignKey("Faculty")]
        public int Faculty_Id { get; set; }
        public Faculty Faculty { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống.")]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu đăng nhập không được bỏ trống.")]
        [Display(Name = "Mật khẩu đăng nhập")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Tên không được để trống.")]
        [StringLength(100,ErrorMessage = "Tên tối đa 100 kí tự.")]
        [Display(Name = "Tên")]
        public string NameFirst { get; set; }

        [StringLength(100, ErrorMessage = "Họ đệm tối đa 100 kí tự.")]
        [Display(Name = "Họ đệm")]
        public string NameMiddle { get; set; }

        [Required(ErrorMessage = "Họ không được để trống.")]
        [StringLength(100, ErrorMessage = "Họ tối đa 100 kí tự.")]
        [Display(Name = "Họ")]
        public string NameLast { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [StringLength(20, ErrorMessage = "Số điện thoại tối đa 20 kí tự.")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ.")]
        public string Email { get; set; }

        //Phần này dành cho khóa ngoại
        #region Foreign Keys
        public ICollection<ShiftPlan> ShiftPlans { get; set; }
        public ICollection<Perscription> Perscriptions { get; set; }
        #endregion
    }
}

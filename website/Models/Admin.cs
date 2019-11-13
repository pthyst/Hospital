using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Role")]
        public int Role_Id { get; set; }
        public Role Role { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống.")]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu đăng nhập không được bỏ trống.")]
        [Display(Name = "Mật khẩu đăng nhập")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ.")]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày chỉnh sửa cuối")]
        public DateTime DateModify { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày sử dụng cuối")]
        public DateTime DateLastUsed { get; set; }

        //Phần này dành cho khóa ngoại
        #region Foreign Keys
        public ICollection<Medicine> Medicines { get; set; }
        #endregion
    }
}

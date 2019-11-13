using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public int Insurance_Id { get; set; }
        public int Role_Id { get; set; }
     

        [Required(ErrorMessage = "Tên không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên tối đa 100 kí tự.")]
        [Display(Name = "Tên")]
        public string NameFirst { get; set; }

        [StringLength(100, ErrorMessage = "Họ đệm tối đa 100 kí tự.")]
        [Display(Name = "Họ đệm")]
        public string NameMiddle { get; set; }

        [Required(ErrorMessage = "Họ không được để trống.")]
        [StringLength(100, ErrorMessage = "Họ tối đa 100 kí tự.")]
        [Display(Name = "Họ")]
        public string NameLast { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày sinh")]
        public DateTime DateBirth { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Số nhà không được để trống")]
        [Display(Name = "Số nhà")]
        public string AddressApartment { get; set; }

        [Required(ErrorMessage = "Tên đường không được để trống")]
        [Display(Name = "Tên đường")]
        public string AddressStreet { get; set; }

        [Required(ErrorMessage = "Quận/Huyện không được để trống")]
        [Display(Name = "Quận/Huyện")]
        public string AddressDistrict { get; set; }

        [Required(ErrorMessage = "Tỉnh/Thành phố không được để trống")]
        [Display(Name = "Tỉnh/Thành phố")]
        public string AddressCity { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [StringLength(20, ErrorMessage = "Số điện thoại tối đa 20 kí tự.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Cân nặng (kg)")]
        public int? Weight { get; set; } = 0;
      
        [Display(Name = "Chiều cao (cm)")]
        public int? Height { get; set; } = 0;

        [Display(Name = "Nhóm máu")]
        public string Blood_Type { get; set; }

        [Display(Name = "Rh+/Rh-")]
        public string Rh { get; set; }

        [Display(Name = "Nhịp tim/phút")]
        public int BMP { get; set; }
    }
}

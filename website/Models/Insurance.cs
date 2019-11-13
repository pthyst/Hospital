using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Insurance
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("InsuranceType")]
        public int InsuranceType_Id { get; set; }
        public InsuranceType InsuranceType { get; set; }

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

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày đăng ký")]
        public DateTime DateRegistration { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày hết hạn")]
        public DateTime DateExpire { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày sử dụng cuối")]
        public DateTime DateLastUsed { get; set; }

        [Required(ErrorMessage = "Số điện thoại cá nhân không được để trống.")]
        [StringLength(20, ErrorMessage = "Số điện thoại tối đa 20 kí tự.")]
        [Display(Name = "Số điện thoại cá nhân")]
        public string PhoneNumberPersonal { get; set; }

        [Required(ErrorMessage = "Số điện thoại người thân không được để trống.")]
        [StringLength(20, ErrorMessage = "Số điện thoại tối đa 20 kí tự.")]
        [Display(Name = "Số điện thoại người thân")]
        public string PhoneNumberHome { get; set; }

        //Phần này dành cho khóa ngoại
        #region Foreign Keys
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Bill> Bills { get; set; }
        #endregion
    }
}

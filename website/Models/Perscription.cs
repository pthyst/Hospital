using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Perscription
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Faculty")]
        public int Faculty_Id { get; set; }
        public Faculty Faculty { get; set; }

        [ForeignKey("Doctor")]
        public int Doctor_Id { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        public int Patient_Id { get; set; }
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "Tên đơn thuốc không được để trống.")]
        [Display(Name = "Tên đơn thuốc")]
        public string Name { get; set; } = "Chưa có tên";

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày chỉnh sửa cuối")]
        public DateTime DateModify { get; set; }

        // Phần này dành cho khóa ngoại
        #region Foreign Keys
        public ICollection<PerscriptionDetail> PerscriptionDetails { get; set; }
        public ICollection<Bill> Bills { get; set; }
        #endregion
    }
}

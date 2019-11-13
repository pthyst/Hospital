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
        public int Faculty_Id { get; set; }
        public int Doctor_Id { get; set; }
        public int Patient_Id { get; set; }
  

        [Required(ErrorMessage = "Tên đơn thuốc không được để trống.")]
        [Display(Name = "Tên đơn thuốc")]
        public string Name { get; set; } = "Chưa có tên";

        [Display(Name = "Chuẩn đoán")]
        public string Description {get;set;}

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày chỉnh sửa cuối")]
        public DateTime DateModify { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Medicine
    {
        [Key]
        [DisplayName("Mã Thuốc")]
        public int Id { get; set; }
        [Display(Name = "Mã quản trị viên")]
        public int Admin_Id { get; set; }
        [Display(Name = "Mã đơn vị thuốc")]
        public int MedicineUnit_Id { get; set; }

        [Required(ErrorMessage = "Tên thuốc không được bỏ trống.")]
        [DisplayName("Tên Thuốc")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Đơn giá không được bỏ trống.")]
        [DisplayName("Đơn giá")]
        public int Price { get; set; } = 0;

        [Required(ErrorMessage = "Số lượng trong kho không được để trống.")]
        [Display(Name = "Số lượng trong kho")]
        public int Instore { get; set; } = 0;
        
        public string Thumbnail { get; set; } = "#";

        [DataType(DataType.DateTime)]
        [DisplayName("Ngày thêm")]
        public DateTime DateCreate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Ngày sửa")]
        public DateTime DateModify { get; set; }
    }
}

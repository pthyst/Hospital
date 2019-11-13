using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Faculty")]
        public int Faculty_Id { get; set; }
        public Faculty Faculty { get; set; }

        [Required(ErrorMessage = "Tên phòng không được bỏ trống.")]
        [Display(Name = "Tên phòng")]
        public string Name { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

        //Phần này dành cho khóa ngoại
        #region Foreign Keys
        public ICollection<WaitingLine> WaitingLines { get; set; }
        public ICollection<ShiftPlan> ShiftPlans { get; set; }
        #endregion
=======
>>>>>>> parent of 95b0adf... Quân - Hoàn thành thêm xóa sửa Phòng và Khoa
=======
>>>>>>> parent of 95b0adf... Quân - Hoàn thành thêm xóa sửa Phòng và Khoa
=======
>>>>>>> parent of 95b0adf... Quân - Hoàn thành thêm xóa sửa Phòng và Khoa
    }
}

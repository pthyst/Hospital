using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên buổi không được để trống.")]
        [Display(Name = "Buổi")]
        public string Session { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Giờ bắt đầu")]
        public DateTime TimeStart { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Giờ kết thúc")]
        public DateTime TimeEnd { get; set; }

        //Phần này dành cho khóa ngoại
        #region Foreign Keys
        public ICollection<ShiftPlan> ShiftPlans { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class ShiftPlan
    {
        [Key]
        public int Id { get; set; }
        public int Room_Id { get; set; }
        public int Doctor_Id { get; set; }
        public int Shift_Id { get; set; }
     
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày kết thúc")]
        public DateTime DateEnd { get; set; }
    }
}

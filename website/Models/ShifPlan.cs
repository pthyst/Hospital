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

        [ForeignKey("Room")]
        public int Room_Id { get; set; }
        public Room Room { get; set; }

        [ForeignKey("Doctor")]
        public int Doctor_Id { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Shift")]
        public int Shift_Id { get; set; }
        public Shift Shift { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày kết thúc")]
        public DateTime DateEnd { get; set; }
    }
}

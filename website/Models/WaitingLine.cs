using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class WaitingLine
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int Patient_Id { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Room")]
        public int Room_Id { get; set; }
        public Room Room { get; set; }

        [Display(Name = "Tình trạng")]
        public string Status { get; set; } = "Đang đợi";
    }
}

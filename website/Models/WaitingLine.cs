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
        public int Patient_Id { get; set; }
        public int Room_Id { get; set; }
     
        [Display(Name = "Tình trạng")]
        public string Status { get; set; } = "Đang đợi";
    }
}

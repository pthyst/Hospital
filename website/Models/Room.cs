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
        public int Faculty_Id { get; set; }

        [Required(ErrorMessage = "Tên phòng không được bỏ trống.")]
        [Display(Name = "Tên phòng")]
        public string Name { get; set; }

        [Display(Name = "Mã phòng")]
        public string ShortCode {get; set;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class MedicineUnit
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đơn vị không được bỏ trống.")]
        [Display(Name = "Tên đơn vị")]
        public string Unit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace website.ViewModels
{
    public class DoctorLoginViewModel
    {
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}

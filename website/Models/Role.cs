using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên phân quyền không được bỏ trống.")]
        [Display(Name = "Tên phân quyền")]
        public string Name { get; set; }

        //Phần này dành cho khóa ngoại
        #region Foreign Keys
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<Pharamacist> Pharamacists { get; set; }
        #endregion
    }
}

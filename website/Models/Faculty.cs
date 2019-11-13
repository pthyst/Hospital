using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên khoa không được bỏ trống.")]
        [Display(Name = "Tên khoa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phí khám chữa bệnh không được bỏ trống")]
        [Display(Name = "Phí khám chữa bệnh (VNĐ)")]
        public int Fee { get; set; } = 0;

        //Phần này dành cho khóa ngoại
        #region Foreign Keys
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Perscription> Perscriptions { get; set; }
        #endregion
    }
}

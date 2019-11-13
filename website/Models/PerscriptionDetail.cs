using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class PerscriptionDetail
    {
        [Key]
        public int Id { get; set; }
        public int Perscription_Id { get; set; }
        public int Medicine_Id { get; set; }
   

        [Required(ErrorMessage = "Tổng số lượng không được để trống.")]
        [Display(Name = "Tổng số lượng")]
        public int Quantity { get; set; } = 0;

        [Display(Name = "Sáng")]
        public int Morning { get; set; } = 0;

        [Display(Name = "Trưa")]
        public int Noon { get; set; } = 0;

        [Display(Name = "Tối")]
        public int Evening { get; set; } = 0;

        [Display(Name = "Ngày")]
        public int Days { get; set; } = 0;

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
    }
}

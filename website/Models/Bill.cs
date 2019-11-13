using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Perscription")]
        public int Perscription_Id { get; set; }
        public Perscription Perscription { get; set; }

        [ForeignKey("Pharamacist")]
        public int Pharamacist_Id { get; set; }
        public Pharamacist Pharamacist { get; set; }

        [ForeignKey("Insurance")]
        public int Insurance_Id { get; set; }
        public Insurance Insurance { get; set; }

        [Display(Name = "Tổng tiền")]
        public int PayTotal { get; set; } = 0;

        [Display(Name = "Bảo hiểm chi trả")]
        public int PayInsurance { get; set; } = 0;

        [Display(Name = "Người bệnh chi trả")]
        public int PayPatient { get; set; } = 0;

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreate { get; set; }
    }
}

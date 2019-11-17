using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website.Models
{
    public class InsuranceType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại bảo hiểm không được để trống.")]
        [StringLength(100,ErrorMessage = "Tên loại bảo hiểm tối đa 100 kí tự.")]
        [Display(Name = "Loại bảo hiểm")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Phần trăm chi trả không được để trống.")]
        [Range(0.0,100.0)]
        [Display(Name = "Phần trăm chi trả")]
        public double PayPercent { get; set; } = 0.0;

        [Required(ErrorMessage = "Giới hạn chi trả không được để trống.")]
        [Display(Name = "Giới hạn chi trả")]
        public int PayLimit { get; set; } = 0;

        [Required(ErrorMessage = "Phí bảo hiểm hàng tháng không được để trống")]
        [Display(Name = "Phí bảo hiểm hàng tháng")]
        public int Fee {get;set;}
    }
}

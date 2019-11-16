using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;
using Microsoft.AspNetCore.Http;

namespace website.ViewModels
{
    public class AdminMedicineEditViewModel
    {
        public Medicine Medicine { get; set; }
        public IEnumerable<Medicine> Medicines {get;set;}
        public IEnumerable<MedicineUnit> MedicineUnits {get;set;} 
        public IFormFile Thumbnail {get;set;}
    }
}

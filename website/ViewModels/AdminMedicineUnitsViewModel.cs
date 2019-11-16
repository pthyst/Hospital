using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminMedicineUnitsViewModel
    {
        public IEnumerable<MedicineUnit> MedicineUnits {get;set;}
        public MedicineUnit MedicineUnit {get;set;}
    }
}

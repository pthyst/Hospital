using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminMedicinesViewModel
    {
        public IEnumerable<Medicine> Medicines { get; set; }
        public IEnumerable<MedicineUnit> MedicineUnits {get;set;} 
    }
}

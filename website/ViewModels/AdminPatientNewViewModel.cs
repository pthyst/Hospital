using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminPatientNewViewModel
    {
        public Patient Patient {get;set;}
        public IEnumerable<InsuranceType> InsuranceTypes {get;set;}
        public int InsuranceType_Id {get;set;}
    }
}

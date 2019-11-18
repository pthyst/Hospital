using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminInsuranceEditViewModel
    {
        public Insurance Insurance {get;set;}
        public IEnumerable<Insurance> Insurances {get;set;}
        public IEnumerable<InsuranceType> InsuranceTypes {get;set;}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class VictimNewInsuranceViewModel
    {
        public IEnumerable<InsuranceType> InsuranceTypes {get;set;}
        public Insurance Insurance {get;set;}
    }
}

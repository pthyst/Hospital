using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class VictimRegistrationViewModel
    {
        public Insurance Insurance {get;set;}
        public IEnumerable<Faculty> Faculties {get;set;}
    }
}

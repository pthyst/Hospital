using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminDoctorNewViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<Faculty> Faculties{get;set;} 
    }
}

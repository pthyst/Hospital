using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminDoctorEditViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<Doctor> Doctors {get; set;}
        public IEnumerable<Faculty> Faculties{get;set;}
        
    }
}

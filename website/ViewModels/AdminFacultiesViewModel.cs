using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminFacultiesViewModel
    {
        public Faculty Faculty {get; set;}
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Doctor> Doctors {get;set;}
    }
}

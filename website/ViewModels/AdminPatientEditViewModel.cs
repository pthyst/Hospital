using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminPatientEditViewModel
    {
        public Patient Patient {get;set;}
        public IEnumerable<Patient> Patients {get;set;}
    }
}

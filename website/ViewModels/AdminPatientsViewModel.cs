using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminPatientsViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
    }
}

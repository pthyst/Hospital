using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class VictimDoctorsViewModel
    {
        public IEnumerable<Doctor> Doctors {get;set;}
        public int InsuranceId {get;set;}
        public string FacultyName {get;set;}
        
    }
}

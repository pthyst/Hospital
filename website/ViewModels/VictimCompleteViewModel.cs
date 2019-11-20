using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class VictimCompleteViewModel
    {
        public string FacultyName {get;set;}
        public string DoctorName {get;set;}
        public string RoomShortCode {get;set;}
        public int WaitNumber {get;set;}
        
    }
}

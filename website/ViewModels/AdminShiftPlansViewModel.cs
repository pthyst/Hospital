using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminShiftPlansViewModel
    {
       public IEnumerable<ShiftPlan> ShiftPlans {get;set;}
       public IEnumerable<Doctor> Doctors {get;set;}
       public IEnumerable<Room> Rooms {get;set;}
       public IEnumerable<Shift> Shifts {get;set;}
    }
}

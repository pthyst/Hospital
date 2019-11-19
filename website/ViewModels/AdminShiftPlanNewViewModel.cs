using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminShiftPlanNewViewModel
    {
       public IEnumerable<Room> Rooms {get;set;}
       public IEnumerable<Doctor> Doctors {get;set;}
       public IEnumerable<Shift> Shifts {get;set;}
       public IEnumerable<ShiftPlan> ShiftPlans {get;set;}
       public ShiftPlan ShiftPlan {get;set;}
    }
}

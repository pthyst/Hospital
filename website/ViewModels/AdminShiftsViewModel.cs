using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminShiftsViewModel
    {
        public Shift Shift {get;set;}
        public IEnumerable<Shift> Shifts {get;set;}
    }
}

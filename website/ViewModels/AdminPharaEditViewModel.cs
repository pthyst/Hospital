using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminPharaEditViewModel
    {
        public Pharamacist Phara {get;set;}
        public IEnumerable<Pharamacist> Pharas {get;set;}
        
    }
}

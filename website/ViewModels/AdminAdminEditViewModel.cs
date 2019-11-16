using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminAdminEditViewModel
    {
        public Admin Admin {get;set;}
        public IEnumerable<Admin> Admins {get;set;}
        
    }
}

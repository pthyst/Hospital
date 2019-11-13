using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminPharasViewModel
    {
        public IEnumerable<Pharamacist> Pharas { get; set; }
    }
}

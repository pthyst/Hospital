using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace website.ViewModels
{
    public class PerscriptionSaveViewModel
    {
        public int Patient_Id { get; set; }
        public int Doctor_Id { get; set; }
        public int Faculty_Id { get; set; }
        public string Name { get; set; } = "Chưa có tên";
        public string Description { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class PercriptionViewModel
    {
        public Perscription perscription { get; set; }
        public List<Medicine> medicine { get; set; } = new List<Medicine>();
        public List<PerscriptionMedicineDetail> perscriptionmedicinedetails { get; set; } = new List<PerscriptionMedicineDetail>();
        public List<PerscriptionDetail> perscriptiondetail { get; set; } = new List<PerscriptionDetail>();
        public void addperscriptiondetail(PerscriptionDetail pd) 
        {
            var data = perscriptiondetail.Find(x => x.Id == pd.Id);
            if (data==null)
            {
                perscriptiondetail.Add(pd);
            }
            else{
                perscriptiondetail.Remove(perscriptiondetail.Find(x => x.Id == pd.Id));
                perscriptiondetail.Add(pd);
            }
        }
    }
}

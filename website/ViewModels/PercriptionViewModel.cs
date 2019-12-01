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
        public List<PerscriptionDetail> perscriptiondetail { get; set; }
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

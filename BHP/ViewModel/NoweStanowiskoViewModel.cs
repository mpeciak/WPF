
using BHP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.ViewModel
{
    public class NoweStanowiskoViewModel:JedenViewModel<StanowiskoTS>
    {
        #region Constructor
        public NoweStanowiskoViewModel()
            : base("Nowe Stanowisko")
        {
            //Ustawiamy co wyświetla się w tytule zakładki
            item = new StanowiskoTS();
        }
        #endregion Constructor
        #region Properties
        public string NazwaStanowiska
        {
            get
            {
                return item.NazwaStanowiska;
            }
            set
            {
                if (value != item.NazwaStanowiska)
                {
                    item.NazwaStanowiska = value;
                    OnPropertyChanged(()=>NazwaStanowiska);
                }
            }
        }
        #endregion Properties
        #region Helpers
        public override void save()
        {
            bhpEntities.StanowiskoTS.Add(item);
            bhpEntities.SaveChanges();
        }
        #endregion Helpers
    }
}

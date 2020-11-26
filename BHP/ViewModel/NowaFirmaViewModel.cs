using BHP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.ViewModel
{
    public class NowaFirmaViewModel : JedenViewModel<FirmaTS>
    {
        #region Constructor
        public NowaFirmaViewModel()
            : base("Nowa Firma")
        {
            item = new FirmaTS();
        }
        #endregion Constructor
      
        #region Properties
        public string NazwaFirmy
        {
           get
           {
                return item.NazwaFirmy;
           }
           set
           {
               if(value!=item.NazwaFirmy)
               {
                   item.NazwaFirmy = value;
                   OnPropertyChanged(() => NazwaFirmy);
               }
           }
        }
        public string KodFirmy
        {
            get
            {
                return item.KodFirmy;
            }
            set
            {
                if (value != item.KodFirmy)
                {
                    item.KodFirmy = value;
                    OnPropertyChanged(() => KodFirmy);
                }
            }
        }

        #endregion Properties
        #region Helpers
        public override void save()
        {
            bhpEntities.FirmaTS.Add(item);
            bhpEntities.SaveChanges();
        }
        #endregion Helpers
    }
}

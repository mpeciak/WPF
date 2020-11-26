using BHP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.ViewModel
{
    public class NowaOdziezViewModel: JedenViewModel<Odziez>
    {

        #region Constructor
        public NowaOdziezViewModel()
            : base("Nowa Odziez")
        {
            //Ustawiamy co wyświetla się w tytule zakładki
            item = new Odziez();
        }
        #endregion Constructor
        #region Properties
        public string NazwaOdziezy
        {
            get
            {
                return item.NazwaOdziezy;
            }
            set
            {
                if (value != item.NazwaOdziezy)
                {
                    item.NazwaOdziezy = value;
                    OnPropertyChanged(() => NazwaOdziezy);
                }
            }
        }
        public string Rozmiar
        {
            get
            {
                return item.Rozmiar;
            }
            set
            {
                if (value != item.Rozmiar)
                {
                    item.Rozmiar = value;
                    OnPropertyChanged(() => Rozmiar);
                }
            }
        }
        #endregion Properties
        #region Helpers
        public override void save()
        {
            bhpEntities.Odziez.Add(item);
            bhpEntities.SaveChanges();
        }
        #endregion Helpers

    }
}

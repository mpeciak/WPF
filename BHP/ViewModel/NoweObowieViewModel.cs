using BHP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.ViewModel
{
    public class NoweObowieViewModel: JedenViewModel<Obowie>
    {
        #region Constructor
        public NoweObowieViewModel()
            : base("Nowe Obowie")
        {
            //Ustawiamy co wyświetla się w tytule zakładki
            item = new Obowie();
        }
        #endregion Constructor
        #region Properties
        public string NazwaObowia
        {
            get
            {
                return item.NazwaObowia;
            }
            set
            {
                if (value != item.NazwaObowia)
                {
                    item.NazwaObowia = value;
                    OnPropertyChanged(() => NazwaObowia);
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
            bhpEntities.Obowie.Add(item);
            bhpEntities.SaveChanges();
        }
        #endregion Helpers

    }
}

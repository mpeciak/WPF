using BHP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.ViewModel
{
    public class NowyAdresViewModel: JedenViewModel<Adresy>
    {
        #region Constructor
        public NowyAdresViewModel()
            : base("Nowy Adres")
        {
            //Ustawiamy co wyświetla się w tytule zakładki
            item = new Adresy();
        }
        #endregion Constructor
        #region Properties

        public string Miejscowosc
        {
            get
            {
                return item.Miejscowosc;
            }
            set
            {
                if (value != item.Miejscowosc)
                {
                    item.Miejscowosc = value;
                    OnPropertyChanged(() => Miejscowosc);
                }
            }
        }
        public string NrDomu
        {
            get
            {
                return item.NrDomu;
            }
            set
            {
                if (value != item.NrDomu)
                {
                    item.NrDomu = value;
                    OnPropertyChanged(() => NrDomu);
                }
            }
        }
        public string NrLokalu
        {
            get
            {
                return item.NrLokalu;
            }
            set
            {
                if (value != item.NrLokalu)
                {
                    item.NrLokalu = value;
                    OnPropertyChanged(() => NrLokalu);
                }
            }
        }
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                if (value != item.Ulica)
                {
                    item.Ulica = value;
                    OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                if (value != item.KodPocztowy)
                {
                    item.KodPocztowy = value;
                    OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        public string Poczta
        {
            get
            {
                return item.Poczta;
            }
            set
            {
                if (value != item.Poczta)
                {
                    item.Poczta = value;
                    OnPropertyChanged(() => Poczta);
                }
            }
        }
        #endregion Properties
        #region Helpers
        public override void save()
        {
            bhpEntities.Adresy.Add(item);
            bhpEntities.SaveChanges();
        }
        #endregion Helpers
    }
}


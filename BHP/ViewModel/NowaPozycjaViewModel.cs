using BHP.Model.BussnesLogic;
using BHP.Model.Entities;
using GalaSoft.MvvmLight.Messaging;
using BHP.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BHP.Model.Validatory;

namespace BHP.ViewModel
{
    public class NowaPozycjaViewModel : JedenViewModel<PozycjaObowieForAllView>//,IDataErrorInfo
    {
        #region Constructor
        public NowaPozycjaViewModel()
            : base("Pozycja faktury")
        {
            item = new PozycjaObowieForAllView();
          //  Messenger.Default.Register<PozycjaObowieForAllView>(this, loadPozycja);

        }
        #endregion Constructor

        #region Properties
        private bool Edytowanie = false;

        public long? IdObowia
        {
            get
            {
                return item.IdObowia;
            }
            set
            {
                if (value != item.IdObowia)
                {
                    item.IdObowia = value;
                    OnPropertyChanged(() => IdObowia);
                }
            }
        }


        public long? IdOdziezy
        {
            get
            {
                return item.IdOdziezy;
            }
            set
            {
                if (value != item.IdOdziezy)
                {
                    item.IdOdziezy = value;
                    OnPropertyChanged(() => IdOdziezy);
                }
            }
        }

        public IQueryable<ComboboxKeyAndValue> ObowieComboboxItems
        {
            get
            {
                return new TowarB(bhpEntities).GetObowieComboboxItems();
            }
        }

        public IQueryable<ComboboxKeyAndValue> OdziezComboboxItems
        {
            get
            {
                return new TowarB(bhpEntities).GetOdziezComboboxItems();
            }
        }
        public int? IloscObowia
        {
            get
            {
                return item.IloscObowia;
            }
            set
            {
                if (value != item.IloscObowia)
                {
                    item.IloscObowia = value;
                    OnPropertyChanged(() => IloscObowia); //dzieki tej funkcji kazda zmiana kodu w kodzie powoduje zmiane na interfejsie
                }
            }
        }

        public int? IloscOdziezy
        {
            get
            {
                return item.IloscOdziezy;
            }
            set
            {
                if (value != item.IloscOdziezy)
                {
                    item.IloscOdziezy = value;
                    OnPropertyChanged(() => IloscOdziezy); //dzieki tej funkcji kazda zmiana kodu w kodzie powoduje zmiane na interfejsie
                }
            }
        }
        public string RozmiarOdziezy
        {
            get
            {
                return item.RozmiarOdziezy;
            }
            set
            {
                if (value != item.RozmiarOdziezy)
                {
                    item.RozmiarOdziezy = value;
                    OnPropertyChanged(() => RozmiarOdziezy); //dzieki tej funkcji kazda zmiana kodu w kodzie powoduje zmiane na interfejsie
                }
            }
        }
        public string RozmiarObowia
        {
            get
            {
                return item.RozmiarObowia;
            }
            set
            {
                if (value != item.RozmiarObowia)
                {
                    item.RozmiarObowia = value;
                    OnPropertyChanged(() => RozmiarObowia); //dzieki tej funkcji kazda zmiana kodu w kodzie powoduje zmiane na interfejsie
                }
            }
        }
        #endregion Properties

        //#region Validation       
        //public string Error
        //{
        //    get
        //    {
        //        return null;
        //    }
        //}
        //public string this[string name]
        //{
        //    get
        //    {
        //        string komunikat = null; 
 
        //        if (name == "RozmiarObowia")
        //        {
        //            komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.RozmiarObowia);

        //        }
        //        if (name == "IloscObowia")
        //        {
        //            komunikat = BiznesValidatory.sprawdzIlosc(this.IloscObowia);
        //        }
        //        return komunikat;
        //    }
        //}
        //public override bool IsValid()
        //{
        //    if (this["RozmiarObowia"] == null && this["IloscObowia"] == null)
        //        return true;
        //    return false;
        //}
        //#endregion //Validatio
        #region Helpers
        
        public override void save()
        {
            if (!Edytowanie)
            {
                //Zamiast zapisania pozycji faktury do bazy nalezy wyslac te pozycje 
                //do okna z faktura
                Obowie obowie = bhpEntities.Obowie.First(o => o.IdObowia == IdObowia);
                Odziez odziez = bhpEntities.Odziez.First(o => o.IdOdziezy == IdOdziezy);
                item.NazwaObowia = obowie.NazwaObowia;
                item.NazwaOdziezy = odziez.NazwaOdziezy;
                item.RozmiarObowia = obowie.Rozmiar;
                item.RozmiarOdziezy = odziez.Rozmiar;
                Messenger.Default.Send<PozycjaObowieForAllView>(item);

            }
            else
                ShowMessageBox("brak czesci danych");
        }
        #endregion Helpers
    }
}

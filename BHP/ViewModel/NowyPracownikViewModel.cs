using BHP.Model.Entities;
using BHP.Model.EntitiesForView;
using BHP.Model.Validatory;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.ViewModel
{
    public class NowyPracownikViewModel : JedenWszystkieViewModel<Pracownicy, PozycjaObowieForAllView>//,IDataErrorInfo
    {
        #region Constructor
        public NowyPracownikViewModel()
            : base("Pracownik", "NowaPozycjaObowie")
        {
            //Ustawiamy co wyświetla się w tytule zakładki
            item = new Pracownicy();
            Messenger.Default.Register<PracownicyForAllView>(this, loadPracownik);
            Messenger.Default.Register<PozycjaObowieForAllView>(this, addPozycjaObowie);
        }


        #endregion Constructor
        #region Properties
        private bool Edytowanie = false;

        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (value != item.Imie)
                {
                    item.Imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (value != item.Nazwisko)
                {
                    item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }
        public long? Stanowisko
        {
            get
            {
                return item.Stanowisko;
            }
            set
            {
                if (value != item.Stanowisko)
                {
                    item.Stanowisko = value;
                    OnPropertyChanged(() => Stanowisko);
                }
            }
        }
        public long? IdFirmy
        {
            get
            {
                return item.IdFirmy;
            }
            set
            {
                if (value != item.IdFirmy)
                {
                    item.IdFirmy = value;
                    OnPropertyChanged(() => IdFirmy);
                }
            }
        }

        public string tech1
        {
            get
            {
                return item.tech1;
            }
            set
            {
                if (value != item.tech1)
                {
                    item.tech1 = value;
                    OnPropertyChanged(() => tech1);
                }
            }
        }
        public int? idOperatora
        {
            get
            {
                return item.idOperatora;
            }
            set
            {
                if (value != item.idOperatora)
                {
                    item.idOperatora = value;
                    OnPropertyChanged(() => idOperatora);
                }
            }
        }

        public DateTime? DataUtworzenia
        {
            get
            {
                return item.DataUtorzenia;
            }
            set
            {
                if (value != item.DataUtorzenia)
                {
                    item.DataUtorzenia = value;
                    OnPropertyChanged(() => DataUtworzenia);
                }
            }
        }
        public int? IdOdziezy
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

        public int? IdObowia
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

        public DateTime? DataModyfikacji
        {
            get
            {
                return item.DataModyfikacji;
            }
            set
            {
                if (value != item.DataModyfikacji)
                {
                    item.DataModyfikacji = value;
                    OnPropertyChanged(() => DataModyfikacji);
                }
            }
        }
        public DateTime? DataZatrudnienia
        {
            get
            {
                return item.DataZatrudnienia;
            }
            set
            {
                if (value != item.DataZatrudnienia)
                {
                    item.DataZatrudnienia = value;
                    OnPropertyChanged(() => DataZatrudnienia);
                }
            }
        }
        public DateTime? DataUsuniecia
        {
            get
            {
                return item.DataUsuniecia;
            }
            set
            {
                if (value != item.DataUsuniecia)
                {
                    item.DataUsuniecia = value;
                    OnPropertyChanged(() => DataUsuniecia);
                }
            }
        }
        public DateTime? DataZwolnienia
        {
            get
            {
                return item.DataZwolnienia;
            }
            set
            {
                if (value != item.DataZwolnienia)
                {
                    item.DataZwolnienia = value;
                    OnPropertyChanged(() => DataZwolnienia);
                }
            }
        }
        public string KtoUtorzyl
        {
            get
            {
                return item.KtoUtworzyl;
            }
            set
            {
                if (value != item.KtoUtworzyl)
                {
                    item.KtoUtworzyl = value;
                    OnPropertyChanged(() => KtoUtorzyl);
                }
            }
        }
        public string KtoZmodyfikowal
        {
            get
            {
                return item.KtoZmodyfikowal;
            }
            set
            {
                if (value != item.KtoZmodyfikowal)
                {
                    item.KtoZmodyfikowal = value;
                    OnPropertyChanged(() => KtoZmodyfikowal);
                }
            }
        }
        public string KtoUsunal
        {
            get
            {
                return item.KtoUsunal;
            }
            set
            {
                if (value != item.KtoUsunal)
                {
                    item.KtoUsunal = value;
                    OnPropertyChanged(() => KtoUsunal);
                }
            }
        }
        public bool? czyZatrudniony
        {
            get
            {
                return item.czyZatrudniony;
            }
            set
            {
                if (value != item.czyZatrudniony)
                {
                    item.czyZatrudniony = value;
                    OnPropertyChanged(() => czyZatrudniony);
                }
            }
        }



        public IQueryable<ComboboxKeyAndValue> StanowiskaComboboxItems
        {
            get
            {
                return
                    (
                    from stanowisko in bhpEntities.StanowiskoTS
                    select new ComboboxKeyAndValue
                    {
                        Key = stanowisko.IdStanowiska,
                        Value = stanowisko.NazwaStanowiska,
                    }
                    ).ToList().AsQueryable();
            }
        }

        public IQueryable<ComboboxKeyAndValue> FirmyComboboxItems
        {
            get
            {
                return
                    (
                    from firma in bhpEntities.FirmaTS
                    select new ComboboxKeyAndValue
                    {
                        Key = firma.IdFirmy,
                        Value = firma.NazwaFirmy
                    }
                    ).ToList().AsQueryable();
            }
        }

        public IQueryable<ComboboxKeyAndValue> ObowieComboboxItems
        {
            get
            {
                return
                    (
                    from obowie in bhpEntities.Obowie
                    select new ComboboxKeyAndValue
                    {
                        Key = obowie.IdObowia,
                        Value = obowie.NazwaObowia,
                    }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<ComboboxKeyAndValue> OdziezComboboxItems
        {
            get
            {
                return
                    (
                    from obowie in bhpEntities.Odziez
                    select new ComboboxKeyAndValue
                    {
                        Key = obowie.IdOdziezy,
                        Value = obowie.NazwaOdziezy,
                    }
                    ).ToList().AsQueryable();
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
        //        if (name == "Imie")
        //        {
        //            komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Imie);
        //        }
        //        if (name == "Nazwisko")
        //        {
        //            komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwisko);
        //        }
        //        return komunikat;
        //    }
        //}
        ////Funkcja sprawdza czy mozna zapisac rekord, sprawdza ktore pola musza byc prawidlowe zeby mozna bylo dodac rekord do bazy (nie wszystkie pola sa sprawdzane)
        //public override bool isValid()
        //{
        //    if (this["Imie"] == null && this["Nazwisko"] == null)
        //        return true;
        //    else
        //        return false;
        //}

        //#endregion Validation
        #region Helpers

        private void loadPracownik(PracownicyForAllView pracownik)
        {
            Edytowanie = true;
            item = bhpEntities.Pracownicy.Where(kon => kon.IdPracownika == pracownik.IdPracownika).First();
        }
        public override void save()
        {

            if (!Edytowanie)
            {
                bhpEntities.Pracownicy.Add(item);
            }

            bhpEntities.SaveChanges();

            foreach (PozycjaObowieForAllView pozycjaObowie in List)
            {
                var pozycja = new Pozycje
                {
                    IdObowia = pozycjaObowie.IdObowia,
                    IdOziezy = pozycjaObowie.IdOdziezy,
                    IloscObowia = pozycjaObowie.IloscObowia,
                    IloscOdziezy = pozycjaObowie.IloscOdziezy,
                    IdPracownika = item.IdPracownika
                };
                bhpEntities.Pozycje.Add(pozycja);
            }
            bhpEntities.SaveChanges();
        }

        private void addPozycjaObowie(PozycjaObowieForAllView obj)
        {
           
            List.Add(obj);
        }

        public override void LoadList()
        {
            List = new ObservableCollection<PozycjaObowieForAllView>();
        }
        #endregion Helpers
    }
}

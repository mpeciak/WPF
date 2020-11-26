using BHP.Helpers;
using BHP.Model.Entities;
using BHP.Model.EntitiesForView;
using BHP.ViewModel.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BHP.ViewModel
{
    class ZwolnieniePracownikaViewModel : JedenViewModel<Zwolnienia>
    {
        #region Fields
        //To jest pole do komendy, ktora zostanie podpieta pod przycisk z trzema kropkami, ktory wywola okno do wybierania Kontrahenta
        private BaseCommand _ShowZwolnieniCommand;
        #endregion Fields

        #region Constructor
        public ZwolnieniePracownikaViewModel()
            :base("Zwolnienia")
        {
            //Ustawiamy co wyświetla się w tytule zakładki
            item = new Zwolnienia();
            //To jest nasluchiwanie na wybranego Kontrahenta w oknie modalny, po zlapaniu Kontrahenta wywola sie metoda getWybranyKontrahent
            Messenger.Default.Register<ZwolnieniForAllView>(this, getWybranyPracownik);
            Messenger.Default.Register<PracownicyForAllView>(this, loadPracownik);

        }
        #endregion Constructor
        #region Command
        public ICommand ShowZwolnieniaCommand
        {
            get
            {
                if (_ShowZwolnieniCommand == null)
                {
                    //Po kliknieciu na button z trzema kropkami do MainWindowViewModel Messengerem zostanie wsylany komunikat wywolujacy okno ze wszystkimi Kontrahentami
                    _ShowZwolnieniCommand = new BaseCommand(() => Messenger.Default.Send("ZwolnieniaShow"));
                }
                return _ShowZwolnieniCommand;
            }
        }
        #endregion Command

        #region Properties
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

        private string _Stanowisko;
        public string Stanowisko {
            get
            {
                return _Stanowisko;
            }
            set
            {
                _Stanowisko = value;
                OnPropertyChanged(() => Stanowisko);
            }
        }

        private string _Firma;
        public string Firma
        {
            get
            {
                return _Firma;
            }
            set
            {
                _Firma = value;
                OnPropertyChanged(() => Firma);
            }
        }

        public string PrzyczynaZwolnienia
        {
            get
            {
                return item.PrzyczynaZwolnienia;
            }
            set
            {
                if (value != item.PrzyczynaZwolnienia)
                {
                    item.PrzyczynaZwolnienia = value;
                    OnPropertyChanged(() => PrzyczynaZwolnienia);
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

        public long? idFirmy
        {
            get
            {
                return item.idFirmy;
            }
            set
            {
                if (value != item.idFirmy)
                {
                    item.idFirmy = value;
                    OnPropertyChanged(() => idFirmy);
                }
            }
        }

        public long? idStanowiska
        {
            get
            {
                return item.idStanowiska;
            }
            set
            {
                if (value != item.idStanowiska)
                {
                    item.idStanowiska = value;
                    OnPropertyChanged(() => idStanowiska);
                }
            }
        }

        #endregion Properties
        #region Helpers
        private void loadPracownik(PracownicyForAllView pracownik)
        {
            Pracownicy p = bhpEntities.Pracownicy.Where(pr => pr.IdPracownika == pracownik.IdPracownika).First();
            Imie = pracownik.Imie;
            Nazwisko = pracownik.Nazwisko;
            idStanowiska= p.Stanowisko;
            idFirmy = p.IdFirmy;
            Firma = p.FirmaTS.NazwaFirmy;
            Stanowisko = p.StanowiskoTS?.NazwaStanowiska;
            DataZatrudnienia = p.DataZatrudnienia;
            DataZwolnienia = DateTime.Now;
        }

        public override void save()
        { 
            bhpEntities.Zwolnienia.Add(item);
            bhpEntities.SaveChanges();
        }
        private void getWybranyPracownik(ZwolnieniForAllView pracownik)
        {
            Imie = pracownik.Imie;
            Nazwisko = pracownik.Nazwisko;
            idStanowiska = pracownik.idStanowisko;
           // idFirmy=pracownik.idFirma;
        }
        #endregion Helpers
    }
}
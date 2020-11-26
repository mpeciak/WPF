using BHP.Model.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BHP.ViewModel
{
    public class ZwolnieniViewModel : WszystkieVieModel<ZwolnieniForAllView>
    {
        #region Constructor
        public ZwolnieniViewModel()
            : base("Zwolnieni")
        {
        }
        #endregion Constructor

        #region Properties
        //To jest pole ktore zostanie wypelnione po kliknieciu na wybranego Kontrahenta w tabelce
        private ZwolnieniForAllView _WybranyKontrahent;
        public ZwolnieniForAllView WybranyKontrahent
        {
            get
            {
                return _WybranyKontrahent;
            }
            set
            {
                if (_WybranyKontrahent != value)
                {
                    //set wywola sie wtedy jak ktos kliknie na wybranego Kontrahenta w tabelce
                    _WybranyKontrahent = value;
                    //wtedy Messengerem do Faktury wyslemy wybranego Kontrahenta
                    Messenger.Default.Send(_WybranyKontrahent);
                    //Po wybraniu kontrahenta nalezy zamknac okno
                    onRequestClose();
                }
            }
        }
        public ZwolnieniForAllView WybranyElement
        {
            get
            {
                return _WybranyElement;
            }
            set
            {
                if (value != _WybranyElement)
                {
                    _WybranyElement = value;

                }
            }
        }

        #endregion Properties
        #region SortAndFind
        public override List<String> GetComboboxSortList()
        {
            return null;
        }
        public override void Sort()
        {
        }
        public override List<String> GetComboboxFindList()
        {
            return null;
        }
        public override void Find()
        {
        }
        #endregion SortAndFind
        #region Helpers
        public override void select() { }
        public override void load()
        {
            List = new ObservableCollection<ZwolnieniForAllView>
                (
                    from kontrahent in bhpEntities.Pracownicy
                    select new ZwolnieniForAllView
                    {
                        IdPracownika = kontrahent.IdPracownika,
                        Imie = kontrahent.Imie,
                        Nazwisko=kontrahent.Nazwisko,
                        idStanowisko=kontrahent.Stanowisko,
                 //       idFirma =kontrahent.IdFirmy
                      }
               );
        }
        public override void modyfikuj() { }
        public override void delete()
        {
            if (WybranyElement == null)
            {
                MessageBox.Show("Wybrany pracownik null");
            }
            //   MessageBox.Show("Wybrany pracownik" + WybranyElement.Imie);
            //  MessageBox.Show("Wybrany pracownik id" + WybranyElement.IdPracownika);
            var zwolnienia1 = (from zwolnienia in bhpEntities.Zwolnienia
                              where WybranyElement.Imie == zwolnienia.Imie
                               select zwolnienia).FirstOrDefault();
            if (zwolnienia1 != null)
            {
                if (zwolnienia1.czyAktywny != false)
                {
                    zwolnienia1.czyAktywny = false;
                    bhpEntities.SaveChanges();
                    MessageBox.Show("Usunieto rekord", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Rekord już usunięty", "Informacja", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Rekord null ", "Informacja", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion Helpers
    }
}
using BHP.Model.Entities;
using BHP.Model.EntitiesForView;
using BHP.ViewModel.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BHP.ViewModel
{
    public class WszyscyPracownicyViewModel : WszystkieVieModel<PracownicyForAllView>
    {
            #region Constructor
            public WszyscyPracownicyViewModel()
                : base("Pokaż Pracowników")
            {      
            }
            #endregion Constructor
            #region SortAndFind
            public override List<String> GetComboboxSortList()
            {
                return new List<String> { "Imie", "Nazwisko" };
            }
            public override void Sort()
            {
                if (SortField == "Imie")
                    List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.Imie));
                if (SortField == "Nazwisko")
                    List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.Nazwisko));

            }
            public override List<String> GetComboboxFindList()
            {
                return new List<String> { "Imie", "Nazwisko","Data Zatrudnienia","Odziez","Obowie" }; ;
            }
            public override void Find()
            {
                load();
                if (FindField == "Imie")
                {
                    List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.Imie != null &&
                    item.Imie.StartsWith(FindTextBox)));
                }
                if (FindField == "Nazwisko")
                {
                    List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.Nazwisko != null &&
                    item.Nazwisko.StartsWith(FindTextBox)));
                }
                if (FindField == "Obowie")
                {
                    List = new ObservableCollection<PracownicyForAllView>(List.Where(item =>
                        item.Pracownik.Pozycje.Any(p => p.Obowie.NazwaObowia.ToLower().Contains(FindTextBox.ToLower())
                    )));
                }
                if (FindField == "Obowie")
                {
                    List = new ObservableCollection<PracownicyForAllView>(List.Where(item =>
                        item.Pracownik.Pozycje.Any(p => p.Odziez.NazwaOdziezy.ToLower().Contains(FindTextBox.ToLower())
                    )));
                }
                if (FindField == "Data Zatrudnienia")
                {
                List = new ObservableCollection<PracownicyForAllView>(List
                    .Where(item => item.DataZatrudnienia?.Date == DateTime.ParseExact(FindTextBox, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture).Date));
            }
            }
        #endregion SortAndFind
        #region Properties
        public PracownicyForAllView WybranyElement
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
        #region Helpers


        public override void select()
        {
            Messenger.Default.Send<PracownicyForAllView>(WybranyElement);
            Messenger.Default.Send("NoweZwolnienieShow");
            onRequestClose();
        }
        public override void load()
            {

            /* List = new ObservableCollection<PracownicyForAllView>
              (
                   from pracownik in bhpEntities.Pracownicy //Dla kazdego pracownika  z bazy danych Pracownicy
                   //where pracownik.czyZatrudniony
                   select new PracownicyForAllView              //tworzymy nowy obiekt typu PracownocyForAllView
               {
                       IdPracownika = pracownik.IdPracownika,
                       Imie = pracownik.Imie,
                       Nazwisko = pracownik.Nazwisko,
                       Firma = pracownik.FirmaTS.NazwaFirmy,
                       DataZatrudnienia = pracownik.DataZatrudnienia,
                       Stanowisko = pracownik.StanowiskoTS.NazwaStanowiska,
                       DataZwolnienia = pracownik.DataZwolnienia,

                   }
                );*/

              List = new ObservableCollection<PracownicyForAllView>(
            bhpEntities.Pracownicy.Where(p => p.czyZatrudniony ?? true).AsEnumerable().Select(pracownik =>        
                          new PracownicyForAllView              
                          {
                                  IdPracownika = pracownik.IdPracownika,
                                  Imie = pracownik.Imie,    
                                  Nazwisko = pracownik.Nazwisko,
                                  Firma = pracownik.FirmaTS?.NazwaFirmy,
                                  DataZatrudnienia = pracownik.DataZatrudnienia,
                                  Stanowisko = pracownik.StanowiskoTS?.NazwaStanowiska,
                                  DataZwolnienia = pracownik.DataZwolnienia,
                                  Pracownik = pracownik,
                                  ObowieNazwa = string.Join(", ", pracownik.Pozycje.Select(p => p.Obowie?.NazwaObowia)),
                                  OdziezNazwa = string.Join(", ", pracownik.Pozycje.Select(p => p.Odziez?.NazwaOdziezy)),
                                  RozmiarObowia = string.Join(" ", pracownik.Pozycje.Select(p => p.Obowie?.Rozmiar)),
                                  RozmiarOdziezy = string.Join(" ", pracownik.Pozycje.Select(p => p.Odziez?.Rozmiar))

                          }
                   ).ToList());
        }

        public override void modyfikuj()
        {
            if(WybranyElement == null)
                ShowMessageBox("nie wybrano pracownika!");
            else
            {
                Messenger.Default.Send("NowyPracownikShow");
                Messenger.Default.Send(WybranyElement);
            }
        }

        public override void delete()
        {
        //    if (WybranyElement == null)
        //    {
        //        MessageBox.Show("Wybrany pracownik null");
        //    }
            
        //    var pracownik1 = (from pracownik in bhpEntities.Pracownicy
        //                          where WybranyElement.IdPracownika == pracownik.IdPracownika
        //                          select pracownik).FirstOrDefault();
            
        //    if (pracownik1 != null)
        //        {
        //            if (pracownik1.czyZatrudniony != false)
        //            {
        //                 pracownik1.czyZatrudniony = false;
        //                bhpEntities.SaveChanges();
        //                MessageBox.Show("Usunieto rekord", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Rekord już usunięty", "Informacja", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //            }
        //    }
        //        else
        //        {
        //            MessageBox.Show("Rekord null ", "Informacja", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //        }
        }
        #endregion Helpers
    }
}

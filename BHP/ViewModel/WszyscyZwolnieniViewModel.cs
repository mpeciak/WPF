using BHP.Model.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.ViewModel
{
   public class WszyscyZwolnieniViewModel: WszystkieVieModel<ZwolnieniForAllView>
    {
        #region Constructor
        public WszyscyZwolnieniViewModel()
            : base("Wszyscy Zwolnieni")
        {
        }
        #endregion Constructor
        #region SortAndFind
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Imie", "Nazwisko"};
        }
        public override void Sort()
        {
            if (SortField == "Imie")
                List = new ObservableCollection<ZwolnieniForAllView>(List.OrderBy(item => item.Imie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<ZwolnieniForAllView>(List.OrderBy(item => item.Nazwisko));
        }
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Imie", "Nazwisko" };
        }
        public override void Find()
        {
            load();
            if (FindField == "Imie")
                List = new ObservableCollection<ZwolnieniForAllView>(List.Where(item => item.Imie != null &&
                item.Imie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<ZwolnieniForAllView>(List.Where(item => item.Nazwisko != null &&
                item.Nazwisko.StartsWith(FindTextBox)));
          
        }
        #endregion SortAndFind
        #region Properties
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
        #region Helpers
        public override void select()
        {

        }

        public override void load()
        {

            List = new ObservableCollection<ZwolnieniForAllView>
             (
                  from pracownik in bhpEntities.Zwolnienia //Dla kazdego pracownika  z bazy danych Pracownicy
                                                           //where pracownik.czyZatrudniony
                      select new ZwolnieniForAllView             //tworzymy nowy obiekt typu PracownocyForAllView
                  {
                      Imie = pracownik.Imie,
                      Nazwisko = pracownik.Nazwisko,
                      NazwaFirmy=pracownik.FirmaTS.NazwaFirmy,
                      idStanowisko = pracownik.StanowiskoTS.IdStanowiska,
                      Stanowisko=pracownik.StanowiskoTS.NazwaStanowiska,
                      DataZatrudnienia=pracownik.DataZatrudnienia,
                      DataZwolnienia=pracownik.DataZwolnienia,
                      PrzyczynaZwolnienia=pracownik.PrzyczynaZwolnienia,
                  }
               );
        }
        public override void delete(){}

        public override void modyfikuj(){}
        #endregion Helpers
    }
}
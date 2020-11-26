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
    public class WszyscyKontrahenciViewModel: WszystkieVieModel<KontrahenciForAllView>
    {
        #region Constructor
        public WszyscyKontrahenciViewModel()
            : base("Pokaż Kontrahentów")
        {
        }
        #endregion Constructor
        #region SortAndFind
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Nazwa", "Nip","Kod" };
        }
        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<KontrahenciForAllView>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Nip")
                List = new ObservableCollection<KontrahenciForAllView>(List.OrderBy(item => item.NIP));
            if (SortField == "Kod")
                List = new ObservableCollection<KontrahenciForAllView>(List.OrderBy(item => item.Kod));
        }
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Nazwa", "Kod","Nip" };
        }
        public override void Find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<KontrahenciForAllView>(List.Where(item => item.Nazwa != null &&
                item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Kod")
                List = new ObservableCollection<KontrahenciForAllView>(List.Where(item => item.Kod != null &&
                item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Nip")
                List = new ObservableCollection<KontrahenciForAllView>(List.Where(item => item.NIP != null &&
                item.NIP.StartsWith(FindTextBox)));

        }
        #endregion SortAndFind
        #region Properties
        public KontrahenciForAllView WybranyElement
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
        public override void select() {}
        public override void load()
        {
            List = new ObservableCollection<KontrahenciForAllView>
              (
                   from kontrahenci in bhpEntities.Kontrahenci //Dla kazdego pracownika  z bazy danych Pracownicy
                   select new KontrahenciForAllView              //tworzymy nowy obiekt typu PracownocyForAllView
                   {
                       IdKontrahenta = kontrahenci.IdKontrahenta,
                       Nazwa = kontrahenci.Nazwa,
                       Kod = kontrahenci.Kod,
                       NIP = kontrahenci.NIP
                   }
                );
        }
        public override void delete()
        {

            MessageBox.Show("Del");

            if (WybranyElement == null)
            {
                MessageBox.Show("Wybrany Kontrahent null");
            }var kontrahent1 = (from kontrahent in bhpEntities.Kontrahenci
                               where WybranyElement.Nazwa == kontrahent.Nazwa
                               select kontrahent).FirstOrDefault();
            if (kontrahent1 != null)
            {
                if (kontrahent1.czyAktywny != false)
                {
                    kontrahent1.czyAktywny = false;
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

        public override void modyfikuj()
        {

            if (WybranyElement == null)
                ShowMessageBox("nie wybrano kontrahenta!");
            else
            {
                Messenger.Default.Send("NowyKontrahentShow");
                Messenger.Default.Send(WybranyElement);
            }
        }
        #endregion Helpers
    }

}

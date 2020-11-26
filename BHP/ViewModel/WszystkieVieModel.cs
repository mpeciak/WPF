using BHP.ViewModel.Abstract;
using BHP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHP.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace BHP.ViewModel
{
   public abstract class WszystkieVieModel<T>:WorkspaceViewModel
    {
        #region Fields
        //laczenie z baza danych
        protected BHPEntities2 bhpEntities;
        //do zaladowania wszystkich obiektow
        private BaseCommand _LoadCommand;
        //komenda zostanie podpieta pod przycisk dodaj
        private BaseCommand _AddCommand;
        private BaseCommand _UsunCommand;
        //to jest komenda ktora zostanie podpieta pod przycisk sortuj z Generic.xaml
        private BaseCommand _SortCommand;
        //to jest komenda ktora zostanie podpieta pod przycisk szukaj z Generic.xaml
        private BaseCommand _FindCommand;
        private BaseCommand _ModyfikujCommand;
        private BaseCommand _WybierzCommand;
        //tu bedzie przechowywana lista obiektow
        private ObservableCollection<T> _List;
        protected T _WybranyElement;
        #endregion Fields
        #region Properties
        public ICommand ModyfikujCommand //uniwersalne do wszystkich
        {
            get
            {
                if (_ModyfikujCommand == null)
                    _ModyfikujCommand = new BaseCommand(() => modyfikuj());
                return _ModyfikujCommand;
            }
        }
        public ICommand WybierzCommand
        {
            get
            {
                if (_WybierzCommand == null)
                    _WybierzCommand = new BaseCommand(() => select());
                return _WybierzCommand;
            }
        }

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => load());
                return _LoadCommand;
            }
        }
        public ICommand UsunCommand
        {
            get
            {
                if (_UsunCommand == null)
                    _UsunCommand = new BaseCommand(() => delete());
                return _UsunCommand;
            }
        }

        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }

        #endregion Properties
        #region SortAndFind
        // sortowanie i filtrowanie
        //to jest properies do ktorego zapiszemy po jakiej kolumnie sortowac
        public string SortField { get; set; }
        //to jest lista ktora dostarczy danych do Comboboxa po czym sortowac w Generic.xamlu
        public List<String> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }
        //to jest komenda ktora zostanie podpieta pod przycisk sortuj w Generic.xaml
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());
                return _SortCommand;
            }
        }
        //to jest properties do ktorego zostanie zapisana kolumna po ktorej bedziemy wyszukiwac
        public string FindField { get; set; }
        //to jest properties do ktorego zostanie zapisany poczatek frazy ktora bedziemy wyszukiwac
        public string FindTextBox { get; set; }
        //to jest lista ktora dostarczy danych do Comboboxa po czym filtrowac w Generic.xamlu
        public List<String> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        //to jest komenda ktora zostanie podpieta pod przycisk szukaj w Generic.xaml
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());
                return _FindCommand;
            }
        }
        #endregion SortAndFind

        #region Constructor
        public WszystkieVieModel(String displayName)
        {
            //ustawiamy co ma sie wyswietlic w tytule zakladki
            base.DisplayName = displayName;
            //inicjujemy baze danych
            bhpEntities = new BHPEntities2();
        }
        #endregion Constructor
        #region Helpers 
        //Tworzymy funkcje abstrakcyjna
        public abstract void load();
        public abstract void delete();
        public abstract void select();
        public abstract void modyfikuj();

        private void add()
        {
            //Metoda add puszcza komunikat do calej aplikacji wywolaj okno Add
            //do tego uzyjemy Messengera z biblioteki MvvmLight 
            //Ten komunikat zlapie klasa MainWindowViewModel, ktora odpowiada za uruchamianie zakladek
            Messenger.Default.Send(DisplayName + "Add");
        }

        //metody filtrujace i sortujace
        public abstract void Sort();
        public abstract List<String> GetComboboxSortList();
        public abstract void Find();
        public abstract List<String> GetComboboxFindList();
        #endregion Helpers
    }
}

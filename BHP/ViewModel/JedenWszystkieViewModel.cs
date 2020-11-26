using BHP.Helpers;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BHP.ViewModel
{
    public abstract class JedenWszystkieViewModel<J, W> : JedenViewModel<J>
    {
        #region Fields
        // to jest komenda do zaladowania wszystkich pozycji obiektu
        private BaseCommand _LoadListCommand;
        //to jest komenda ktora zostanie podpieta pod przycisk dodaj i bedzie otwierala okno do
        //dodawania elementow pozycji
        private BaseCommand _AddCommand;
        //To jest komenda do wywolywania okienka z dodawaniem pozycji
        private BaseCommand _ShowAddViewCommand;
        // w tym polu bedzie przechowywana lista pozycji
        private ObservableCollection<W> _List;
        //W tym polu bedzie przechowywana nazwa listy pozycji
        private string displayListName;
        #endregion Fields

        #region Properties
        public ICommand LoadListCommand //uniwersalne do wszystkich
        {
            get
            {
                if (_LoadListCommand == null)
                    _LoadListCommand = new BaseCommand(() => LoadList());
                return _LoadListCommand;
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => add());
                return _AddCommand;
            }
        }
        public ObservableCollection<W> List
        {
            get
            {
                if (_List == null)
                    LoadList();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        public ICommand ShowAddViewCommand
        {
            get
            {
                if (_ShowAddViewCommand == null)
                    _ShowAddViewCommand = new BaseCommand(() => ShowAddView());
                return _ShowAddViewCommand;
            }
        }
        #endregion Properties

        #region Constructor
        public JedenWszystkieViewModel(String displayName, String displayListName)
            : base(displayName)
        {
            this.displayListName = displayListName;
        }
        #endregion Constructor
        #region Helpers 
        //To jest metoda, ktora zaladuje liste pozycji faktury
        public abstract void LoadList();
        private void add()
        {
            //Metoda add puszcza komunikat do calej aplikacji wywolaj okno Add
            //do tego uzyjemy Messengera z biblioteki MvvmLight 
            //Ten komunikat zlapie klasa MainWindowViewModel, ktora odpowiada za uruchamianie zakladek
            Messenger.Default.Send(DisplayName + "Add");
        }
        private void ShowAddView()
        {
            Messenger.Default.Send(displayListName + "Add");
        }
        #endregion Helpers
    }
}
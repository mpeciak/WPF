using BHP.Helpers;
using BHP.Model.Entities;
using BHP.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BHP.ViewModel
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        //obiekt odpowiedzisalny za  polaczenie z baza dasnych
        protected BHPEntities2 bhpEntities;
        //obiekt ktory symbolizuje dodawany rekord
        protected T item;
        //komenda do zapisu obiektu
        private BaseCommand _SaveCommand;
        #endregion Fields

        #region Constructor
        public JedenViewModel(String displayName)
        {
            base.DisplayName = displayName;
            bhpEntities = new BHPEntities2();
        }
        #endregion Constructor

        #region Command
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveCommand;

            }

        }
        #endregion Command
        #region Helpers
        public abstract void save();
        private void saveAndClose()
        {
            if (isValid())
            {
                save();
                onRequestClose();
            }
            else ShowMessageBox("Wprowadzono niepoprawne dane");
            //onRequestClose();
        }

        #endregion Helpers

        #region Validation
        public virtual bool isValid()
        {
            return true;
        }
        #endregion Validation
    }
}
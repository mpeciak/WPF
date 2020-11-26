using BHP.Model.Entities;
using BHP.Model.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.ViewModel
{
    public class NowyKontrahentViewModel: JedenViewModel<Kontrahenci>
    {
        #region Constructor
        public NowyKontrahentViewModel()
            : base("Nowy kontrahent")
        {
            item = new Kontrahenci();
            Messenger.Default.Register<KontrahenciForAllView>(this, loadKontrahent);
        }
        #endregion Constructor


        #region Properties
        private bool Edytowanie = false;

        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (value != item.Nazwa)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (value != item.Kod)
                {
                    item.Kod = value;
                    OnPropertyChanged(() => Kod);
                }
            }
        }
        public string NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                if (item.NIP != value)
                    item.NIP = value;
                OnPropertyChanged(() => NIP);
            }
        }
        #endregion Properties
        #region Helpers

        private void loadKontrahent(KontrahenciForAllView kontrahent)
        {       Edytowanie = true;
                item = bhpEntities.Kontrahenci.Where(kon => kon.IdKontrahenta == kontrahent.IdKontrahenta).First();
        }

        public override void save()
        {
            if(!Edytowanie)
            {
                bhpEntities.Kontrahenci.Add(item);
            }
            
            bhpEntities.SaveChanges();
        }
        #endregion Helpers
    }
}


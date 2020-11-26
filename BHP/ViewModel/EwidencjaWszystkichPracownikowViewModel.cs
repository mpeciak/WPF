using BHP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.ViewModel
{
    public class EwidencjaWszystkichPracownikowViewModel : WorkspaceViewModelcs<EwidencjaPracownika>
    {
        #region Constructor
        public EwidencjaWszystkichPracownikowViewModel()
            : base("Ewidencja")
        {
            item = new EwidencjaPracownika();
        }
        #endregion Constructor

        #region Properties
        public long IdPracownika
        {
            get
            {
                return item.IdPracownika;
            }
            set
            {
                if (value != item.IdPracownika)
                {
                    item.IdPracownika = value;
                    OnPropertyChanged(() => IdPracownika);
                }
            }
        }
        public long? IdStanowiska
        {
            get
            {
                return item.IdStanowiska;
            }
            set
            {
                if (value != IdStanowiska)
                {
                    item.IdStanowiska = value;
                    OnPropertyChanged(() => IdStanowiska);
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
                if(value!=IdFirmy)
                {
                    item.IdFirmy = value;
                    OnPropertyChanged(() => IdFirmy);
                }
            }        
        }
        public long? IdOdziezy
        {
            get
            {
                return item.IdOdziezy;
            }
            set
            {
                if(item.IdOdziezy!=value)
                {
                    item.IdOdziezy = value;
                    OnPropertyChanged(() => IdOdziezy);
                }
            }
        }
        public long? IdObowia
        {
            get
            {
                return item.IdObowia;
            }
            set
            {
                if (item.IdObowia != value)
                {
                    item.IdObowia = value;
                    OnPropertyChanged(() => IdObowia);
                }
            }
        }
        public long? IdRozmiaru
        {
            get
            {
                return item.IdRozmaru;
            }
            set
            {
                if (item.IdRozmaru != value)
                {
                    item.IdRozmaru = value;
                    OnPropertyChanged(() => IdRozmiaru);
                }
            }
        }
        public long IdFirmyPioracej
        {
            get
            {
                return item.IdFirmyPioracej;
            }
            set
            {
                if (item.IdFirmyPioracej != value)
                {
                    item.IdFirmyPioracej = value;
                    OnPropertyChanged(() => IdFirmyPioracej);
                }
            }
        }
        public bool? CzyZdane
        {
            get
            {
                return item.CzyZdane;
            }
            set
            {
                if (item.CzyZdane!= value)
                {
                    item.CzyZdane = value;
                    OnPropertyChanged(() => CzyZdane);
                }
            }
        }
        #endregion Properties
        #region Helpers
        public override void save()
        {
            bhpEntities.EwidencjaPracownika.Add(item);
            bhpEntities.SaveChanges();
        }
        #endregion Helpers
    }
}

using BHP.Model.Entities;
using BHP.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BHP.Model.BussnesLogic
{
    public class TowarB : DatabaseClass //bo uzywa bazy danych
    {
        #region Constructor
        public TowarB(BHPEntities2 bhpEntities)
            : base(bhpEntities)
        {
        }
        #endregion Constructor

        #region ViewFunction
        //to jest funkcja ktora bedzie pobierala wszystkie towary do Comboboxa
        public IQueryable<ComboboxKeyAndValue> GetObowieComboboxItems()
        {
            return
                (
                    from towar in BhpEntities.Obowie
                    select new ComboboxKeyAndValue
                    {
                        Key = towar.IdObowia,
                        Value = towar.NazwaObowia
                    }
                ).ToList().AsQueryable();
        }
        public IQueryable<ComboboxKeyAndValue> GetOdziezComboboxItems()
        {
            return
                (
                    from towar in BhpEntities.Odziez
                    select new ComboboxKeyAndValue
                    {
                        Key = towar.IdOdziezy,
                        Value = towar.NazwaOdziezy 
                    }
                ).ToList().AsQueryable();
        }

        #endregion ViewFunction
    }

}

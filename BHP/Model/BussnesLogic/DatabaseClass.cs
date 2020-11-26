using BHP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.Model.BussnesLogic
{
    public class DatabaseClass
    {
        #region Properties
        public BHPEntities2 BhpEntities { get; set; }
        #endregion Properies
        #region Constructor
        public DatabaseClass(BHPEntities2 fakturyEntities)
        {
            this.BhpEntities = fakturyEntities;
        }
        #endregion Constructor
    }
}

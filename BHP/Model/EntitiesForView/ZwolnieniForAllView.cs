using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.Model.EntitiesForView
{
    public class ZwolnieniForAllView
    {   public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }
        public string NazwaFirmy { get; set; }
        public long? idStanowisko { get; set; }
        public DateTime? DataZatrudnienia { get; set; }
        public DateTime? DataZwolnienia { get; set; }
        public string PrzyczynaZwolnienia { get; set; }
        public long? IdPracownika { get; set; }
        public long IdFirma { get; set; }
        public long? IdFirmy { get; set; }


    }
}

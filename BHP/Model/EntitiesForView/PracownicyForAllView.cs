using BHP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.Model.EntitiesForView
{
    public class PracownicyForAllView
    {
        public long IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }
        public string Firma { get; set; }
        public string ObowieNazwa { get; set; }
        public string OdziezNazwa { get; set; }
        public string RozmiarObowia { get; set; }
        public string RozmiarOdziezy { get; set; }
        public DateTime? DataZatrudnienia { get; set; }
        public DateTime? DataZwolnienia { get; set; }
        public string PrzyczynaZwolnienia { get; set; }
        public Pracownicy Pracownik { get; set; }

    }
}
 
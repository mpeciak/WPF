using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.Model.EntitiesForView
{
    public class PozycjeFakturyForAllView
    {
        public int IdPozycjiFaktury { get; set; }
        public string TowarNazwa { get; set; }
        public decimal? Cena { get; set; }
        public decimal? StawkaVAT { get; set; }
        public decimal? Rabat { get; set; }
        //dodac
        public decimal? CenaPoRabacie { get; set; }
        public decimal? CenaBruttoPoRabacie { get; set; }
        public decimal? Ilosc { get; set; }
        //dodac
        public decimal? Wartosc { get; set; }
        public decimal? WartoscBrutto { get; set; }
    }
}

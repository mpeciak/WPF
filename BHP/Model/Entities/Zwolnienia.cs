//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BHP.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zwolnienia
    {
        public int idZwolnienia { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Nullable<System.DateTime> DataZwolnienia { get; set; }
        public Nullable<System.DateTime> DataZatrudnienia { get; set; }
        public Nullable<long> idStanowiska { get; set; }
        public Nullable<long> idFirmy { get; set; }
        public string PrzyczynaZwolnienia { get; set; }
        public Nullable<bool> czyAktywny { get; set; }
    
        public virtual FirmaTS FirmaTS { get; set; }
        public virtual StanowiskoTS StanowiskoTS { get; set; }
    }
}

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
    
    public partial class OperatorzyTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OperatorzyTS()
        {
            this.FirmaPioracaTS = new HashSet<FirmaPioracaTS>();
            this.FirmaPioracaTS1 = new HashSet<FirmaPioracaTS>();
            this.FirmaTS = new HashSet<FirmaTS>();
            this.Obowie = new HashSet<Obowie>();
            this.Odziez = new HashSet<Odziez>();
            this.Rozmiary = new HashSet<Rozmiary>();
            this.StanowiskoTS = new HashSet<StanowiskoTS>();
            this.TypKategoriObowia = new HashSet<TypKategoriObowia>();
            this.TypKategoriTS = new HashSet<TypKategoriTS>();
            this.TypKategoriTS1 = new HashSet<TypKategoriTS>();
            this.WydzialyTS = new HashSet<WydzialyTS>();
        }
    
        public int IdOperatora { get; set; }
        public string KodOperatora { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Nullable<System.DateTime> DataUtworzenia { get; set; }
        public Nullable<System.DateTime> DataUsuniecia { get; set; }
        public string KtoUtworzyl { get; set; }
        public string KtoUsunal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmaPioracaTS> FirmaPioracaTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmaPioracaTS> FirmaPioracaTS1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmaTS> FirmaTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Obowie> Obowie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odziez> Odziez { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rozmiary> Rozmiary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StanowiskoTS> StanowiskoTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypKategoriObowia> TypKategoriObowia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypKategoriTS> TypKategoriTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypKategoriTS> TypKategoriTS1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WydzialyTS> WydzialyTS { get; set; }
    }
}

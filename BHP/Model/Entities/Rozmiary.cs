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
    
    public partial class Rozmiary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rozmiary()
        {
            this.EwidencjaPracownika = new HashSet<EwidencjaPracownika>();
            this.Obowie = new HashSet<Obowie>();
        }
    
        public long IdRozmiaru { get; set; }
        public string Rozmary { get; set; }
        public string JednostaMiary { get; set; }
        public Nullable<long> IdJednostkiMiary { get; set; }
        public Nullable<System.DateTime> DataUtorzenia { get; set; }
        public Nullable<System.DateTime> DataModyfikacji { get; set; }
        public Nullable<System.DateTime> DataUsuniecia { get; set; }
        public string KtoUtorzyl { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public string KtoUsunal { get; set; }
        public Nullable<int> IdOperatora { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EwidencjaPracownika> EwidencjaPracownika { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Obowie> Obowie { get; set; }
        public virtual OperatorzyTS OperatorzyTS { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BitirmeProjesi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Projeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projeler()
        {
            this.Öğrenciler = new HashSet<Öğrenciler>();
        }
    
        public int Proje_Id { get; set; }
        public string ProjeAd { get; set; }
        public string ProjeTanimi { get; set; }
        public Nullable<int> Bölüm_Id { get; set; }
        public Nullable<int> Akademisyen_Id { get; set; }
    
        public virtual Bölümler Bölümler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Öğrenciler> Öğrenciler { get; set; }
    }
}

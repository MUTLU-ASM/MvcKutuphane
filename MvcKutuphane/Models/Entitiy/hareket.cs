//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entitiy
{
    using System;
    using System.Collections.Generic;
    
    public partial class hareket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hareket()
        {
            this.ceza = new HashSet<ceza>();
        }
    
        public int id { get; set; }
        public Nullable<int> kitap { get; set; }
        public Nullable<int> uye { get; set; }
        public Nullable<int> personel { get; set; }
        public Nullable<System.DateTime> alisTarih { get; set; }
        public Nullable<System.DateTime> iadeTarih { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ceza> ceza { get; set; }
        public virtual kitap kitap1 { get; set; }
        public virtual uye uye1 { get; set; }
    }
}

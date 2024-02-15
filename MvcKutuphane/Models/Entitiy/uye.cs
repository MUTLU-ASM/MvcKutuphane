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
    using System.ComponentModel.DataAnnotations;

    public partial class uye
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public uye()
        {
            this.ceza = new HashSet<ceza>();
            this.hareket = new HashSet<hareket>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage ="Ad Bo� Ge�ilemez!")]
        [StringLength(20,ErrorMessage ="En fazla 20 Karakter Girilebilir!")]
        public string ad { get; set; }
        public string soyad { get; set; }
        public string mail { get; set; }
        public string kullaniciad { get; set; }
        [StringLength(10, ErrorMessage = "En fazla 10 Karakter Girilebilir!")]
        public string sifre { get; set; }
        public string fotograf { get; set; }
        public string telefon { get; set; }
        public string okul { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ceza> ceza { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hareket> hareket { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBL3.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhap()
        {
            this.CT_PhieuNhap = new HashSet<CT_PhieuNhap>();
        }
    
        public string MaPhieuNhap { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public string ID_TK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuNhap> CT_PhieuNhap { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}

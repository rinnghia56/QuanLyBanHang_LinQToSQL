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
    
    public partial class CT_PhieuNhap
    {
        public string MaPhieuNhap { get; set; }
        public string MaSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual PhieuNhap PhieuNhap { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyNhaSach1
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuThutien
    {
        public int Id { get; set; }
        public int IdKhachHang { get; set; }
        public Nullable<System.DateTime> NgayThuTien { get; set; }
        public Nullable<double> SoTienThu { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
    }
}

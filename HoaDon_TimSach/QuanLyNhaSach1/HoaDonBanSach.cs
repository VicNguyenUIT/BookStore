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
    
    public partial class HoaDonBanSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonBanSach()
        {
            this.ThongTinHoaDons = new HashSet<ThongTinHoaDon>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> DateOutput { get; set; }
        public int? TongTien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinHoaDon> ThongTinHoaDons { get; set; }
    }
}
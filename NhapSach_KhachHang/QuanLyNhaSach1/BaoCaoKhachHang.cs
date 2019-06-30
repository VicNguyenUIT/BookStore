using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach1
{
    public class BaoCaoKhachHang
    {
        public KhachHang KhachHang { get; set; }
        public int STT { get; set; }
        public Nullable<int> No { get; set; }
        public Nullable<int> Tra { get; set; }
        public int NoCuoi { get; set; }
        public int? NoDau { get; set; }
    }
}

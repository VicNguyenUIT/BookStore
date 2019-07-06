using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyNhaSach1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<SachTon> ListHoaDon = new ObservableCollection<SachTon>();
        ObservableCollection<SachTon> items = new ObservableCollection<SachTon>();
        ObservableCollection<BaoCaoSachTon> ListSachTon = new ObservableCollection<BaoCaoSachTon>();
        ObservableCollection<DSKhachHang> ListKhachHang = new ObservableCollection<DSKhachHang>();
        ObservableCollection<BaoCaoKhachHang> ListbaoCaoCongNo = new ObservableCollection<BaoCaoKhachHang>();

        SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhaSach;Integrated Security=True");

        int Nhaptoithieu_Quydinh = 150;
        int Sachtontoithieu_Nhap_Quydinh = 300;
        int TienNo_Quydinh = 20000;
        int Sachtontoithieu_Ban_Quydinh = 20;
        int isChecked_Phieuthutien_Quydinh = 1;

        int? _tongtien_hoadon = 0;

        string Tensach_Search_Textbox_temp = "";
        string Theloaisach_Search_Textbox_temp = "";
        string Tacgia_Search_Textbox_temp = "";
        string Giaban_Search_Textbox_temp = "";
        int Idsach_Search_temp = 0;

        int IdKhachHang_Temp = 0;

        public MainWindow()
        {
            InitializeComponent();
            Dangnhap dangnhap = new Dangnhap();
            dangnhap.ShowDialog();
            Quydinh_Config();
        }

        #region Funtions

        void Quydinh_Config()
        {
            string  SqlIns = "select * from [Quydinh] where Id = '1' ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(SqlIns, conn);
            SqlDataReader Dr = cmd.ExecuteReader();
            if (Dr.HasRows == true)
            {
                while (Dr.Read())
                {
                    Nhaptoithieu_Quydinh = int.Parse(Dr["Nhaptoithieu"].ToString());
                    Sachtontoithieu_Nhap_Quydinh = int.Parse(Dr["Sachtontoithieu_Nhap"].ToString());
                    Sachtontoithieu_Ban_Quydinh = int.Parse(Dr["Sachtontoithieu_Ban"].ToString());
                    TienNo_Quydinh = int.Parse(Dr["TienNo"].ToString());
                    isChecked_Phieuthutien_Quydinh = int.Parse(Dr["Phieuthutien"].ToString());
                }
            }
            conn.Close();
            Nhaptoithieu_Quydinh_Textbox.Text = Nhaptoithieu_Quydinh.ToString();
            Sachtontoithieu_Nhap_Quydinh_Textbox.Text = Sachtontoithieu_Nhap_Quydinh.ToString();
            Tienno_Quydinh_Textbox.Text = TienNo_Quydinh.ToString();
            Sachtontoithieu_Ban_Quydinh_Textbox.Text = Sachtontoithieu_Ban_Quydinh.ToString();
            if (isChecked_Phieuthutien_Quydinh == 1)
                Phieuthutien_Quydinh_Checkbox.IsChecked = true;
            else Phieuthutien_Quydinh_Checkbox.IsChecked = false;
        }

        void Display_Listview_Sachton(string SqlIns)
        {
            //Refresh listview
            Listview_Search.ItemsSource = null;
            Listview_Search.Items.Clear();
            items.Clear();

            int i = 1;  //STT

            conn.Open();
            SqlCommand cmd = new SqlCommand(SqlIns, conn);
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                int a = int.Parse(Dr["Id"].ToString());
                var x = DataProvider.Ins.DB.ThongTinPhieuNhaps.Where(p => p.IdSach == a);
                foreach (var temp in x)
                {
                    SachTon sachtonitem = new SachTon();
                    sachtonitem.STT = i;
                    sachtonitem.Soluong = int.Parse(Dr["SoLuong"].ToString());
                    sachtonitem.Dongia = (int)temp.DonGiaBan;
                    sachtonitem.Tong = sachtonitem.Dongia * sachtonitem.Soluong;

                    Sach sach = new Sach
                    {
                        Id = int.Parse(Dr["Id"].ToString()),
                        SoLuong = int.Parse(Dr["SoLuong"].ToString()),
                        TacGia = Dr["TacGia"].ToString(),
                        TenSach = Dr["TenSach"].ToString(),
                        TheLoai = Dr["TheLoai"].ToString()
                    };
                    sachtonitem.Sach = sach;
                    items.Add(sachtonitem);
                    i++;
                    break;
                }
            }
            if (i == 1)
                MessageBox.Show("Không có sách!");
            conn.Close();
            Listview_Search.ItemsSource = items;
        }

        int itemp = 1;


        void Display_Listview_HoaDon(string SachInfo, int iSelect)
        {
            conn.Open();
            string SqlIns = "";

            if (iSelect == 1) //Seach theo ID
                SqlIns = "select * from [Sach] where Id = '" + SachInfo + "' ";
            else
                if (iSelect == 2) //Search theo Ten sach
                SqlIns = "select * from [Sach] where TenSach = '" + SachInfo + "' ";
            
            SqlCommand cmd = new SqlCommand(SqlIns, conn);
            SqlDataReader Dr = cmd.ExecuteReader();

            if (Dr.HasRows == true)
            {
                while (Dr.Read())
                {
                   int a = int.Parse(Dr["Id"].ToString());

                    var x = DataProvider.Ins.DB.ThongTinPhieuNhaps.Where(p => p.IdSach == a);
                    foreach (var temp in x)
                    {
                        SachTon sachtonitem = new SachTon();
                        sachtonitem.STT = itemp;
                        sachtonitem.Soluong = int.Parse(Soluong_Bill_Textbox.Text);
                        sachtonitem.Dongia = (int)temp.DonGiaBan;
                        sachtonitem.Tong = sachtonitem.Dongia * sachtonitem.Soluong;

                        _tongtien_hoadon += sachtonitem.Dongia * sachtonitem.Soluong;

                        Sach sach = new Sach
                        {
                            Id = int.Parse(Dr["Id"].ToString()),
                            SoLuong = int.Parse(Dr["SoLuong"].ToString()),
                            TacGia = Dr["TacGia"].ToString(),
                            TenSach = Dr["TenSach"].ToString(),
                            TheLoai = Dr["TheLoai"].ToString()
                        };
                        sachtonitem.Sach = sach;
                        itemp++;
                        ListHoaDon.Add(sachtonitem);
                        break;
                    }
                }
                Listview_Bill.ItemsSource = ListHoaDon;
                Tongtien_Hoadon_Textbox.Text = _tongtien_hoadon.ToString();
            }
            else
                MessageBox.Show("Sách không tồn tại!");
            conn.Close();
        }

        public void Display_DSKhachHang()
        {
            DSKhachhang_Listview.ItemsSource = null;
            DSKhachhang_Listview.Items.Clear();
            ListKhachHang.Clear();

            conn.Open();
            string SqlIns = "select* from[KhachHang]";

            SqlCommand cmd = new SqlCommand(SqlIns, conn);
            SqlDataReader Dr = cmd.ExecuteReader();

            if (Dr.HasRows == true)
            {
                int i = 1;
                while (Dr.Read())
                {
                    KhachHang _khachHang = new KhachHang
                    {
                        Id = int.Parse(Dr["Id"].ToString()),
                        HoTen = Dr["HoTen"].ToString(),
                        Address = Dr["Address"].ToString(),
                        Phone = Dr["Phone"].ToString(),
                        Email = Dr["Email"].ToString(),
                        TienNo = int.Parse(Dr["TienNo"].ToString())
                    };

                    DSKhachHang itemKhachHang = new DSKhachHang
                    {
                        KhachHang = _khachHang,
                        STT = i
                    };

                    i++;
                    ListKhachHang.Add(itemKhachHang);
                }
                DSKhachhang_Listview.ItemsSource = ListKhachHang;
            }
            else
                MessageBox.Show("Không có khách hàng nào!");
            conn.Close();
        }

        public void LuuHoaDon(int iSelect)
        {
            if (CMND_Bill_Textbox.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập CMND Khách hàng!");
                return;
            }

            int a = int.Parse(CMND_Bill_Textbox.Text);
            conn.Open();
            string SqlIns = "select * from [KhachHang] where Id = '" + a + "'";
            int Tienno = 0;

            SqlCommand cmd = new SqlCommand(SqlIns, conn);
            SqlDataReader Dr = cmd.ExecuteReader();

            if (Dr.HasRows == true)
            {
                while (Dr.Read())
                {
                    Tienno = int.Parse(Dr["TienNo"].ToString());
                }

            }
            conn.Close();

            if (Tienno > TienNo_Quydinh)
            {
                MessageBox.Show("Chỉ bán cho Khách Hàng nợ không quá " + TienNo_Quydinh + "đ!");
                return;
            }


            var x = DataProvider.Ins.DB.KhachHangs.Where(p => p.Id == a);
            if (x.Count() > 0)
            {

                if (Listview_Bill.Items.Count > 0)
                {
                    int? Tong_Bill = 0;
                    for (int i = 0; i < Listview_Bill.Items.Count; i++)
                    {
                        Tong_Bill += ((SachTon)Listview_Bill.Items[i]).Tong;
                    }
                    for (int i = 0; i < Listview_Bill.Items.Count; i++)
                    {
                        if ((((SachTon)Listview_Bill.Items[i]).Sach.SoLuong - ((SachTon)Listview_Bill.Items[i]).Soluong) < Sachtontoithieu_Ban_Quydinh)
                        {
                            MessageBox.Show("Sách '" + ((SachTon)Listview_Bill.Items[i]).Sach.TenSach + "' không đủ số lượng tồn kho!");
                            return;
                        }
                    }

                    if(iSelect == 1)
                    {
                        UpdateTienNo(CMND_Bill_Textbox.Text, Tong_Bill);
                        MessageBox.Show("Ghi nợ thành công!");
                    }

                     SqlIns = "SELECT TOP 1 * FROM [HoaDonBanSach] ORDER BY Id DESC";
                    int IdHoadonbansach = 0;
                    int IdThongtinhoadon = 0;

                    if (CreateNextID(SqlIns) != 0)
                    {


                        IdHoadonbansach = CreateNextID(SqlIns);
                        DataProvider.Ins.DB.HoaDonBanSaches.Add(new HoaDonBanSach
                        {
                            Id = IdHoadonbansach,
                            DateOutput = Ngaythangnam_Bill.DisplayDate,
                            TongTien = Tong_Bill
                        });
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi Id!");
                        return;
                    }

                    SqlIns = "SELECT TOP 1 * FROM [ThongTinHoaDon] ORDER BY Id DESC";

                    string _Status = "Tien mat";
                    if (iSelect == 1)
                        _Status = "Ghi no";
                    for (int i = 0; i < Listview_Bill.Items.Count; i++)
                    {
                        if (CreateNextID(SqlIns) != 0)
                        {
                            IdThongtinhoadon = CreateNextID(SqlIns);
                            DataProvider.Ins.DB.ThongTinHoaDons.Add(new ThongTinHoaDon
                            {
                                Id = IdThongtinhoadon,
                                IdHoaDon = IdHoadonbansach,
                                IdSach = ((SachTon)Listview_Bill.Items[i]).Sach.Id,
                                Count = ((SachTon)Listview_Bill.Items[i]).Soluong,
                                IdKhachhang = a,
                                Status = _Status
                            });
                            DataProvider.Ins.DB.SaveChanges();

                            UpdateSoLuongSachDB(((SachTon)Listview_Bill.Items[i]).Sach.Id, -((SachTon)Listview_Bill.Items[i]).Soluong);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi Id!");
                            return;
                        }
                    }
                    Listview_Bill.ItemsSource = null;
                    Listview_Bill.Items.Clear();
                    ListHoaDon.Clear();
                    _tongtien_hoadon = 0;
                    Tongtien_Hoadon_Textbox.Text = _tongtien_hoadon.ToString();
                    MessageBox.Show("Đã lưu!");
                }
                else
                    MessageBox.Show("Vui lòng chọn sách!");
            }
        }

        public int CreateNextID(string SqlIns)
        {
            SqlCommand cmd = new SqlCommand(SqlIns, conn);
            conn.Open();
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            int temp = 0;
            if (myReader.Read())
                temp = int.Parse(myReader["Id"].ToString());
            conn.Close();
            int temp1 = temp + 1;
            return temp1;
        }

        public int StringToInt(string str)
        {
            string temp = string.Empty;
            int val = 0;
            if (str != null)
            {
                for (int i = 0; i < str.Length; i++)
                    if (char.IsDigit(str[i]))
                        temp = temp + str[i];
            }
            else
                return 0;

            if (temp.Length > 0)
                val = int.Parse(temp);

            return val;
        }

        public void UpdateSoLuongSachDB(int IdSach, int? SoLuongMoi)
        {
            string temp = string.Format("select SoLuong from [Sach] where Id = '{0}'", IdSach);
            conn.Open();
            SqlCommand cmd = new SqlCommand(temp, conn);
            SqlDataReader Dr = cmd.ExecuteReader();

            int? a = 0;
            if (Dr.Read())
            {
                a = int.Parse(Dr["SoLuong"].ToString());
                a = a + SoLuongMoi;
            }
            Dr.Close();

            temp = string.Format("UPDATE Sach SET  SoLuong = {0}  WHERE Id = '{1}'", a, IdSach);
            cmd = new SqlCommand(temp, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateTienNo(string IdKhachHang, int? TienNo)
        {
            string temp = string.Format("select TienNo from [KhachHang] where Id = '{0}'", IdKhachHang);
            conn.Open();
            SqlCommand cmd = new SqlCommand(temp, conn);
            SqlDataReader Dr = cmd.ExecuteReader();

            int? a = 0;
            if (Dr.Read())
            {
                a = int.Parse(Dr["TienNo"].ToString());
                a = a + TienNo;
            }
            Dr.Close();

            temp = string.Format("UPDATE KhachHang SET  TienNo = {0}  WHERE Id = '{1}'", a, IdKhachHang);
            cmd = new SqlCommand(temp, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Clear_Import_Textbox()
        {
            Idsach_Import_textbox.Clear();
            Tensach_Import_Texbox.Clear();
            Tacgia_Import_Texbox.Clear();
            Theloai_Import_Textbox.Clear();
            Soluongnhap_Import_Textbox.Clear();
            Dongiaban_Import_Textbox.Clear();
            Dongianhap_Import_Textbox.Clear();
        }

        public void Clear_Them_KhachHang_Textbox ()
        {
            HovaTenKhachhang_Khachhang_Textbox.Clear();
            CMND_Them_Khachhang_Textbox.Clear();
            SDT_Khachhang_Textbox.Clear();
            Email_Khachhang_Textbox.Clear();
            DiaChi_Khachhang_Textbox.Clear();
            ThangNgayNamSinh_Khachhang_Datepicker.Text = "";
        }

        public void Clear_Search_Textbox()
        {
            Theoten_textbox_search.Clear();
            Theotheloai_textbox_search.Clear();
            Theomasach_textbox_search.Clear();
        }

        public void Clear_Search_Textbox_Infor()
        {
            Tensach_Search_Textbox.Clear();
            Theloaisach_Search_Textbox.Clear();
            Tacgia_Search_Textbox.Clear();
            Giaban_Search_Textbox.Clear();
        }

        public void ThemPhieuNhap(int IdSach,int? Count, double? DonGiaNhap, double?  DonGiaBan )
        {
            //Them Phieu nhap
            int IdPhieuNhap = 0;
            string SqlIns = "SELECT TOP 1 * FROM [PhieuNhap] ORDER BY Id DESC";
            if (CreateNextID(SqlIns) > 0)
                IdPhieuNhap = CreateNextID(SqlIns);
            else
            {
                MessageBox.Show("Lỗi ID");
                return;
            }
            DataProvider.Ins.DB.PhieuNhaps.Add(new PhieuNhap { Id = IdPhieuNhap, DateInput = Ngaythang_Import_Textbox.DisplayDate });
            DataProvider.Ins.DB.SaveChanges();

            //Them Thong tin phieu nhap
            int IdThongTinPhieuNhap = 0;
            SqlIns = "SELECT TOP 1 * FROM [ThongTinPhieuNhap] ORDER BY Id DESC";
            if (CreateNextID(SqlIns) > 0)
                IdThongTinPhieuNhap = CreateNextID(SqlIns);
            else
            {
                MessageBox.Show("Lỗi ID");
                return;
            }
            DataProvider.Ins.DB.ThongTinPhieuNhaps.Add(new ThongTinPhieuNhap
            {
                Id = IdThongTinPhieuNhap,
                IdSach = IdSach,
                IdPhieunhap = IdPhieuNhap,
                Count = Count,
                DonGiaNhap = DonGiaNhap,
                DonGiaBan = DonGiaBan
            });
            DataProvider.Ins.DB.SaveChanges();
        }

        int CheckSoluongSach(string IdSach)
        {
            string temp = string.Format("select SoLuong from [Sach] where Id = '{0}'", IdSach);
            conn.Open();
            SqlCommand cmd = new SqlCommand(temp, conn);
            SqlDataReader Dr = cmd.ExecuteReader();

            int? a = 0;
            if (Dr.Read())
            {
                a = int.Parse(Dr["SoLuong"].ToString());
            }
            Dr.Close();
            conn.Close();

            if(a < Sachtontoithieu_Nhap_Quydinh)
            return 1;
            return 0;
        }

        #endregion

        #region Events

        //
        //
        // Hóa đơn EVENT
        //
        //
        private void Them_Button_Bill_Click(object sender, RoutedEventArgs e)
        {
            if (Tensach_Bill_Texbox.Text.Length == 0 && Masach_Textbox_Bill.Text.Length > 0)
            {
                Display_Listview_HoaDon(Masach_Textbox_Bill.Text, 1);
                Masach_Textbox_Bill.Clear();
                return;
            }
            if (Tensach_Bill_Texbox.Text.Length > 0 && Masach_Textbox_Bill.Text.Length == 0)
            {
                Display_Listview_HoaDon(Tensach_Bill_Texbox.Text, 2);
                Tensach_Bill_Texbox.Clear();
                return;
            }
            if (Tensach_Bill_Texbox.Text.Length == 0 && Masach_Textbox_Bill.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Tên hoặc Mã sách!");
            }
        }

        private void Xoa_Button_Bill_Click(object sender, RoutedEventArgs e)
        {
            if (Listview_Bill.SelectedItems.Count > 0)
            {

                _tongtien_hoadon -= ((SachTon)Listview_Bill.SelectedItems[0]).Tong;
                Tongtien_Hoadon_Textbox.Text = _tongtien_hoadon.ToString();
                ListHoaDon.Remove((SachTon)Listview_Bill.SelectedItems[0]);
            }
        }

        private void Tensach_Bill_Texbox_GotFocus(object sender, RoutedEventArgs e)
        {
            Masach_Textbox_Bill.Clear();
        }

        private void Masach_Textbox_Bill_GotFocus(object sender, RoutedEventArgs e)
        {
            Tensach_Bill_Texbox.Clear();
        }

        private void GhiNo_Hoadon_Button_Click(object sender, RoutedEventArgs e)
        {
            LuuHoaDon(1);
        }

        private void Luu_Hoadon_Button_Click(object sender, RoutedEventArgs e)
        {
            LuuHoaDon(0);
        }

        //
        //
        // Tìm Sách EVENT
        //
        //

        private void Tim_Timsach_button_Click(object sender, RoutedEventArgs e)
        {
            if (Theomasach_textbox_search.Text.Length > 0 || Theoten_textbox_search.Text.Length > 0 || Theotheloai_textbox_search.Text.Length > 0)
            {
                if (Theoten_textbox_search.Text.Length > 0)
                {
                    string str = string.Format("select * from [Sach] where TenSach like N'%{0}%' ", Theoten_textbox_search.Text);
                    Display_Listview_Sachton(str);
                }
                if (Theomasach_textbox_search.Text.Length > 0)
                {
                    string str = string.Format("select * from [Sach] where Id like N'%{0}%' ", Theomasach_textbox_search.Text);
                    Display_Listview_Sachton(str);
                }
                if (Theotheloai_textbox_search.Text.Length > 0)
                {
                    string str = string.Format("select * from [Sach] where TheLoai like N'%{0}%' ", Theotheloai_textbox_search.Text);
                    Display_Listview_Sachton(str);
                }
                Clear_Search_Textbox();
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!");
        }



        private void Sua_Timsach_Texbox_Click(object sender, RoutedEventArgs e)
        {
            if (Listview_Search.SelectedItems.Count > 0)
            {
                if (Tensach_Search_Textbox_temp != Tensach_Search_Textbox.Text
                    || Theloaisach_Search_Textbox_temp != Theloaisach_Search_Textbox.Text
                    || Tacgia_Search_Textbox_temp != Tacgia_Search_Textbox.Text
                    || Giaban_Search_Textbox_temp != Giaban_Search_Textbox.Text)
                {
                    string strTemp = " UPDATE Sach SET TenSach = @TensachTextbox, TacGia = @TacgiaTextbox, TheLoai = @TheloaisachTextbox WHERE Id = " + Idsach_Search_temp;
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(strTemp, conn))
                    {
                        cmd.Parameters.AddWithValue("@TensachTextbox", Tensach_Search_Textbox.Text);
                        cmd.Parameters.AddWithValue("@TacgiaTextbox", Tacgia_Search_Textbox.Text);
                        cmd.Parameters.AddWithValue("@TheloaisachTextbox", Theloaisach_Search_Textbox.Text);
                        cmd.ExecuteNonQuery();
                    }

                    strTemp = string.Format("UPDATE ThongTinPhieuNhap SET  DonGiaBan = {0}  WHERE IdSach = '{1}'", Giaban_Search_Textbox.Text, Idsach_Search_temp);
                    SqlCommand cmd1 = new SqlCommand(strTemp, conn);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    string SqlIns = "select * from [Sach]";
                    Display_Listview_Sachton(SqlIns);
                }
                else
                    MessageBox.Show("Thông tin trùng!");
            }
            else
                MessageBox.Show("Vui lòng chọn sách!");
        }

        private void Xoa_Search_Button_Click(object sender, RoutedEventArgs e)
        {

            int idPhieunhapTemp = 0;
            if (Listview_Search.SelectedItems.Count > 0)
            {
                var x = DataProvider.Ins.DB.ThongTinPhieuNhaps.Where(p => p.IdSach == Idsach_Search_temp);
                foreach (var temp in x)
                {
                    var y = DataProvider.Ins.DB.PhieuNhaps.Where(p => p.Id == temp.IdPhieunhap);
                    foreach (var temp1 in y)
                    {
                        idPhieunhapTemp = temp1.Id;
                    }
                }

                if (DataProvider.Ins.DB.ThongTinHoaDons.Where(p => p.IdSach == Idsach_Search_temp).Count() > 0)
                {
                    MessageBox.Show("Không thể xóa vì sách đã có trong Hóa đơn ", "Caution!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }



                string strTemp = " DELETE FROM ThongTinPhieuNhap  WHERE IdSach = " + Idsach_Search_temp;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(strTemp, conn))
                {
                    cmd.ExecuteNonQuery();
                }


                strTemp = " DELETE FROM PhieuNhap  WHERE Id = " + idPhieunhapTemp;
                using (SqlCommand cmd = new SqlCommand(strTemp, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                strTemp = " DELETE FROM Sach  WHERE Id = " + Idsach_Search_temp;
                using (SqlCommand cmd = new SqlCommand(strTemp, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                conn.Close();

                string SqlIns = "select * from [Sach]";
                Display_Listview_Sachton(SqlIns);
                Clear_Search_Textbox_Infor();
            }
            else
                MessageBox.Show("Vui lòng chọn sách!");

        }

        //
        //
        // Nhập Sách EVENT
        //
        //

        private void Nhap_Nhapsach_button_Click(object sender, RoutedEventArgs e)
        {
            //Nhap sach co san
            if (Checkbox_Import.IsChecked == true)
            {
                if (Idsach_Import_textbox.Text.Length > 0 && Soluongnhap_Import_Textbox.Text.Length > 0)
                {
                    if (int.Parse(Soluongnhap_Import_Textbox.Text) < Nhaptoithieu_Quydinh)
                    {
                        MessageBox.Show("Số lượng nhập tối thiểu là: " + Nhaptoithieu_Quydinh, "Caution!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    if (MessageBox.Show("Bạn có muốn thêm " + Soluongnhap_Import_Textbox.Text + " sách vào Sách có Mã: " + Idsach_Import_textbox.Text + "?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if(CheckSoluongSach(Idsach_Import_textbox.Text) == 0)
                        {
                            MessageBox.Show("Chỉ nhập các đầu sách có lượng tồn ít hơn: " + Sachtontoithieu_Nhap_Quydinh, "Caution!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        int a = int.Parse(Idsach_Import_textbox.Text);
                        var x = DataProvider.Ins.DB.ThongTinPhieuNhaps.Where(p => p.IdSach == a);
                        if (x.Count() > 0)
                        {
                            double? _Dongianhap = 0;
                            double? _Dongiaban = 0;
                            foreach (var temp in x)
                            {
                                _Dongianhap = temp.DonGiaNhap;
                                _Dongiaban = temp.DonGiaBan;
                                break;
                            }
                            ThemPhieuNhap(int.Parse(Idsach_Import_textbox.Text), int.Parse(Soluongnhap_Import_Textbox.Text), _Dongianhap, _Dongiaban);
                        }
                        UpdateSoLuongSachDB(int.Parse(Idsach_Import_textbox.Text), int.Parse(Soluongnhap_Import_Textbox.Text));
                        return;
                    }
                    else return;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }
            }

            //Nhap sach chua co trong DB
            if (Ngaythang_Import_Textbox.DisplayDate.ToString().Length > 0 && Tensach_Import_Texbox.Text.Length > 0 && Idsach_Import_textbox.Text.Length > 0 && Dongianhap_Import_Textbox.Text.Length > 0 && Soluongnhap_Import_Textbox.Text.Length > 0)
            {
                if (int.Parse(Soluongnhap_Import_Textbox.Text) < Nhaptoithieu_Quydinh)
                {
                    MessageBox.Show("Số lượng nhập tối thiểu là: " + Nhaptoithieu_Quydinh, "Caution!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int a = int.Parse(Idsach_Import_textbox.Text);
                var x = DataProvider.Ins.DB.Saches.Where(p => p.Id == a);
                if (x == null || x.Count() == 0)    //Kiem tra sach trung
                {
                    //Them sach
                    Sach sach = new Sach
                    {
                        Id = int.Parse(Idsach_Import_textbox.Text),
                        TenSach = Tensach_Import_Texbox.Text,
                        TacGia = Tacgia_Import_Texbox.Text,
                        TheLoai = Theloai_Import_Textbox.Text,
                        SoLuong = int.Parse(Soluongnhap_Import_Textbox.Text)
                    };
                    DataProvider.Ins.DB.Saches.Add(sach);
                    DataProvider.Ins.DB.SaveChanges();

                    //Them Phieu nhap + Thong tin phieu nhap
                    ThemPhieuNhap(int.Parse(Idsach_Import_textbox.Text), int.Parse(Soluongnhap_Import_Textbox.Text), int.Parse(Dongianhap_Import_Textbox.Text), int.Parse(Dongiaban_Import_Textbox.Text));
                }

                //Da co sach trong DB
                else if (x.Count() >= 1)
                {
                    MessageBox.Show("Sách trùng!");
                    return;
                }

                //Kiem tra them sach thanh cong chua
                a = int.Parse(Idsach_Import_textbox.Text);
                var temp = DataProvider.Ins.DB.ThongTinPhieuNhaps.Where(p => p.IdSach == a);
                if (temp.Count() > 0)
                {
                    MessageBox.Show("Thêm sách thành công!");
                    Clear_Import_Textbox();
                }
                else MessageBox.Show("Không thành công!");
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");    //Thieu thong tin

        }

        //
        //
        // Khách hàng EVENT
        //
        //

        private void Them_Khachhang_Button_Click(object sender, RoutedEventArgs e)
        {
            if (HovaTenKhachhang_Khachhang_Textbox.Text.Length > 0 && CMND_Them_Khachhang_Textbox.Text.Length > 0 && SDT_Khachhang_Textbox.Text.Length > 0 && Email_Khachhang_Textbox.Text.Length > 0 && DiaChi_Khachhang_Textbox.Text.Length > 0 && ThangNgayNamSinh_Khachhang_Datepicker.Text.Length > 0)
            {
                int CMND = int.Parse(CMND_Them_Khachhang_Textbox.Text);
                var x = DataProvider.Ins.DB.KhachHangs.Where(p => p.Id == CMND);
                if (x == null || x.Count() == 0)    //Kiem tra Khach hang trung
                {
                    //Them Khach hang
                    KhachHang Khachhang = new KhachHang
                    {
                        Id = int.Parse(CMND_Them_Khachhang_Textbox.Text),
                        HoTen = HovaTenKhachhang_Khachhang_Textbox.Text,
                        Phone = SDT_Khachhang_Textbox.Text,
                        Address = DiaChi_Khachhang_Textbox.Text,
                        Email = Email_Khachhang_Textbox.Text,
                        TienNo = 0
                    };
                    DataProvider.Ins.DB.KhachHangs.Add(Khachhang);
                    DataProvider.Ins.DB.SaveChanges();

                }

                //Da co Khach hang trong DB
                else if (x.Count() >= 1)
                {
                    MessageBox.Show("Khách hàng trùng!");
                    return;
                }

                //Kiem tra them Khach hang thanh cong chua
                var temp = DataProvider.Ins.DB.KhachHangs.Where(p => p.Id == CMND);
                if (temp.Count() > 0)
                {
                    MessageBox.Show("Thêm Khách hàng thành công!");
                    Clear_Them_KhachHang_Textbox();
                }
                else MessageBox.Show("Không thành công!");
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
        }


        private void Sua_DanhsachKH_Khachhang_Button_Click(object sender, RoutedEventArgs e)
        {
            if (DSKhachhang_Listview.SelectedItems.Count > 0)
            {
                string strTemp = " UPDATE KhachHang SET HoTen = @TenKhachHang, Address = @Address, Phone = @Phone, Email = @Email  WHERE Id = " + IdKhachHang_Temp;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(strTemp, conn))
                {
                    cmd.Parameters.AddWithValue("@TenKhachHang", HoTen_DSKhachHang_KhachHang_Textbox.Text);
                    cmd.Parameters.AddWithValue("@Address", DiaChi_DSKhachHang_KhachHang_Textbox.Text);
                    cmd.Parameters.AddWithValue("@Phone", SDT_DSKhachHang_KhachHang_Textbox.Text);
                    cmd.Parameters.AddWithValue("@Email", Email_DSKhachHang_KhachHang_Textbox.Text);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                Display_DSKhachHang();
                MessageBox.Show("Xong!");
            }
            else
                MessageBox.Show("Vui lòng chọn Khách Hàng!");
        }

        private void Thutien_PhieuthuTien_Khachhang_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CMND_PhieuThuTien_Textbox.Text.Length > 0)
            {
                if (SoTienThu_PhieuThuTien_KhachHang_Textbox.Text.Length > 0)
                {
                    if (isChecked_Phieuthutien_Quydinh == 1)
                    {
                        string temp = string.Format("select TienNo from [KhachHang] where Id = '{0}'", CMND_PhieuThuTien_Textbox.Text);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(temp, conn);
                        SqlDataReader Dr = cmd.ExecuteReader();

                        int? a = 0;
                        if (Dr.Read())
                        {
                            a = int.Parse(Dr["TienNo"].ToString());
                        }
                        conn.Close();

                        if ((a - int.Parse(SoTienThu_PhieuThuTien_KhachHang_Textbox.Text)) < 0)
                        {
                            MessageBox.Show("Không được thu số tiền lớn hơn tiền nợ!");
                            Dr.Close();
                            return;
                        }
                    }

                    UpdateTienNo(CMND_PhieuThuTien_Textbox.Text, -int.Parse(SoTienThu_PhieuThuTien_KhachHang_Textbox.Text));
                    string SqlIns = "SELECT TOP 1 * FROM [PhieuThutien] ORDER BY Id DESC";
                    DataProvider.Ins.DB.PhieuThutiens.Add(new PhieuThutien
                    {
                        Id = CreateNextID(SqlIns),
                        IdKhachHang = int.Parse(CMND_PhieuThuTien_Textbox.Text),
                        NgayThuTien = Ngaythangnam_Bill.DisplayDate,
                        SoTienThu = int.Parse(SoTienThu_PhieuThuTien_KhachHang_Textbox.Text)
                    });
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Đã thu!");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng số tiền!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập CMND Khách hàng!");
            }
        }

        //
        //
        // Báo cáo tháng EVENT
        //
        //

        private void Tim_Baocaoton_Report_Click(object sender, RoutedEventArgs e)
        {
            int IdTemp = int.Parse(Nhapthang_Baocaoton_Textbox.Text + Nhapnam_Baocaoton_Textbox.Text);
            var x = DataProvider.Ins.DB.BaoCaoThangs.Where(p => p.Id == IdTemp);
            if (x.Count() > 0)
            {
                Listview_baocaoton.ItemsSource = null;
                Listview_baocaoton.Items.Clear();
                ListSachTon.Clear();

                int i = 1;
                foreach (var temp in x)
                {
                    var y = DataProvider.Ins.DB.ThongTinBaoCaoThangs.Where(p => p.IdBaoCao == temp.Id);
                    foreach (var temp1 in y)
                    {
                        BaoCaoSachTon SachTon = new BaoCaoSachTon();
                        SachTon.IdSach = temp1.IdSach.ToString();
                        SachTon.Tensach = temp1.TenSach;
                        SachTon.STT = i;
                        SachTon.TonDau = temp1.Tondau;
                        SachTon.TonCuoi = temp1.Toncuoi;
                        SachTon.Soluongban = temp1.Soluongban;
                        SachTon.Soluongnhap = temp1.Soluongnhap;

                        ListSachTon.Add(SachTon);
                        Listview_baocaoton.ItemsSource = ListSachTon;
                        i++;
                    }
                }
            }

            else MessageBox.Show("Không có dữ liệu!");
        }

        private void Lapbaocao_Report_Click(object sender, RoutedEventArgs e)
        {
            if (List_Lapbaocaoton.Items.Count > 0)
            {
                string IdTemp = Ngaythangnam_Bill.DisplayDate.Month.ToString() + Ngaythangnam_Bill.DisplayDate.Year.ToString();
                int a = int.Parse(IdTemp);
                var x = DataProvider.Ins.DB.BaoCaoThangs.Where(p => p.Id == a);
                if (x == null || x.Count() == 0)
                {

                    DataProvider.Ins.DB.BaoCaoThangs.Add(new BaoCaoThang
                    {
                        Id = int.Parse(IdTemp),
                        DateOutput = Ngaythangnam_Bill.DisplayDate
                    });
                    DataProvider.Ins.DB.SaveChanges();

                    for (int i = 0; i < List_Lapbaocaoton.Items.Count; i++)
                    {
                        string Sqlins = "SELECT TOP 1 * FROM [ThongTinBaoCaoThang] ORDER BY Id DESC";
                        BaoCaoSachTon SachTon = (BaoCaoSachTon)List_Lapbaocaoton.Items[i];
                        DataProvider.Ins.DB.ThongTinBaoCaoThangs.Add(new ThongTinBaoCaoThang
                        {
                            Id = CreateNextID(Sqlins),
                            IdBaoCao = int.Parse(IdTemp),
                            IdSach = int.Parse(SachTon.IdSach),
                            TenSach = SachTon.Tensach,
                            Tondau = SachTon.TonDau,
                            Toncuoi = SachTon.TonCuoi,
                            Soluongban = SachTon.Soluongban,
                            Soluongnhap = SachTon.Soluongnhap
                        });
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }
                else
                if (MessageBox.Show("Đã có báo cáo tháng này. Bạn có muốn UPDATE?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes && List_Lapbaocaoton.Items.Count > 0)
                {
                    conn.Open();
                    for (int i = 0; i < List_Lapbaocaoton.Items.Count; i++)
                    {
                        BaoCaoSachTon SachTon = (BaoCaoSachTon)List_Lapbaocaoton.Items[i];
                        string Sqlins = string.Format("UPDATE ThongTinBaoCaoThang SET  Soluongban = {0}, Soluongnhap ={1}, Toncuoi ={2}  WHERE IdSach = '{3}'", SachTon.Soluongban, SachTon.Soluongnhap, SachTon.TonCuoi, SachTon.IdSach);
                        using (SqlCommand cmd = new SqlCommand(Sqlins, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
                else return;
            }
            else
            {
                MessageBox.Show("Không có gì để lưu!");
                return;
            }

        }

        private void Thongke_Baocaocongno_Report_Click(object sender, RoutedEventArgs e)
        {
            Listview_baocaocongno.ItemsSource = null;
            Listview_baocaocongno.Items.Clear();
            ListbaoCaoCongNo.Clear();

            int i = 1;
            var x = DataProvider.Ins.DB.KhachHangs;
            foreach (var temp in x)
            {
                int? Tienno = 0;
                int? Tientra = 0;
                var y = DataProvider.Ins.DB.ThongTinHoaDons.Where(p => p.IdKhachhang == temp.Id);
                foreach (var temp1 in y)
                {
                    var z = DataProvider.Ins.DB.HoaDonBanSaches.Where(p => p.Id == temp1.IdHoaDon );
                    foreach (var temp2 in z)
                    {
                        if (temp1.Status == "Ghi no")
                        {
                            Tienno += temp2.TongTien;
                        }
                    }
                }
                var o = DataProvider.Ins.DB.PhieuThutiens.Where(p => p.IdKhachHang == temp.Id);
                foreach (var temp3 in o)
                {
                    Tientra += (int)temp3.SoTienThu;
                }

                BaoCaoKhachHang baoCaoKhachHang = new BaoCaoKhachHang
                {
                    KhachHang = temp,
                    STT = i,
                    NoCuoi = (int)temp.TienNo,
                    No = Tienno,
                    Tra = Tientra,
                    NoDau = (int)temp.TienNo - (Tienno - Tientra)
                };

                i++;
                ListbaoCaoCongNo.Add(baoCaoKhachHang);
            }

            Listview_baocaocongno.ItemsSource = ListbaoCaoCongNo;
        }


        private void Thongke_Lapbaocaothang_Report_Click(object sender, RoutedEventArgs e)
        {
            List_Lapbaocaoton.ItemsSource = null;
            List_Lapbaocaoton.Items.Clear();
            ListSachTon.Clear();

            conn.Open();
            string SqlIns = "select * from [Sach]";
            SqlCommand cmd = new SqlCommand(SqlIns, conn);
            SqlDataReader Dr = cmd.ExecuteReader();
            if (Dr.HasRows == true)
            {
                int i = 1;
                while (Dr.Read())
                {
                    int? Soluongban = 0;
                    int? Soluongnhap = 0;
                    int a = int.Parse(Dr["Id"].ToString());
                    var x = DataProvider.Ins.DB.ThongTinHoaDons.Where(p => p.IdSach == a);
                    foreach (var temp in x)
                    {
                        var y = DataProvider.Ins.DB.HoaDonBanSaches.Where(p => p.Id == temp.IdHoaDon && p.DateOutput.Value.Month.ToString() == Ngaythangnam_Bill.DisplayDate.Month.ToString() && p.DateOutput.Value.Year.ToString() == Ngaythangnam_Bill.DisplayDate.Year.ToString());
                        foreach (var temp1 in y)
                        {
                            Soluongban = temp.Count + Soluongban;
                        }
                    }

                    var z = DataProvider.Ins.DB.ThongTinPhieuNhaps.Where(p => p.IdSach == a);
                    foreach (var temp in z)
                    {

                        var y = DataProvider.Ins.DB.PhieuNhaps.Where(p => p.Id == temp.IdPhieunhap && p.DateInput.Value.Month.ToString() == Ngaythangnam_Bill.DisplayDate.Month.ToString() && p.DateInput.Value.Year.ToString() == Ngaythangnam_Bill.DisplayDate.Year.ToString());
                        foreach (var temp1 in y)
                        {
                            Soluongnhap += temp.Count;
                        }
                    }

                    BaoCaoSachTon baoCaoSachTon = new BaoCaoSachTon
                    {
                        STT = i,
                        Tensach = Dr["TenSach"].ToString(),
                        IdSach = Dr["Id"].ToString(),
                        Soluongnhap = Soluongnhap,
                        Soluongban = Soluongban,
                        TonDau = int.Parse(Dr["SoLuong"].ToString()) - (Soluongnhap - Soluongban),
                        TonCuoi = int.Parse(Dr["SoLuong"].ToString()),
                    };
                    i++;
                    ListSachTon.Add(baoCaoSachTon);
                    List_Lapbaocaoton.ItemsSource = ListSachTon;
                }

            }

            conn.Close();
        }

        //
        //
        // Quy định EVENT
        //
        //

        private void Luu_Nhapsach_Quydinh_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();

            string Sqlins = string.Format("UPDATE Quydinh SET  Nhaptoithieu = {0}, Sachtontoithieu_Nhap ={1}  WHERE Id = '{2}'", int.Parse(Nhaptoithieu_Quydinh_Textbox.Text), int.Parse(Sachtontoithieu_Nhap_Quydinh_Textbox.Text), 1);
            using (SqlCommand cmd = new SqlCommand(Sqlins, conn))
            {
                cmd.ExecuteNonQuery();
            }

            conn.Close();

            Quydinh_Config();
            MessageBox.Show("Đã lưu!");
        }

        private void Luu_Hoadon_Quydinh_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();

            string Sqlins = string.Format("UPDATE Quydinh SET  Sachtontoithieu_Ban = {0}, TienNo ={1}  WHERE Id = '{2}'", int.Parse(Sachtontoithieu_Ban_Quydinh_Textbox.Text), int.Parse(Tienno_Quydinh_Textbox.Text), 1);
            using (SqlCommand cmd = new SqlCommand(Sqlins, conn))
            {
                cmd.ExecuteNonQuery();
            }

            conn.Close();

            Quydinh_Config();
            MessageBox.Show("Đã lưu!");
        }



        private void Phieuthutien_Quydinh_Checkbox_Click(object sender, RoutedEventArgs e)
        {
            int temp = 0;
            if (Phieuthutien_Quydinh_Checkbox.IsChecked == true)
                temp = 1;

            conn.Open();
            string Sqlins = string.Format("UPDATE Quydinh SET  Phieuthutien = {0}  WHERE Id = '{1}'", temp, 1);
            using (SqlCommand cmd = new SqlCommand(Sqlins, conn))
            {
                cmd.ExecuteNonQuery();
            }

            conn.Close();

            Quydinh_Config();
        }

        //
        //
        // Các events phụ 
        //
        //

        private void Hoadon_button_Click(object sender, RoutedEventArgs e)
        {
            Hoadon_button.Background = Brushes.Orange;
            Timsach_button.Background = Brushes.DarkBlue;
            Khachhang_button.Background = Brushes.DarkBlue;
            Nhapsach_button.Background = Brushes.DarkBlue;
            Baocaothang_button.Background = Brushes.DarkBlue;
            Quydinh_button.Background = Brushes.DarkBlue;

            Bill.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Hidden;
            Money.Visibility = Visibility.Hidden;
            Import.Visibility = Visibility.Hidden;
            Report.Visibility = Visibility.Hidden;
            Rule.Visibility = Visibility.Hidden;
        }

        private void Timsach_button_Click(object sender, RoutedEventArgs e)
        {
            Hoadon_button.Background = Brushes.DarkBlue;
            Timsach_button.Background = Brushes.Orange;
            Khachhang_button.Background = Brushes.DarkBlue;
            Nhapsach_button.Background = Brushes.DarkBlue;
            Baocaothang_button.Background = Brushes.DarkBlue;
            Quydinh_button.Background = Brushes.DarkBlue;

            Bill.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Visible;
            Money.Visibility = Visibility.Hidden;
            Import.Visibility = Visibility.Hidden;
            Report.Visibility = Visibility.Hidden;
            Rule.Visibility = Visibility.Hidden;

        }

        private void Khachhang_button_Click(object sender, RoutedEventArgs e)
        {
            Hoadon_button.Background = Brushes.DarkBlue;
            Timsach_button.Background = Brushes.DarkBlue;
            Khachhang_button.Background = Brushes.Orange;
            Nhapsach_button.Background = Brushes.DarkBlue;
            Baocaothang_button.Background = Brushes.DarkBlue;
            Quydinh_button.Background = Brushes.DarkBlue;

            Bill.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            Money.Visibility = Visibility.Visible;
            Import.Visibility = Visibility.Hidden;
            Report.Visibility = Visibility.Hidden;
            Rule.Visibility = Visibility.Hidden;

        }

        private void Nhapsach_button_Click(object sender, RoutedEventArgs e)
        {
            Hoadon_button.Background = Brushes.DarkBlue;
            Timsach_button.Background = Brushes.DarkBlue;
            Khachhang_button.Background = Brushes.DarkBlue;
            Nhapsach_button.Background = Brushes.Orange;
            Baocaothang_button.Background = Brushes.DarkBlue;
            Quydinh_button.Background = Brushes.DarkBlue;

            Bill.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            Money.Visibility = Visibility.Hidden;
            Import.Visibility = Visibility.Visible;
            Report.Visibility = Visibility.Hidden;
            Rule.Visibility = Visibility.Hidden;
        }

        private void Baocaothang_button_Click(object sender, RoutedEventArgs e)
        {
            Hoadon_button.Background = Brushes.DarkBlue;
            Timsach_button.Background = Brushes.DarkBlue;
            Khachhang_button.Background = Brushes.DarkBlue;
            Nhapsach_button.Background = Brushes.DarkBlue;
            Baocaothang_button.Background = Brushes.Orange;
            Quydinh_button.Background = Brushes.DarkBlue;

            Bill.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            Money.Visibility = Visibility.Hidden;
            Import.Visibility = Visibility.Hidden;
            Report.Visibility = Visibility.Visible;
            Rule.Visibility = Visibility.Hidden;
        }

        private void Quydinh_button_Click(object sender, RoutedEventArgs e)
        {
            Hoadon_button.Background = Brushes.DarkBlue;
            Timsach_button.Background = Brushes.DarkBlue;
            Khachhang_button.Background = Brushes.DarkBlue;
            Nhapsach_button.Background = Brushes.DarkBlue;
            Baocaothang_button.Background = Brushes.DarkBlue;
            Quydinh_button.Background = Brushes.Orange;

            Bill.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            Money.Visibility = Visibility.Hidden;
            Import.Visibility = Visibility.Hidden;
            Report.Visibility = Visibility.Hidden;
            Rule.Visibility = Visibility.Visible;
        }

        private void Theoten_button_search_Click(object sender, RoutedEventArgs e)
        {
            Theoten_textbox_search.Visibility = Visibility.Visible;
            Theomasach_textbox_search.Visibility = Visibility.Hidden;
            Theotheloai_textbox_search.Visibility = Visibility.Hidden;
            Tim_Timsach_Button.Visibility = Visibility.Visible;

            Theoten_button_search.Background = Brushes.GreenYellow;
            Theotheloai_button_search.Background = Brushes.LightGray;
            Theomasach_button_search.Background = Brushes.LightGray;
            Tatcasach_button_search.Background = Brushes.LightGray;
            Clear_Search_Textbox();
        }

        private void Theotheloai_button_search_Click(object sender, RoutedEventArgs e)
        {
            Theoten_textbox_search.Visibility = Visibility.Hidden;
            Theomasach_textbox_search.Visibility = Visibility.Hidden;
            Theotheloai_textbox_search.Visibility = Visibility.Visible;
            Tim_Timsach_Button.Visibility = Visibility.Visible;

            Theoten_button_search.Background = Brushes.LightGray;
            Theotheloai_button_search.Background = Brushes.GreenYellow;
            Theomasach_button_search.Background = Brushes.LightGray;
            Tatcasach_button_search.Background = Brushes.LightGray;
            Clear_Search_Textbox();
        }

        private void Theomasach_button_search_Click(object sender, RoutedEventArgs e)
        {
            Theoten_textbox_search.Visibility = Visibility.Hidden;
            Theomasach_textbox_search.Visibility = Visibility.Visible;
            Theotheloai_textbox_search.Visibility = Visibility.Hidden;
            Tim_Timsach_Button.Visibility = Visibility.Visible;

            Theoten_button_search.Background = Brushes.LightGray;
            Theotheloai_button_search.Background = Brushes.LightGray;
            Theomasach_button_search.Background = Brushes.GreenYellow;
            Tatcasach_button_search.Background = Brushes.LightGray;
            Clear_Search_Textbox();
        }

        private void Tatcasach_button_search_Click(object sender, RoutedEventArgs e)
        {
            Theoten_textbox_search.Visibility = Visibility.Hidden;
            Theomasach_textbox_search.Visibility = Visibility.Hidden;
            Theotheloai_textbox_search.Visibility = Visibility.Hidden;
            Tim_Timsach_Button.Visibility = Visibility.Hidden;

            Theoten_button_search.Background = Brushes.LightGray;
            Theotheloai_button_search.Background = Brushes.LightGray;
            Theomasach_button_search.Background = Brushes.LightGray;
            Tatcasach_button_search.Background = Brushes.GreenYellow;


            string SqlIns = "select * from [Sach]";
            Display_Listview_Sachton(SqlIns);
        }

        private void Lapbaocaothang_Baocaothang_Button_Click(object sender, RoutedEventArgs e)
        {
            Lapbaocaothang_Baocaothang_Button.Background = Brushes.GreenYellow;
            Baocaoton_button.Background = Brushes.LightGray;
            Baocaocongno.Background = Brushes.LightGray;

            Lapbaocaothang_Baocaothang_Grid.Visibility = Visibility.Visible;
            Baocaoton_Baocaothang_Grid.Visibility = Visibility.Hidden;
            Baocaocongno_Baocaothang_Grid.Visibility = Visibility.Hidden;
        }

        private void Baocaoton_button_Click(object sender, RoutedEventArgs e)
        {
            Baocaoton_button.Background = Brushes.GreenYellow;
            Baocaocongno.Background = Brushes.LightGray;
            Lapbaocaothang_Baocaothang_Button.Background = Brushes.LightGray;

            Lapbaocaothang_Baocaothang_Grid.Visibility = Visibility.Hidden;
            Baocaoton_Baocaothang_Grid.Visibility = Visibility.Visible;
            Baocaocongno_Baocaothang_Grid.Visibility = Visibility.Hidden;
        }

        private void Baocaocongno_Click(object sender, RoutedEventArgs e)
        {
            Baocaoton_button.Background = Brushes.LightGray;
            Baocaocongno.Background = Brushes.GreenYellow;
            Lapbaocaothang_Baocaothang_Button.Background = Brushes.LightGray;

            Baocaoton_Baocaothang_Grid.Visibility = Visibility.Hidden;
            Lapbaocaothang_Baocaothang_Grid.Visibility = Visibility.Hidden;
            Baocaocongno_Baocaothang_Grid.Visibility = Visibility.Visible;
        }

        private void Rule_Hoadon_Click(object sender, RoutedEventArgs e)
        {
            Rule_Nhapsach.Background = Brushes.LightGray;
            Rule_Hoadon.Background = Brushes.GreenYellow;
            Rule_Phieuthutien.Background = Brushes.LightGray;

            Nhapsach_Quydinh_Grid.Visibility = Visibility.Hidden;
            HoaDon_Quydinh_Grid.Visibility = Visibility.Visible;
            Phieuthutien_Quydinh_Grid.Visibility = Visibility.Hidden;
        }

        private void Rule_Phieuthutien_Click(object sender, RoutedEventArgs e)
        {
            Rule_Nhapsach.Background = Brushes.LightGray;
            Rule_Hoadon.Background = Brushes.LightGray;
            Rule_Phieuthutien.Background = Brushes.GreenYellow;

            Nhapsach_Quydinh_Grid.Visibility = Visibility.Hidden;
            HoaDon_Quydinh_Grid.Visibility = Visibility.Hidden;
            Phieuthutien_Quydinh_Grid.Visibility = Visibility.Visible;
        }

        private void Rule_Nhapsach_Click(object sender, RoutedEventArgs e)
        {
            Rule_Nhapsach.Background = Brushes.GreenYellow;
            Rule_Hoadon.Background = Brushes.LightGray;
            Rule_Phieuthutien.Background = Brushes.LightGray;

            Nhapsach_Quydinh_Grid.Visibility = Visibility.Visible;
            HoaDon_Quydinh_Grid.Visibility = Visibility.Hidden;
            Phieuthutien_Quydinh_Grid.Visibility = Visibility.Hidden;
        }

        private void Listview_Search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Listview_Search.SelectedItems.Count > 0)
            {
                SachTon a = (SachTon)Listview_Search.SelectedItems[0];
                Tensach_Search_Textbox_temp = Tensach_Search_Textbox.Text = a.Sach.TenSach;
                Theloaisach_Search_Textbox_temp = Theloaisach_Search_Textbox.Text = a.Sach.TheLoai;
                Tacgia_Search_Textbox_temp = Tacgia_Search_Textbox.Text = a.Sach.TacGia;
                Giaban_Search_Textbox_temp = Giaban_Search_Textbox.Text = a.Dongia.ToString();
                Idsach_Search_temp = a.Sach.Id;
            }
        }

        private void Danhsach_Khachhang_Button_Click(object sender, RoutedEventArgs e)
        {
            Themkhachhang_Khachhang_Button.Background = Brushes.LightGray;
            Phieuthutien_Khachhang_Button.Background = Brushes.LightGray;
            Danhsach_Khachhang_Button.Background = Brushes.GreenYellow;

            Phieuthutien_Khachhang_Grid.Visibility = Visibility.Hidden;
            Themkhachhang_Khachhang_Grid.Visibility = Visibility.Hidden;
            DanhsachKH_Khachhang_Grid.Visibility = Visibility.Visible;
            Display_DSKhachHang();
        }

        private void Phieuthutien_Khachhang_Button_Click(object sender, RoutedEventArgs e)
        {
            Themkhachhang_Khachhang_Button.Background = Brushes.LightGray;
            Phieuthutien_Khachhang_Button.Background = Brushes.GreenYellow;
            Danhsach_Khachhang_Button.Background = Brushes.LightGray;

            Phieuthutien_Khachhang_Grid.Visibility = Visibility.Visible;
            Themkhachhang_Khachhang_Grid.Visibility = Visibility.Hidden;
            DanhsachKH_Khachhang_Grid.Visibility = Visibility.Hidden;
        }

        private void Themkhachhang_Khachhang_Button_Click(object sender, RoutedEventArgs e)
        {
            Themkhachhang_Khachhang_Button.Background = Brushes.GreenYellow;
            Phieuthutien_Khachhang_Button.Background = Brushes.LightGray;
            Danhsach_Khachhang_Button.Background = Brushes.LightGray;

            Phieuthutien_Khachhang_Grid.Visibility = Visibility.Hidden;
            Themkhachhang_Khachhang_Grid.Visibility = Visibility.Visible;
            DanhsachKH_Khachhang_Grid.Visibility = Visibility.Hidden;
        }

        private void DSKhachhang_Listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DSKhachhang_Listview.SelectedItems.Count > 0)
            {
                DSKhachHang a = (DSKhachHang)DSKhachhang_Listview.SelectedItems[0];
                HoTen_DSKhachHang_KhachHang_Textbox.Text = a.KhachHang.HoTen;
                DiaChi_DSKhachHang_KhachHang_Textbox.Text = a.KhachHang.Address;
                SDT_DSKhachHang_KhachHang_Textbox.Text = a.KhachHang.Phone;
                Email_DSKhachHang_KhachHang_Textbox.Text = a.KhachHang.Email;
                IdKhachHang_Temp = a.KhachHang.Id;
            }
        }
        
    }
    #endregion
}
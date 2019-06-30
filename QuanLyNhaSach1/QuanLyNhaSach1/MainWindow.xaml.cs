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


        #region Events
        void Quydinh_Config()
        {
            string SqlIns = "select * from [Quydinh] where Id = '1' ";
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

        #endregion
        //
        //
        // Hóa đơn EVENT
        //
        //
        private void Them_Button_Bill_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Xoa_Button_Bill_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void Tensach_Bill_Texbox_GotFocus(object sender, RoutedEventArgs e)
        {
          
        }

        private void Masach_Textbox_Bill_GotFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void GhiNo_Hoadon_Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Luu_Hoadon_Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        //
        //
        // Tìm Sách EVENT
        //
        //

        private void Tim_Timsach_button_Click(object sender, RoutedEventArgs e)
        {
           
        }



        private void Sua_Timsach_Texbox_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Xoa_Search_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //
        //
        // Nhập Sách EVENT
        //
        //

        private void Nhap_Nhapsach_button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        //
        //
        // Khách hàng EVENT
        //
        //

        private void Them_Khachhang_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void Sua_DanhsachKH_Khachhang_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Thutien_PhieuthuTien_Khachhang_Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        //
        //
        // Báo cáo tháng EVENT
        //
        //

        private void Tim_Baocaoton_Report_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Lapbaocao_Report_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Thongke_Baocaocongno_Report_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void Thongke_Lapbaocaothang_Report_Click(object sender, RoutedEventArgs e)
        {
           
        }

        //
        //
        // Quy định EVENT
        //
        //

        private void Luu_Nhapsach_Quydinh_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Luu_Hoadon_Quydinh_Click(object sender, RoutedEventArgs e)
        {
           
        }



        private void Phieuthutien_Quydinh_Checkbox_Click(object sender, RoutedEventArgs e)
        {
           
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
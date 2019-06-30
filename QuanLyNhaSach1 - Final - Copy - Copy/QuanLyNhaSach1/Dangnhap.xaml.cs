using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace QuanLyNhaSach1
{
    /// <summary>
    /// Interaction logic for Dangnhap.xaml
    /// </summary>
    public partial class Dangnhap : Window
    {
        public int exit = 0;
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {

            if (DataProvider.Ins.DB.Users.Where(x => x.UserName == username.Text && x.Password == PasswordBox.Password.ToString()).Count() > 0)
            {
                exit = 1;
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai Tài khoản hoặc Mật Khẩu!");
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (exit == 0)
                Environment.Exit(1);
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
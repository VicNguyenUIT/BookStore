   M S B A M L   `   `   `  ���� I  EQuanLyNhaSach1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QuanLyNhaSach1QuanLyNhaSach1      QuanLyNhaSach1.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:QuanLyNhaSach1     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � Title$ Quản Lý Nhà Sách��$	��600��$	��815�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=�.���  � RowDefinitions �� $
��auto ��� .+�� $��0��.+�#  MaterialDesignThemes.Wpf.Card  $��80������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF65E0F3��	 � Offset$	 0Q�� $ 	#FF75D6C0��$	 1Q�� $ 	#FFA4F7F6��$
	 0.48Q�.��� $��Stretch=�$��Stretch=�
������ 
 � ColumnDefinitions
 �� �� �� �� �� �� .+��� -    ��Name$ Hoadon_button��$��0�� � ToolTip$ 
Hóa Đơn��
��� ��� " MaterialDesignRaisedDarkButton#��[ $	��130��$��60�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 3Q�   	Direction$	 320Q�   Color$ 	#FF646363��.���  �� �� .+�� $��0��.+��� $��Center=�$��0 0 0 3q�
Hóa Đơn� $��1��.+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ BarcodeScan=�$��38��$��30��$��Center=�$��0,0,0,-7q�$��Bottom=��� -   $ Timsach_button��$��1��$ 
Tìm Sách��
����  �#��[ $	��130��$��60��   $ 3Q�$	 320Q�$ 	#FF646363��.���  �� �� .+�� $��0��.+��� $��Center=�$��0 0 0 3q�
Tìm Sách� $��1��.+�  $ DatabaseSearch=�$��38��$��30��$��Center=�$��0,0,0,-7q�$��Bottom=��� -   $ Nhapsach_button��$��2��$ Nhập sách��
����  �#��[ $	��130��$��60��   $	 320Q�$ 	#FF646363��$ 3Q�.���  �� �� .+�� $��0��.+��� $��Center=�$��0 0 0 3q�Nhập Sách� $��1��.+�  $ BookPlus=�$��38��$��30��$��Center=�$��0,0,0,-7q�$��Bottom=��� -   $ Khachhang_button��$��3��$ Khách Hàng��
����  �#��[ $	��130��$��60��   $ 3Q�$	 320Q�$ 	#FF646363��.���  �� �� .+�� $��0��.+��� $��Center=�$��0 0 0 3q�Khách Hàng� $��1��.+�  $ Elevator=�$��38��$��30��$��Center=�$��0,0,0,-7q�$��Bottom=��� -   $ Baocaothang_button��$��4��$ Báo Cáo Tháng��
����  �#��[ $	��130��$��60��   $	 320Q�$ 	#FF646363��$ 3Q�.���  �� �� .+�� $��0��.+��� $��Center=�$��0 0 0 3q��� $�Báo Cáo Tháng��� $��1��.+�  $ 	Newspaper=�$��38��$��30��$��Center=�$��0,0,0,-7q�$��Bottom=��� -   $ Quydinh_button��$��6��$ Thay Đổi Quy Định��
����  �#��[ $	��130��$��60��   $	 320Q�$ 	#FF646363��$ 3Q�.���  �� �� .+�� $��0��.+��� $��Center=�$��0 0 0 3q��� $�Quy Định��� $��1��.+�  $ CalendarText=�$��38��$��30��$��Center=�$��0,0,0,-7q�$��Bottom=�� -    �Name$
 Rule��$��1��$��15q�$y�Hidden=�.+�  $	��462��.��� 
 �� $
��auto ��� .+��� $��Center=�$	��450��$��0��
�������$��1q�$	��0,6q�$
��Left=�$	��160��._��  �� $
��auto ��� $
��auto ��� $
��auto �.+�� $��0��.+��� -   $ Rule_Nhapsach��$��0��
���/���$��Center=�$��0,4,0,0q� $  MaterialDesignRaisedAccentButton#��[ $	��150��$5 /Resource name: MaterialDesignRaisedAccentButton�� J� RenderTransformOrigin$ 0.06,0.5&�.��Nhập sách�� -	   $ Rule_Hoadon��$��1��$��Center=�$��0,4,0,0q�#��[ $	��150��
�������$5 /Resource name: MaterialDesignRaisedAccentButton��$ 0.06,0.5&�.��
Hóa đơn�� -
   $ Rule_Phieuthutien��$��2��$��Center=�$��0,4,0,0q�#��[ $	��150��
�������$5 /Resource name: MaterialDesignRaisedAccentButton��$ 0.06,0.5&�.��Phiếu thu tiền� -   $ Nhapsach_Quydinh_Grid��$��1��$y�Visible=� �� $
��auto ��� $
��auto ��� $
��auto �.+�  $��0��$��40��$��	10 20 0 0q�.��� .+��� $	��200��$��10,0,0,0q�$
��Left=�$��Center=�-+-Số lượng sách nhập ít nhất là:�� -    ��Name$" Nhaptoithieu_Quydinh_Textbox��$��
195,-2,0,7q�$
��Left=�$��50��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$  �� % !MaterialDesignFloatingHintTextBox#��[   $��1��$��40��$��10 5 0 0q�.��� .+��� $	��250��$��10,0,0,0q�$
��Left=�$��Center=�><-Chỉ nhập các đầu sách có lượng tồn ít hơn:�� -   $* $Sachtontoithieu_Nhap_Quydinh_Textbox��$��
268,-2,0,7q�$
��Left=�$��50��$  ��#��[ �� -   $ Luu_Nhapsach_Quydinh��$��2��
���/���$��Right=�$��0,4,30,0q�#��[ $	��100��$5 /Resource name: MaterialDesignRaisedAccentButton��$ 0.06,0.5&�.��Lưu� -   $ HoaDon_Quydinh_Grid��$��1��$y�Hidden=� �� $
��auto ��� $
��auto �.+�  $��0��$��70��$��	10 20 0 0q�.��� .+��� $
��auto��$��
10,15,0,39q�$
��Left=�$��Center=�42Chỉ bán cho các khách hàng nợ không quá:�� -   $ Tienno_Quydinh_Textbox��$��265,-30,0,35q�$
��Left=�$��50��$  ��#��[ �� $
��auto��$��
10,40,0,14q�$
��Left=�$��Center=�B@và đầu sách có lượng tồn sau khi bán ít nhất là:�� -   $) #Sachtontoithieu_Ban_Quydinh_Textbox��$��
287,-4,0,9q�$
��Left=�$��50��$  ��#��[ �� -   $ Luu_Hoadon_Quydinh��$��1��
���/���$��Right=�$��0,4,30,0q�#��[ $	��100��$5 /Resource name: MaterialDesignRaisedAccentButton��$ 0.06,0.5&�.��Lưu� -   $ Phieuthutien_Quydinh_Grid��$��1��$y�Hidden=�.+�  $��1��$��40��$��10 5 0 0q�.��� .+��� -    ��Name$# Phieuthutien_Quydinh_Checkbox��$M��GSố tiền thu không vượt quá số tiền Khách hàng đang nợ��$��
20,0,-20,0q�� -   $ Report��$��1��$��15q�$y�Hidden=�.+�  $	��462��.��� 
 �� $
��auto ��� $
��auto �.+��� $
��Left=�$��Center=�$	��160��$	��450��$��0��
�������$��1q�$	��0,6q�._��  �� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $' !Lapbaocaothang_Baocaothang_Button��$��0��$��0 5 0 0q�$��Center=�$	��Top=�
���/���#��[ $	��150��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Lập báo cáo tháng�� -   $ Baocaoton_button��$��1��$��0 5 0 0q�$��Center=�$	��Top=�
�������#��[ $	��150��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Báo cáo tồn�� -   $ Baocaocongno��$��2��$��0 5 0 0q�$��Center=�$	��Top=�
�������#��[ $	��150��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Báo cáo công nợ� -   $% Lapbaocaothang_Baocaothang_Grid��$��1��$	��600��$y�Visible=� �� $
��auto ��� $
��auto ��� $
��Auto ��� .+�� $��1��$��0 5 0 0q�
 �� �� �� .+��� -   $# Thongke_Lapbaocaothang_Report��$��1��$��0 0 10 0q�$��Right=�
���/���#��[ $	��100��$! Lập báo cáo tháng này��.��Thống kê�� -   $ Lapbaocao_Report��$��2��$
��Left=�
���/���#��[ $	��100��$! Lập báo cáo tháng này��.��Lưu�� -    ��Name$ List_Lapbaocaoton��$��2��$	��350��$y�Visible=�$��0,0,0,65q����� *Items1+ �� View �� .P��� $	��STT�� �� DisplayMemberBinding �� *STT+��  �� Width$	 130��$��Sách�� �� *	Tensach+�� $	 100��$��Tồn đầu�� �� *TonDau+�� $	 110��$��Lượng nhập�� �� *Soluongnhap+�� $	 110��$��Số lượng bán�� �� *
Soluongban+�� $	 100��$��Tồn cuối�� �� *	TonCuoi+� -   $  Baocaoton_Baocaothang_Grid��$��1��$	��600��$y�Hidden=� �� $
��auto ��� $
��auto ��� $
��Auto ��� .+�� $��1��
 �� �� �� .+��� -   $! Nhapthang_Baocaoton_Textbox��$��0��$��0,0,0,5q�$��Center=�$	��100��$ Nhập Tháng��#��[ �� -   $ Nhapnam_Baocaoton_Textbox��$��1��$��0,0,0,5q�$
��Left=�$	��100��$ Nhập năm��#��[ �� -    $ Tim_Baocaoton_Report��$��2��$
��Left=�
���/���#��[ $	��100��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Tìm�� -!   $ Listview_baocaoton��$��2��$	��270��$��0,0,0,65q� �� .P��� $	��STT�� �� *STT+�� $	 150��$��Sách�� �� *	Tensach+�� $	 100��$��Tồn đầu�� �� *TonDau+�� $	 100��$��Lượng nhập�� �� *Soluongnhap+�� $	 100��$��Lượng bán�� �� *
Soluongban+�� $	 100��$��Tồn cuối�� �� *	TonCuoi+� -"   $# Baocaocongno_Baocaothang_Grid��$��1��$	��600��$y�Hidden=� �� $
��auto ��� $
��auto ��� .+�� $��0��
 �� �� �� .+��� -#   $! Thongke_Baocaocongno_Report��$��2��$
��Left=�
���/���#��[ $	��100��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Tìm�� -$   $ Listview_baocaocongno��$��1��$	��350��$��0,0,0,65q� �� .P��� $	��STT�� �� *STT+�� $	 150��$��Khách hàng�� �� *KhachHang.HoTen+�� $	 100��$��Nợ đầu�� �� *NoDau+�� $	 100��$
��Nợ�� �� *No+�� $	 100��$��Trả�� �� *Tra+�� $	 100��$��Nợ cuối�� �� *NoCuoi+� .+��� 
���/���#��[ $	��100��$��50��$5 /Resource name: MaterialDesignRaisedAccentButton��$��Center=�$��Center=�$��Xuất Excel��$��654,407,-589,5q�� -%   $ Money��$��1��$��15q�$y�Hidden=�.+�  $	��462��.��� 
 �� $
��auto ��� .+��� $��0��$
��Left=�$��Center=�$	��160��$	��450��
�������$��1q�._��  �� $
��auto ��� $
��auto ��� $
��auto �.+��� -&   $# Phieuthutien_Khachhang_Button��$��0��$��0 4 0 0q�$	��Top=�
���/���$��Center=�#��[ $	��150��$5 /Resource name: MaterialDesignRaisedAccentButton��$ 0.06,0.5&�.��Phiếu thu tiền�� -'   $$ Themkhachhang_Khachhang_Button��$��1��$��0 4 0 0q�$	��Top=�
�������$��Center=�#��[ $	��150��$5 /Resource name: MaterialDesignRaisedAccentButton��$ 0.06,0.5&�.��Thêm khách hàng�� -(   $ Danhsach_Khachhang_Button��$��2��$��0 4 0 0q�$	��Top=�
�������$��Center=�#��[ $	��150��$5 /Resource name: MaterialDesignRaisedAccentButton��$ 0.06,0.5&�.��Danh sách KH� -)   $! Phieuthutien_Khachhang_Grid��$��1��$y�Visible=�
 �� �� .+��� -*   $ CMND_PhieuThuTien_Textbox��$��0��$��	10,10,0,0q�#��[ $
��Left=�$	��Top=�$ CMND khách hàng��$	��170��� $��1��$��
-90 10 0 0q�
 �� �� .+��� -+   $. (SoTienThu_PhieuThuTien_KhachHang_Textbox��$��0��$ Số tiền thu��#��[ $
��Left=�$	��Top=�$	��150��� $��1��$��	-25 0 0 0q�
 �� �� .+��� -,   $+ %Thutien_PhieuthuTien_Khachhang_Button��$��0��#��[ $	��100��$	��Top=�$5 /Resource name: MaterialDesignRaisedAccentButton��.��Thu� --   $" Themkhachhang_Khachhang_Grid��$��1��$y�Hidden=� �� $
��auto ��� $
��auto ��� $
��auto �.+�� $��0��
 �� �� .+��� -.   $( "HovaTenKhachhang_Khachhang_Textbox��$��0��$��	10,10,0,0q�$  Họ và Tên Khách Hàng��#��[ $
��Left=�$	��170��� $��1��$��	-70 0 0 0q�
 �� �� .+��� -/   $! CMND_Them_Khachhang_Textbox��$��0��$
 CMND��#��[ $
��Left=�$	��150��� $��1��$��	-25 0 0 0q�
 �� �� .+��� -0   $ Them_Khachhang_Button��$��0��#��[ $	��100��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Thêm� $��1��$��0 10 0 0q�
 �� �� .+�� .+��� -1   $ SDT_Khachhang_Textbox��$��0��$��	10,10,0,0q�$ Điện thoại��#��[ $
��Left=�$	��170��� $��1��$��	-70 0 0 0q�
 �� �� .+��� -2   $ Email_Khachhang_Textbox��$��0��$ Email��#��[ $
��Left=�$	��150��� $��2��$��0 10 0 0q�
 �� �� .+�� .+��� -3   $ DiaChi_Khachhang_Textbox��$��0��$��	10,10,0,0q�$ Địa chỉ��#��[ $
��Left=�$	��170��� $��1��$��0 0 0 0q�
 �� �� .+�(  "System.Windows.Controls.DatePicker  -4     Name$+ %ThangNgayNamSinh_Khachhang_Datepicker��$	��150��$��
-140 0 0 0q�$ Tháng Ngày Năm sinh�� ( $MaterialDesignFloatingHintDatePicker#��[ � -5   $ DanhsachKH_Khachhang_Grid��$��1��$	��600��$y�Hidden=� �� $
��auto ��� $
��auto ��� $
��Auto ��� .+�� $��0��$��0 5 0 5q�
 �� �� �� .+��� -6   $% Sua_DanhsachKH_Khachhang_Button��$��2��$��0 0 10 0q�$��Center=�
���/���#��[ $	��100��$! Lập báo cáo tháng này��.��Sửa  $��1��$��50��.��� 
 �� �� �� �� .+��� -7   $) #HoTen_DSKhachHang_KhachHang_Textbox��$��0��$��30 0 0 5q�$
��Left=�$	��200��$ 	Họ Tên��#��[ �� -8   $* $DiaChi_DSKhachHang_KhachHang_Textbox��$��1��$��30 0 0 5q�$
��Left=�$	��200��$ Địa chỉ��#��[ �� -9   $' !SDT_DSKhachHang_KhachHang_Textbox��$��2��$��30 0 0 5q�$
��Left=�$	��200��$
 SĐT��#��[ �� -:   $) #Email_DSKhachHang_KhachHang_Textbox��$��3��$��30 0 0 5q�$
��Left=�$	��200��$ Email��#��[ �� -;   $ DSKhachhang_Listview��$��2��$	��350��$y�Visible=�$��0,0,0,65q� �� .P��� $ 65��$	��STT�� �� *STT+�� $	 100��$��	Họ Tên�� �� *KhachHang.HoTen+�� $	 100��$��Địa chỉ�� �� *KhachHang.Address+�� $	 110��$
��SĐT�� �� *KhachHang.Phone+�� $	 110��$��Email�� �� *KhachHang.Email+�� $	 100��$��Tiền nợ�� �� *KhachHang.TienNo+� -<   $ Import��$��1��$��15q�$y�Hidden=�.+�  $	��462��.���  �� $
��auto ��� $
��auto �.+�� $��0��
 �� �� .+�� $��0��$��10q�.+�  -=   $ Ngaythang_Import_Textbox��$��0��$
��Left=�$	��150��$ Tháng/Ngày/Năm��#��[ � $��1��$��	-70 0 0 0q�
 �� �� .+�� $��0��.+��� ->   $ Idsach_Import_textbox��$ 	Mã sách��#��[ $
��Left=�$	��150��� $��1��$��	-40 0 0 0q�
 �� �� .+��� -?   $ Checkbox_Import��$��0��  MaterialDesignCheckBox#��[ .��Nhập sách có sẵn�� -@   $ Nhap_Nhapsach_button��$��1��#��[ $	��100��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Nhập� $��1�� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+�� $��0��
 �� �� .+�� $��0��.+��� -A   $ Tensach_Import_Texbox��$��	10,10,0,0q�$ 
Tên sách��#��[ $
��Left=�$	��250��� $��1��$��	-70 0 0 0q�.+��� -B   $ Tacgia_Import_Texbox��$ 
Tác giả��#��[ $
��Left=�$	��150��� $��1��$��0 10 0 0q�
 �� �� .+�� $��0��.+��� -C   $ Theloai_Import_Textbox��$��	10,10,0,0q�$ Thể loại��#��[ $
��Left=�$	��250��� $��1��$��	-70 0 0 0q�
 �� �� .+��� -D   $  Soluongnhap_Import_Textbox��$��0��$��0 0 0 0q�$ Số lượng nhập��#��[ $
��Left=�$	��150��� $��2��$��0 10 0 0q�
 �� �� .+��� -E   $ Dongianhap_Import_Textbox��$��0��$��	10,10,0,0q�$ Đơn giá nhập��#��[ $
��Left=�$	��250��� $��1��$��0 0 0 0q�
 �� �� .+��� -F   $ Dongiaban_Import_Textbox��$��0��$��	-70 0 0 0q�$ Đơn giá bán��#��[ $
��Left=�$	��150��� -G   $ Search��$��1��$��15q�$y�Hidden=�.+�  $	��462��.���  �� $
��auto ��� $
��auto ��� $
��auto ��� $��1* �.+�  $��0��$��50��.��� 
 �� �� �� �� .+�� $��0��.+��� -H   $ Theoten_button_search��$
��Left=�$��30 0 0 0q�
���/���#��[ $	��130��$5 /Resource name: MaterialDesignRaisedAccentButton��.��	Theo tên� $��1��.+��� -I   $ Theotheloai_button_search��$
��Left=�$��30 0 0 0q�
�������#��[ $	��130��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Theo thể loại� $��2��.+��� -J   $ Theomasach_button_search��$
��Left=�$��30 0 0 0q�
�������#��[ $	��130��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Theo mã sách� $��3��.+��� -K   $ Tatcasach_button_search��$
��Left=�$��30 0 0 0q�
�������#��[ $	��130��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Tất cả sách  $��1��$��50��$��0 10 0 0q�.��� 
 �� �� �� �� .+�� $��0��.+��� -L   $ Theoten_textbox_search��$��30 0 0 5q�$
��Left=�$	��200��$ Nhập tên sách��#��[ �� -M   $  Theotheloai_textbox_search��$y�Hidden=�$��30 0 0 5q�$
��Left=�$	��200��$ Nhập thể loại sách��#��[ �� -N   $ Theomasach_textbox_search��$y�Hidden=�$��30 0 0 5q�$
��Left=�$	��200��$ Nhập mã sách��#��[ �� -O   $ Tim_Timsach_Button��$��1��$��-0 0 0 0q� �� 	IsDefault . #��[ $	��100��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Tìm�� -P   $ Sua_Timsach_Texbox��$��2��$��-0 0 0 0q� . #��[ $	��100��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Sửa�� -Q   $ Xoa_Timsach_Button��$��3��$��-0 0 0 0q� . #��[ $	��100��$5 /Resource name: MaterialDesignRaisedAccentButton��.��Xóa  $��2��$��50��.��� 
 �� �� �� �� .+��� -R   $ Tensach_Search_Textbox��$��0��$��30 0 0 5q�$
��Left=�$	��200��$ 
Tên sách��#��[ �� -S   $  Theloaisach_Search_Textbox��$��1��$��30 0 0 5q�$
��Left=�$	��200��$ Thể loại sách��#��[ �� -T   $ Tacgia_Search_Textbox��$��2��$��30 0 0 5q�$
��Left=�$	��200��$ Tác giả��#��[ �� -U   $ Giaban_Search_Textbox��$��3��$��30 0 0 5q�$
��Left=�$	��200��$ Giá bán��#��[ � $��3��.+��� -V   $ Listview_Search��$	��280�� �� .P��� $	��STT�� �� *STT+�� $	��Mã�� �� *	Sach.Id+�� $	 150��$��Sách�� �� *Sach.TenSach+�� $	 100��$��Thể loại�� �� *Sach.TheLoai+�� $	 100��$��
Tác giả�� �� *Sach.TacGia+�� $	 100��$��Số lượng�� �� *	Soluong+�� $	 100��$��	Giá bán�� �� *Dongia+�� $	 150��$��Tổng�� �� *Tong+� -W   $
 Bill��$��1��$��15q�$y�Visible=�.+�  $	��462��.���  �� $
��auto ��� $
��auto ��� $��1* �.+�  $��0��$��50��$��0 0 0 3q�.��� 
 �� �� .+�� $��0��
 �� �� .+�  -X   $ Ngaythangnam_Bill��$��0��$��	10,10,0,5q�$
��Left=�$	��150��$ Tháng/Ngày/Năm��#��[    FirstDayOfWeek$ Monday=��� -Y   $ CMND_Bill_Textbox��$��1��$��5 0 0 5q�$ CMND Khách hàng��#��[ $
��Left=�$	��170��� $��2��$��	-70 0 0 0q�
 �� �� .+��� -Z   $ Luu_Hoadon_Button��$��0��$��60 0 0 0q�
������� # MaterialDesignRaisedLightButton#��[ $	��100��$$ Thanh toán + lưu hóa đơn��.��Tiền mặt� $��1��$��	-25 0 0 0q�
 �� �� .+��� -[   $ GhiNo_Hoadon_Button��$��0��
�������#��[ $	��100��$ Cho khách hàng ghi nợ��.��
Ghi nợ�� $��1��
�������#��[ $	��100��$ In hóa đơn + Lưu��.��In  $��1��$��50��$��0 0 0 3q�.��� 
 �� $
��auto ��� $
��auto �.+�� $��0��
 �� $
��auto ��� $
��auto �$	��190���� $
��auto �$��86��.+��� -\   $ Tensach_Bill_Texbox��$��0��$��10,0,0,5q�$��2��$ 
Tên sách��#��[ $
��Left=�$	��170���� -]   $ Masach_Textbox_Bill��$��1��$��20 0 0 5q�$��1��$ 	Mã sách��#��[ $
��Left=�$	��170���� -^   $ Soluong_Bill_Textbox��$��2��$��
20,0,-21,5q�$��1��$ Số lượng��#��[ $
��Left=�$��88��� $��1��
 �� $
��auto ��� $
��auto �.+��� -_   $ Them_Button_Bill��$��0��$��74 0 0 0q� . #��[ $	��100��$$ Thêm sách vào hóa đơn��.��Thêm�� -`   $ Xoa_Button_Bill��$��1��$��25 0 0 0q�#��[ $	��100��$% Xóa sách khỏi hóa đơn��.��Xóa� $��2��.+��� -a   $ Listview_Bill��$	��320��$	��Top=�$��0,0,0,10q�$��2������ *
ListHoaDon+ �� .P��� $	��STT�� �� *STT+�� $	��Mã�� �� *	Sach.Id+�� $	 150��$��Sách�� �� *Sach.TenSach+�� $	 100��$��Thể loại�� �� *Sach.TheLoai+�� $	 100��$��
Tác giả�� �� *Sach.TacGia+�� $	 100��$��Số lượng�� �� *	Soluong+�� $	 100��$��
Đơn giá�� �� *Dongia+�� $	 150��$��Tổng�� �� *Tong+�� -b    ��Name$ Tongtien_Hoadon_Textbox��$��0��$
��auto��$��670,325,-670,-22q�$��2���� $��Tổng tiền: ��$
��auto��$��606,325,-606,-22q�$��2��
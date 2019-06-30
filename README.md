# Quản Lý Nhà Sách
# Giới thiệu
Trước kia khi công nghệ chưa phát triển, chúng ta đều dùng các phương pháp thủ công trong việc quản lý gây ra nhiều phiền toái trong việc lưu trữ sổ sách, việc tính toán , tìm kiếm, ... Để giải quyết vấn đề này chúng ta xây dựng những trang web, phần mềm quản lý để giảm bớt số lượng công việc cần tới con người, đáp ứng những nhu cầu của người dùng.

# Tổng quan
Đồ án môn Nhập môn Công nghệ phần mềm

Mã lớp: SE104.J21.PMCL

Giảng viên: Nguyễn Công Hoan

Công nghệ: C#, SQL Sever
# Yêu cầu
-Phù hợp mục đích của người dùng , phù hợp với trình độ của người dùng,ai cũng có thể dùng được. Đồng thời phải ổn định chắc chắn có khả năng cung cấp thông tin đáp ứng khi cần thiết. Dễ dàng bảo hành, cải tiến , nhanh chóng chỉ ra những lỗi cần điều chỉnh

-Hệ thống phải dễ dàng truy xuất , vận hành , sử dụng

-Giao diện dễ nhìn phù hợp với không gian làm việc, các yêu cầu về kỹ thuật phải xử lý chính xác

-An toàn, bảo mật

# Chức năng
    1.Màn hình “Hóa đơn”: 
-Đầu tiên Nhân viên nhập Số CMND khách hàng (Trước đó đã tạo thông tin Khách hàng.
-Tìm và thêm sách Khách hàng yêu cầu bằng cách nhập “Mã sách” hoặc “Tên sách” (Tên sách phải chính xác), số lượng Khách hàng yêu cầu.
-Ấn nút “Thêm” để thêm sách vào hóa đơn.
-Nếu muốn xóa sách khỏi hóa đơn thì ấn nút “Xóa”.
-Có 2 hình thức thanh toán là Trả tiền mặt hoặc cho Khách hàng Ghi nợ, tương ứng với nút “Tiền mặt” và “Ghi nợ”. 
+Có được phép bán cho khách hàng hay không thì phụ thuộc vào “Quy định Hóa đơn” trong phần “Quy Định”. Liên quan đến số tiền nợ của khách hàng và số lượng tồn của đầu sách sau khi bán.
Sau khi thanh toán thì lưu hóa đơn vào Database và reset các thông tin sách và danh sách hóa đơn.
-Nút “In” chưa hoàn thiện.
-Ô “Tháng/Ngày/Năm” để mặc định sẽ là ngày hiện tại.

    2.Màn hình “Tìm sách”: 
-Tìm kiếm sách theo “Tên”, “Thể loại”, “Mã sách” hoặc tìm “Tất cả sách” hiện có trong kho.
-Nhập thông tin gần đúng của sách vào ô nhập và ấn nút “Tìm”.
-Chọn vào sách bất kì thì thông tin sách sẽ hiện thị lên các ô thông tin bên trên, sửa các thông tin trong ô này rồi ấn nút “Sửa” để sửa thông tin sách.
-Chọn sách bất kỳ rồi ấn nút “Xóa” để xóa sách khỏi Database. Lưu ý là sách đã có trong hóa đơn hoặc báo cáo thì sẽ không xóa được!


# Thành viên:
-Phạm Tấn Khoa- 16520602

-Phạm Đình Anh Vũ- 16521407

-Nguyễn Văn Thắng- 16521104

-Nguyễn Trung Nghĩa- 16520812

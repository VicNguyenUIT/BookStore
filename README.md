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
Màn hình “Báo cáo tháng”: Gồm 3 màn hình khác:
  * Màn hình “Lập báo cáo tháng”: Thống kê sách mỗi cuối tháng.
    - Nút “Thống kê” để liệt kê các sách và lượng “tồn đầu”, “Lượng bán”, “Lượng nhập” và “Tồn cuối”.
    - Nút “Lưu”, lưu bản báo cáo vừa thống kê vào Database. Lưu ý: Việc này là nhất định phải làm mỗi cuối tháng, nếu không thì tháng đó       sẽ không có báo cáo.
  * Màn hình “Báo cáo tồn”: Tìm kiếm báo cáo về sách trong một tháng nào đó (Đã lưu trước đó).
    - Nhập “Tháng” và “Năm” cần tìm báo cáo vào ô.
    - Nút “Tìm”, xuất ra bảng báo cáo của tháng cần tìm (Với điều kiện là đã lưu báo cáo của tháng đó trước đó).
  * Màn hình “Báo cáo Công nợ”: 
    - Nút “Tìm”, thống kê các khách hàng và các “số tiền đã ghi nợ”, “số tiền đã trả” và “nợ cuối” của khách hàng.

Màn hình “Quy Định”: Gồm 3 màn hình khác:
  * Màn hình “Nhập sách”: Quy định các yếu tố khi nhập sách.
    - Quy định “Số lượng sách nhập ít nhất” mỗi lần nhập sách.
    - “Chỉ nhập các đầu sách có lượng tồn ít hơn” , số lượng sách trong kho nhỏ hơn mức này thì mới nhập đầu sách đó.
  * Màn hình “Hóa Đơn”: Quy định các yếu tố lập hóa đơn bán sách.
    - Chỉ bán sách cho khách hàng nợ không quá số tiền quy định và sau khi bán thì đầu sách phải còn hơn 20 sách.
  * Màn hình “Phiếu thu tiền”: 
    - Quyết định có sử dụng quy định “số tiền thu không vượt quá số tiền khách đang nợ hay không”
    - Nếu không sử dụng, số tiền nợ của khách hàng có thể là âm, lúc này nhà sách đang nợ lại khách hàng.

# Thành viên:
-Phạm Tấn Khoa- 16520602

-Phạm Đình Anh Vũ- 16521407

-Nguyễn Văn Thắng- 16521104

-Nguyễn Trung Nghĩa- 16520812

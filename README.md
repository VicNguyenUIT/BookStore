# Màn hình “Nhập sách”:
- Điền các thông tin của sách vào các ô.
- Mã sách là do nhà sách quy định hoặc mã sau cuốn sách.
- Ấn nút “Nhập” để nhập sách.
    + Nếu mã sách đã có trong kho thì thông báo “Sách trùng”.
    + Nếu điền thiếu các thông tin thì thông báo Lỗi.
    + Số lượng sách nhập phụ thuộc vào “Quy định Nhập sách” trong phần “Quy Định”. Liên quan đến số lượng nhập vào và số lượng tồn trong kho của đầu sách đó.
- Checkbox “Nhập sách có sẵn” để nhập thêm sách đã có trong kho, khi này chỉ cần điền mã sách và số lượng nhập, các thông tin còn lại sẽ tự động lấy từ Database.
- Ô “Tháng/ Ngày/ Năm” để mặc định sẽ là ngày hiện tại.

# Màn hình “Khách hàng”:
Gồm 3 màn hình khác:
- Màn hình “Phiếu thu tiền”: Để thu 1 tiền khách hàng (Khách hàng trả nợ)
    + Nhập “CMND Khách hàng”.
    + Nhập “Số tiền thu”. 
    + Nút “Thu” để tiền hành lưu phiếu thu và trừ tiền nợ cho Khách hàng.
    + Số tiền thu được theo “Quy định Phiếu thu tiền” trong phần “Quy Định” liên quan đến số tiền nợ của Khách hàng.
    
- Màn hình “Thêm khách hàng”: Thêm Khách hàng mới.
    + Điền thông tin Khách hàng vào các ô. 
    + CMND Khách hàng chính được sử dụng làm  “Mã số Khách hàng”.
    + Nút thêm để lưu thông tin Khách hàng.

- Màn hình “Danh sách KH”: Liệt kê danh sách các khách hàng và thay đổi thông tin khách hàng khi cần thiết.
    + Để sửa thông tin khách hàng: Chọn khách hàng rồi điền thông tin cần sửa vào các ô bên trên, sau đó nhấn “Sửa”.
    + Khách hàng thì không có tính năng xóa.

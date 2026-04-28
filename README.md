# Hệ thống Quản lý Lịch hẹn (Calendar Management System)

Dự án cuối kỳ - Nhóm 3 thành viên.

## 📌 Giới thiệu
Ứng dụng cho phép người dùng quản lý lịch cá nhân và lịch nhóm, hỗ trợ các tính năng thêm, sửa, xóa, kiểm tra trùng lịch và cài đặt bộ nhắc nhở. Dự án được xây dựng theo mô hình kiến trúc 3 lớp (3-Tier Architecture) để đảm bảo tính dễ bảo trì và làm việc nhóm hiệu quả.

## 🛠 Công nghệ sử dụng
- **Ngôn ngữ:** C# (.NET Framework)
- **Giao diện:** Windows Forms (WinForms)
- **Cơ sở dữ liệu:** Microsoft SQL Server (MSSQL)
- **Công nghệ truy vấn:** LINQ to SQL (.dbml)

## 📂 Cấu trúc dự án
Dự án được tổ chức thành các thư mục chính:
- **VIEW:** Chứa các Form giao diện người dùng (MainForm, AppointmentDetailForm, ...).
- **BLL (Business Logic Layer):** Xử lý nghiệp vụ, kiểm tra tính hợp lệ và các thuật toán (Trùng lịch, Họp nhóm).
- **DAL (Data Access Layer):** Chuyên trách giao tiếp với Database thông qua DataContext.
- **DTO (Data Transfer Object):** Chứa các lớp dữ liệu sinh ra từ file `DataClasses1.dbml`.

## 🚀 Hướng dẫn tải code và setup máy

### 1. Chuẩn bị
- Đảm bảo máy đã cài đặt **Visual Studio** (hỗ trợ .NET Framework).
- Cài đặt **SQL Server Management Studio (SSMS)**.

### 2. Thiết lập Database (Rất quan trọng)
1. Mở SSMS, tạo một database mới tên là `CalendarDB`.
2. Mở file script SQL của nhóm (hoặc xin trưởng nhóm đoạn mã tạo bảng) và nhấn **Execute (F5)** để tạo bảng.
3. Đảm bảo bạn có đủ 4 bảng: `Users`, `Appointments`, `Reminders`, `GroupParticipants`.

### 3. Cấu hình Project trong Visual Studio
1. Mở Solution bằng Visual Studio.
2. **Cập nhật lại kết nối Database:**
   - Mở cửa sổ **Server Explorer**.
   - Thêm lại Connection (Add Connection) trỏ về đúng máy chủ SQL (Server name) của bạn và chọn `CalendarDB`.
   - **Lưu ý lỗi SSL:** Khi kết nối, nhớ tích chọn **`Trust Server Certificate = True`** (hoặc `Mandatory`) để tránh lỗi bảo mật chứng chỉ.
   - Nếu DataClasses1.dbml bị lỗi kết nối cũ, hãy mở file đó ra, kéo thả lại các bảng từ Server Explorer vào để cập nhật chuỗi kết nối (Connection String) cho đúng máy của bạn.

### 4. Chạy dự án
- Nhấn nút **Start (F5)** để build và chạy ứng dụng.

## 🤝 Phân công nhiệm vụ
- **Thành viên 1:** Quản lý chung, xây dựng luồng Thêm/Sửa lịch (`AppointmentDetailForm`).
- **Thành viên 2:** Xây dựng giao diện Danh sách (`AppointmentListForm`), luồng Xem/Xóa và nạp dữ liệu.
- **Thành viên 3:** Xử lý các thuật toán nâng cao (Check Conflict, Group Meeting Match) và hệ thống Nhắc nhở.

## 📝 Ghi chú làm việc nhóm
- Luôn **Pull** (kéo code mới nhất) từ Git về máy trước khi bắt đầu code để tránh đè file.
- Tuyệt đối không tự ý sửa các file cấu trúc chung (`DataClasses1.dbml`, `App.config`) khi chưa báo cho cả nhóm.

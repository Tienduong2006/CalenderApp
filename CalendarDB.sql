-- =============================================
-- KHỞI TẠO CƠ SỞ DỮ LIỆU
-- =============================================

-- 1. Tạo Database mới tên là CalendarDB
CREATE DATABASE CalendarDB;
GO

-- 2. Bắt buộc SQL Server phải trỏ vào Database vừa tạo để làm việc
USE CalendarDB;
GO

-- =============================================
-- TẠO CÁC BẢNG (TABLES)
-- =============================================

-- 3. Tạo Bảng lưu trữ thông tin người dùng
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    Email VARCHAR(100)
);
GO

-- 4. Tạo Bảng lưu trữ Cuộc hẹn (Dùng chung cho cả Lịch đơn và Lịch nhóm)
CREATE TABLE Appointments (
    AppointmentID INT IDENTITY(1,1) PRIMARY KEY,
    OwnerID INT NOT NULL, -- Người tạo ra lịch này
    Name NVARCHAR(255) NOT NULL, -- Đảm bảo không được nhập tên rỗng
    Location NVARCHAR(255),
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    IsGroupMeeting BIT DEFAULT 0, -- 0: Lịch Cá Nhân, 1: Lịch Nhóm
    
    -- Ràng buộc khóa ngoại trỏ về bảng Users
    FOREIGN KEY (OwnerID) REFERENCES Users(UserID),
    
    -- Ràng buộc (Constraint): Giờ kết thúc phải lớn hơn giờ bắt đầu
    CONSTRAINT CHK_Duration CHECK (EndTime > StartTime) 
);
GO

-- 5. Tạo Bảng lưu trữ Bộ nhắc nhở
CREATE TABLE Reminders (
    ReminderID INT IDENTITY(1,1) PRIMARY KEY,
    AppointmentID INT NOT NULL,
    MinutesBefore INT NOT NULL, -- Ghi nhớ số phút nhắc trước (vd: 15 phút, 1440 phút = 1 ngày)
    
    -- CASCADE: Xóa lịch thì các bộ nhắc liên quan tự động bị xóa theo
    FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID) ON DELETE CASCADE
);
GO

-- 6. Tạo Bảng lưu trữ Người tham gia họp nhóm (Chỉ dùng cho IsGroupMeeting = 1)
CREATE TABLE GroupParticipants (
    AppointmentID INT NOT NULL,
    UserID INT NOT NULL,
    
    -- Khóa chính kép: Một người chỉ được tham gia 1 nhóm 1 lần
    PRIMARY KEY (AppointmentID, UserID), 
    
    -- CASCADE: Xóa lịch nhóm thì danh sách người tham gia của lịch đó cũng bị xóa
    FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID) ON DELETE CASCADE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO


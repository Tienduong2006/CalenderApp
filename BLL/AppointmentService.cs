using System;
using CalenderApp.DAL;

namespace CalenderApp.BLL
{
    public class AppointmentService
    {
        private readonly AppointmentRepository _repository;

        public AppointmentService()
        {
            _repository = new AppointmentRepository();
        }

        public bool TryCreateAppointment(string name, string location, DateTime startTime, DateTime endTime, bool isGroupMeeting, int ownerId, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Tên sự kiện không được để trống.";
                return false;
            }

            if (startTime >= endTime)
            {
                errorMessage = "Thời gian kết thúc phải sau thời gian bắt đầu.";
                return false;
            }

            if (startTime.Date != endTime.Date)
            {
                errorMessage = "Thời gian bắt đầu và kết thúc phải cùng một ngày.";
                return false;
            }

            if (!_repository.OwnerExists(ownerId))
            {
                errorMessage = "Không tìm thấy chủ sở hữu (UserID = 1). Vui lòng tạo user trước khi lưu.";
                return false;
            }

            _repository.InsertAppointment(name.Trim(), location?.Trim(), startTime, endTime, isGroupMeeting, ownerId);
            errorMessage = null;
            return true;
        }
    }
}

using CalenderApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalenderApp.DAL
{
    public class AppointmentDAL
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void EnsureParticipants(int appointmentId)
        {
            var appointment = db.Appointments.FirstOrDefault(a => a.AppointmentID == appointmentId);
            if (appointment == null)
            {
                return;
            }

            var existingIds = new HashSet<int>(
                db.GroupParticipants
                    .Where(p => p.AppointmentID == appointmentId)
                    .Select(p => p.UserID));

            if (db.Users.Any(u => u.UserID == 1) && !existingIds.Contains(1))
            {
                db.GroupParticipants.InsertOnSubmit(new GroupParticipant
                {
                    AppointmentID = appointmentId,
                    UserID = 1
                });
                existingIds.Add(1);
            }

            if (appointment.IsGroupMeeting == true)
            {
                var otherUserIds = db.Users
                    .Where(u => u.UserID != 1)
                    .Select(u => u.UserID)
                    .ToList();

                foreach (var userId in otherUserIds)
                {
                    if (existingIds.Contains(userId))
                    {
                        continue;
                    }

                    db.GroupParticipants.InsertOnSubmit(new GroupParticipant
                    {
                        AppointmentID = appointmentId,
                        UserID = userId
                    });
                }
            }

            db.SubmitChanges();
        }

        public dynamic GetAllAppointments()
        {
            var rawList = db.Appointments.ToList();

            var list = rawList.Select(a => new AppointmentDTO 
            {
                ID = a.AppointmentID,
                Title = a.Name,
                Location = a.Location,
                Date = a.StartTime.Date,
                StartHour = a.StartTime.ToString("h:mm tt"),
                EndHour = a.EndTime.ToString("h:mm tt"),
                Type = (a.IsGroupMeeting == true) ? "Nhóm" : "Đơn"
            }).ToList();

            return list;
        }

        public void UpdateAppointment(int id, string newTitle, string newLocation)
        {
            var appointment = db.Appointments.FirstOrDefault(a => a.AppointmentID == id);
            if (appointment != null)
            {
                appointment.Name = newTitle;
                appointment.Location = newLocation;
                db.SubmitChanges(); 
            }
        }
        public void DeleteAppointment(int id)
        {
            var appointment = db.Appointments.FirstOrDefault(a => a.AppointmentID == id);
            if (appointment != null)
            {
                db.Appointments.DeleteOnSubmit(appointment);
                db.SubmitChanges(); 
            }
        }
        // Hàm lấy chi tiết 1 sự kiện
        public dynamic GetAppointmentDetail(int id)
        {
            var detail = db.Appointments.FirstOrDefault(a => a.AppointmentID == id);
            return detail;
        }

        // Hàm lấy danh sách người tham gia
        public dynamic GetParticipants(int eventId)
        {
            var list = from p in db.GroupParticipants
                       join u in db.Users on p.UserID equals u.UserID
                       where p.AppointmentID == eventId
                       select new
                       {
                           ID = u.UserID,
                           Name = u.UserName,
                           Email = u.Email
                       };
            return list.ToList();
        }
    }
}

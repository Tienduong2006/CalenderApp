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

        public dynamic GetAllAppointments()
        {
            var rawList = db.Appointments.Select(a => new
            {
                a.AppointmentID,
                a.Name,
                a.Location,
                a.StartTime,
                a.EndTime,
                ParticipantCount = db.GroupParticipants.Count(p => p.AppointmentID == a.AppointmentID)
            }).ToList(); 

            var list = rawList.Select(a => new AppointmentDTO
            {
                ID = a.AppointmentID,
                Title = a.Name,
                Location = a.Location,
                Date = a.StartTime.Date,
                StartHour = a.StartTime.ToString("h:mm tt"),
                EndHour = a.EndTime.ToString("h:mm tt"),
                Type = (a.ParticipantCount > 1) ? "Nhóm" : "Đơn"
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
        public void SaveAllParticipants(int appointmentId, List<ParticipantDTO> finalList)
        {
            using (DataClasses1DataContext dbNew = new DataClasses1DataContext())
            {
                dbNew.Connection.Open();
                using (var transaction = dbNew.Connection.BeginTransaction())
                {
                    dbNew.Transaction = transaction;
                    try
                    {
                        var oldParticipants = dbNew.GroupParticipants.Where(p => p.AppointmentID == appointmentId);
                        dbNew.GroupParticipants.DeleteAllOnSubmit(oldParticipants);
                        dbNew.SubmitChanges();

                        List<int> addedUserIds = new List<int>();

                        foreach (var item in finalList)
                        {
                            int finalUserId = item.ID;

                            if (finalUserId != 0)
                            {
                                bool isExist = dbNew.Users.Any(u => u.UserID == finalUserId);
                                if (!isExist) finalUserId = 0; 
                            }

                            if (finalUserId == 0)
                            {
                                var existUser = dbNew.Users.FirstOrDefault(u => u.Email == item.Email);
                                if (existUser != null)
                                {
                                    finalUserId = existUser.UserID;
                                }
                                else
                                {
                                    var newUser = new User { UserName = item.Name, Email = item.Email };
                                    dbNew.Users.InsertOnSubmit(newUser);
                                    dbNew.SubmitChanges(); 
                                    finalUserId = newUser.UserID;
                                }
                            }

                            if (!addedUserIds.Contains(finalUserId))
                            {
                                var newLink = new GroupParticipant 
                                {
                                    AppointmentID = appointmentId,
                                    UserID = finalUserId
                                };
                                dbNew.GroupParticipants.InsertOnSubmit(newLink);
                                addedUserIds.Add(finalUserId);
                            }
                        }
                        dbNew.SubmitChanges();
                        transaction.Commit(); 
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); 
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
    }
}

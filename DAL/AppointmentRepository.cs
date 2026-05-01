using System;
using System.Linq;
using CalenderApp.DTO;

namespace CalenderApp.DAL
{
    public class AppointmentRepository
    {
        public bool OwnerExists(int ownerId)
        {
            using (var context = new DataClasses1DataContext())
            {
                return context.Users.Any(user => user.UserID == ownerId);
            }
        }

        public void InsertAppointment(string name, string location, DateTime startTime, DateTime endTime, bool isGroupMeeting, int ownerId)
        {
            using (var context = new DataClasses1DataContext())
            {
                var appointment = new Appointment
                {
                    Name = name,
                    Location = string.IsNullOrWhiteSpace(location) ? null : location,
                    StartTime = startTime,
                    EndTime = endTime,
                    IsGroupMeeting = isGroupMeeting,
                    OwnerID = ownerId
                };

                context.Appointments.InsertOnSubmit(appointment);
                context.SubmitChanges();
            }
        }
    }
}

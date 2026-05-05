using CalenderApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalenderApp.BLL
{
    public class MeetingLogic
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public string ValidateInput(string name, string location, int startHour, int endHour)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(location))
                return "Vui lòng điền đủ thông tin!";

            if (startHour >= endHour)
                return "Giờ bắt đầu phải bé hơn giờ kết thúc!";

            return "";
        }

        public int CheckMeetingStatus(int currentUserId, string eventName, DateTime date, int startHour, int endHour, out Appointment existingMeeting)
        {
            existingMeeting = null;
            DateTime newStart = date.Date.AddHours(startHour);
            DateTime newEnd = date.Date.AddHours(endHour);

            var groupMatch = db.Appointments.FirstOrDefault(a =>
                a.IsGroupMeeting == true &&
                a.Name == eventName &&
                (newStart < a.EndTime && newEnd > a.StartTime));

            if (groupMatch != null)
            {
                bool isAlreadyJoined = db.GroupParticipants.Any(p => p.AppointmentID == groupMatch.AppointmentID && p.UserID == currentUserId);
                if (!isAlreadyJoined)
                {
                    existingMeeting = groupMatch;
                    return 2;
                }
            }

            var conflictMatch = db.Appointments.FirstOrDefault(a =>
                a.OwnerID == currentUserId &&
                (newStart < a.EndTime && newEnd > a.StartTime));

            if (conflictMatch != null)
            {
                existingMeeting = conflictMatch;
                return 1;
            }

            return 0;
        }

        public void ProcessMeeting(int currentUserId, string name, string location, DateTime date, int startHour, int endHour, bool isGroup, List<int> reminderMinutes, int status, Appointment existingMeeting)
        {
            DateTime newStart = date.Date.AddHours(startHour);
            DateTime newEnd = date.Date.AddHours(endHour);

            if (status == 2)
            {
                var newParticipant = new GroupParticipant
                {
                    AppointmentID = existingMeeting.AppointmentID,
                    UserID = currentUserId
                };
                db.GroupParticipants.InsertOnSubmit(newParticipant);
                db.SubmitChanges();
                return;
            }

            if (status == 1)
            {
                db.Appointments.DeleteOnSubmit(existingMeeting);
                db.SubmitChanges();
            }

            var newAppt = new Appointment
            {
                OwnerID = currentUserId,
                Name = name,
                Location = location,
                StartTime = newStart,
                EndTime = newEnd,
                IsGroupMeeting = isGroup
            };
            db.Appointments.InsertOnSubmit(newAppt);
            db.SubmitChanges();

            if (isGroup)
            {
                db.GroupParticipants.InsertOnSubmit(new GroupParticipant { AppointmentID = newAppt.AppointmentID, UserID = currentUserId });
            }

            if (reminderMinutes != null && reminderMinutes.Count > 0)
            {
                foreach (int minutes in reminderMinutes)
                {
                    db.Reminders.InsertOnSubmit(new Reminder
                    {
                        AppointmentID = newAppt.AppointmentID,
                        MinutesBefore = minutes
                    });
                }
            }

            db.SubmitChanges();
        }
    }
}
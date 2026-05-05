using CalenderApp.DAL;
using CalenderApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalenderApp.BLL
{
    public class AppointmentBLL
    {
        AppointmentDAL dal = new AppointmentDAL();

        public dynamic GetList()
        {
            return dal.GetAllAppointments();
        }

        public void UpdateAppointment(int id, string title, string location)
        {
            dal.UpdateAppointment(id, title, location);
        }

        public void DeleteAppointment(int id)
        {
            dal.DeleteAppointment(id);
        }

        public dynamic GetAppointmentDetail(int id)
        {
            return dal.GetAppointmentDetail(id);
        }

        public dynamic GetParticipants(int eventId)
        {
            return dal.GetParticipants(eventId);
        }
        public void SaveAllParticipants(int appointmentId, List<ParticipantDTO> finalList)
        {
            dal.SaveAllParticipants(appointmentId, finalList);
        }

        // --- HÀM GHÉP THÊM ---
        public List<ReminderDTO> GetReminders(int eventId)
        {
            return dal.GetReminders(eventId);
        }
    }
}
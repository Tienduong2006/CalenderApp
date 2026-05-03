using CalenderApp.DAL;
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
            dal.EnsureParticipants(id);
            return dal.GetAppointmentDetail(id);
        }

        public dynamic GetParticipants(int eventId)
        {
            return dal.GetParticipants(eventId);
        }
    }
}

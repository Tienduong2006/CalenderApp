using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalenderApp.DTO
{
    public class AppointmentDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string Type { get; set; }
    }

    public class ParticipantDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Xoa { get; set; }
    }
}

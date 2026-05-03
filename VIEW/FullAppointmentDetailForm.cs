using CalenderApp.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalenderApp.VIEW
{
    public partial class FullAppointmentDetailForm : Form
    {
        AppointmentBLL bll = new AppointmentBLL();
        private int currentEventId;
        public FullAppointmentDetailForm(int eventId)
        {
            InitializeComponent(); 
            currentEventId = eventId;
        }
        private void FullAppointmentDetailForm_Load(object sender, EventArgs e)
        {
            var detail = bll.GetAppointmentDetail(currentEventId);
            if (detail != null)
            {
            
                lblTenSuKien.Text = detail.Name;
                lblViTri.Text = detail.Location;
                lblNgay.Text = detail.StartTime.ToString("dd/MM/yyyy");

                lblBatDau.Text = detail.StartTime.ToString("h:mm tt");
                lblKetThuc.Text = detail.EndTime.ToString("h:mm tt");
            }

            var participants = bll.GetParticipants(currentEventId);
            dgvNguoiThamGia.DataSource = participants;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using CalenderApp.VIEW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalenderApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnThemCuocHen_Click(object sender, EventArgs e)
        {
            // Lấy ra cái ngày mà người dùng đang click đậm lên ở MonthCalendar
            DateTime ngayDuocChon = monthCalendar1.SelectionStart;

            // Mở form Detail và ném cái ngày đó sang
            using (var detailForm = new AppointmentDetailForm(ngayDuocChon))
            {
                detailForm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fullAppointmentForm = new FullAppointmentListForm())
            {
                fullAppointmentForm.ShowDialog();
            }
            this.Close();
        }
    }
}

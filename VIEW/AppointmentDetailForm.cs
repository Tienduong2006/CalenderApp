using CalenderApp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace CalenderApp.VIEW
{
    public partial class AppointmentDetailForm : Form
    {
        private readonly DateTime _selectedDate;

        public AppointmentDetailForm()
        {
            InitializeComponent();
        }

        public AppointmentDetailForm(DateTime selectedDate)
        {
            InitializeComponent();
            _selectedDate = selectedDate.Date;
            dateTimePicker1.Value = _selectedDate;
            dateTimePicker2.Value = _selectedDate.AddHours(1);
            radioButton1.Checked = true;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string location = textBox2.Text.Trim();

            int startHour = dateTimePicker1.Value.Hour;
            int endHour = dateTimePicker2.Value.Hour;

            bool isGroup = radioButton2.Checked;
            DateTime date = _selectedDate;

            int currentUserId = 1;

            CalenderApp.BLL.MeetingLogic logic = new CalenderApp.BLL.MeetingLogic();

            string error = logic.ValidateInput(name, location, startHour, endHour);
            if (error != "")
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Appointment existingMeeting;
            int status = logic.CheckMeetingStatus(currentUserId, name, date, startHour, endHour, out existingMeeting);

            if (status == 1)
            {
                if (existingMeeting != null && existingMeeting.Name.Trim().ToLower() == name.ToLower())
                {
                    MessageBox.Show("Cuộc họp đã tồn tại trong lịch rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Lịch hẹn đã trùng với lịch cũ của bạn, bạn có muốn thay thế không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.No) return;
                }
            }
            else if (status == 2)
            {
                DialogResult dr = MessageBox.Show("Lịch hẹn này trùng với 1 group meeting, bạn có muốn tham gia không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
            }

            List<int> reminderMinutes = new List<int>();
            DialogResult drNhac = MessageBox.Show("Bạn có muốn thêm bộ nhắc?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (drNhac == DialogResult.Yes)
            {
                ReminderForm frm = new ReminderForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    reminderMinutes.AddRange(frm.SelectedReminders);
                }
            }

            logic.ProcessMeeting(currentUserId, name, location, date, startHour, endHour, isGroup, reminderMinutes, status, existingMeeting);

            if (status == 1)
                MessageBox.Show("Đã thay thế lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (status == 2)
                MessageBox.Show("Đã tham gia nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Đã thêm lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                var cuocHenVuaTao = db.Appointments
                                      .Where(a => a.Name == name && a.StartTime.Date == date.Date)
                                      .OrderByDescending(a => a.AppointmentID)
                                      .FirstOrDefault();

                if (cuocHenVuaTao != null)
                {
                    this.Hide();
                    CalenderApp.VIEW.FullAppointmentListForm frmDanhSach = new CalenderApp.VIEW.FullAppointmentListForm();
                    frmDanhSach.ShowDialog();
                }
            }
            catch (Exception)
            {
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
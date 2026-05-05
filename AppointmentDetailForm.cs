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
            string name = textBox1.Text;
            string location =textBox2.Text;

            // Rút trích đúng cái số giờ (Hour) từ DateTimePicker
            int startHour = dateTimePicker1.Value.Hour;
            int endHour = dateTimePicker2.Value.Hour;

            bool isGroup = radioButton2.Checked; // radioButton2 là nút chọn Lịch Nhóm
            DateTime date = _selectedDate; // Dùng đúng biến ngày được truyền từ Form Lịch sang

            int currentUserId = 1; // ID của bạn trong Database

            // Gọi class thuật toán 
            CalenderApp.BLL.MeetingLogic logic = new CalenderApp.BLL.MeetingLogic();

            // 2. KIỂM TRA ĐẦU VÀO (Bỏ trống, sai giờ)
            string error = logic.ValidateInput(name, location, startHour, endHour);
            if (error != "")
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. THUẬT TOÁN CHECK TRÙNG LỊCH & MATCH GROUP
            Appointment existingMeeting;
            int status = logic.CheckMeetingStatus(currentUserId, name, date, startHour, endHour, out existingMeeting);

            if (status == 1) // Trùng lịch cá nhân
            {
                DialogResult dr = MessageBox.Show("Lịch hẹn đã trùng với lịch cũ của bạn, bạn có muốn thay thế không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;
            }
            else if (status == 2) // Trùng lịch nhóm
            {
                DialogResult dr = MessageBox.Show("Lịch hẹn này trùng với 1 group meeting, bạn có muốn tham gia không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
            }

            // 4. HỎI THÊM BỘ NHẮC
            List<int> reminderMinutes = new List<int>();
            DialogResult drNhac = MessageBox.Show("Bạn có muốn thêm bộ nhắc?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (drNhac == DialogResult.Yes)
            {
                // Tạm thời fix cứng nhắc trước 15 phút để test. 
                // Lát nữa sang Chặng 3 mình sẽ mở Form Bộ Nhắc ở đây!
                reminderMinutes.Add(15);
            }

            // 5. LƯU XUỐNG DATABASE
            logic.ProcessMeeting(currentUserId, name, location, date, startHour, endHour, isGroup, reminderMinutes, status, existingMeeting);

            // 6. THÔNG BÁO VÀ ĐÓNG FORM
            if (status == 1)
                MessageBox.Show("Đã thay thế lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Đã thêm lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK; // Báo cho Form chính biết là đã lưu thành công
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var startTime = _selectedDate.Add(dateTimePicker1.Value.TimeOfDay);
            var endTime = _selectedDate.Add(dateTimePicker2.Value.TimeOfDay);

            var service = new BLL.AppointmentService();
            string errorMessage;
            var isGroupMeeting = radioButton2.Checked;

            if (!service.TryCreateAppointment(textBox1.Text, textBox2.Text, startTime, endTime, isGroupMeeting, 1, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

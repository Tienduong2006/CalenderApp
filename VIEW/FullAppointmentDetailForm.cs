using CalenderApp.DTO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CalenderApp.VIEW
{
    public partial class FullAppointmentDetailForm : Form
    {
        private int _appointmentId;

        public FullAppointmentDetailForm()
        {
            InitializeComponent();
        }

        public FullAppointmentDetailForm(int appointmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
        }

        private void FullAppointmentDetailForm_Load(object sender, EventArgs e)
        {
            LoadDuLieuSuKien();
        }

        private void LoadDuLieuSuKien()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var appt = db.Appointments.FirstOrDefault(a => a.AppointmentID == _appointmentId);
            if (appt == null) return;

            lblTenSuKien.Text = appt.Name;
            lblViTri.Text = appt.Location;
            lblNgay.Text = appt.StartTime.ToString("dd/MM/yyyy");
            lblBatDau.Text = appt.StartTime.ToString("HH 'giờ'");
            lblKetThuc.Text = appt.EndTime.ToString("HH 'giờ'");

            lstDanhSachNhac.Clear();
            var dsNhac = db.Reminders.Where(r => r.AppointmentID == _appointmentId).ToList();

            if (dsNhac.Count > 0)
            {
                foreach (var r in dsNhac)
                {
                    string hienThi = "";
                    if (r.MinutesBefore == 15)
                        hienThi = "Nhắc trước 15 phút";
                    else if (r.MinutesBefore == 1440)
                        hienThi = "Nhắc trước 1 ngày";
                    else
                        hienThi = "Nhắc trước " + r.MinutesBefore + " phút";

                    lstDanhSachNhac.AppendText(hienThi + Environment.NewLine);
                }
            }
            else
            {
                lstDanhSachNhac.AppendText("(Không có nhắc nhở)");
            }

            var dsNguoiThamGia = from p in db.GroupParticipants
                                 join u in db.Users on p.UserID equals u.UserID
                                 where p.AppointmentID == _appointmentId
                                 select new
                                 {
                                     ID = u.UserID,
                                     Name = u.UserName,
                                     Email = u.Email
                                 };

            dgvNguoiThamGia.DataSource = dsNguoiThamGia.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
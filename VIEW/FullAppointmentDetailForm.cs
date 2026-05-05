using CalenderApp.BLL;
using CalenderApp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CalenderApp.VIEW
{
    public partial class FullAppointmentDetailForm : Form
    {
        AppointmentBLL bll = new AppointmentBLL();
        private int currentEventId;

        BindingList<ParticipantDTO> danhSachTam = new BindingList<ParticipantDTO>();
        List<ParticipantDTO> danhSachGoc = new List<ParticipantDTO>();

        public FullAppointmentDetailForm(int eventId)
        {
            InitializeComponent();
            currentEventId = eventId;
        }

        private void FullAppointmentDetailForm_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void LoadDuLieu()
        {
            var detail = bll.GetAppointmentDetail(currentEventId);

            if (detail != null)
            {
                lblTenSuKien.Text = detail.Name;
                lblViTri.Text = detail.Location;
                lblNgay.Text = detail.StartTime.ToString("dd/MM/yyyy");
                lblBatDau.Text = detail.StartTime.ToString("HH:mm");
                lblKetThuc.Text = detail.EndTime.ToString("HH:mm");
            }

            // ===== Nhắc nhở =====
            lstDanhSachNhac.Clear();
            var reminders = bll.GetReminders(currentEventId);

            if (reminders != null && reminders.Count > 0)
            {
                foreach (var r in reminders)
                {
                    string text = "";

                    if (r.MinutesBefore == 15)
                        text = "Nhắc trước 15 phút";
                    else if (r.MinutesBefore == 1440)
                        text = "Nhắc trước 1 ngày";
                    else
                        text = $"Nhắc trước {r.MinutesBefore} phút";

                    lstDanhSachNhac.AppendText(text + Environment.NewLine);
                }
            }
            else
            {
                lstDanhSachNhac.AppendText("(Không có nhắc nhở)");
            }

            // ===== Người tham gia =====
            dgvNguoiThamGia.AllowUserToAddRows = true;

            danhSachTam.Clear();
            danhSachGoc.Clear();

            var participants = bll.GetParticipants(currentEventId);

            if (participants != null)
            {
                foreach (var p in participants)
                {
                    danhSachTam.Add(new ParticipantDTO
                    {
                        ID = p.ID,
                        Name = p.Name,
                        Email = p.Email,
                        Xoa = false
                    });

                    danhSachGoc.Add(new ParticipantDTO
                    {
                        ID = p.ID,
                        Name = p.Name,
                        Email = p.Email,
                        Xoa = false
                    });
                }
            }

            dgvNguoiThamGia.DataSource = danhSachTam;
        }

        // ===== Kiểm tra thay đổi =====
        private bool KiemTraCoThayDoi()
        {
            dgvNguoiThamGia.EndEdit();

            var hienTai = danhSachTam
                .Where(x => !string.IsNullOrWhiteSpace(x.Name) || !string.IsNullOrWhiteSpace(x.Email))
                .ToList();

            if (hienTai.Count != danhSachGoc.Count)
                return true;

            foreach (var item in hienTai)
            {
                if (item.Xoa == true) return true;

                var goc = danhSachGoc.FirstOrDefault(g => g.ID == item.ID);

                if (goc == null) return true;

                if (item.Name != goc.Name || item.Email != goc.Email)
                    return true;
            }

            return false;
        }

        // ===== Lưu =====
        private bool ThucHienLuu()
        {
            dgvNguoiThamGia.EndEdit();

            bool coXoa = danhSachTam.Any(x => x.Xoa == true);

            if (coXoa)
            {
                DialogResult confirm = MessageBox.Show(
                    "Bạn có muốn xóa những người đã chọn không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.No)
                    return false;
            }

            try
            {
                List<ParticipantDTO> finalList = new List<ParticipantDTO>();

                foreach (var item in danhSachTam)
                {
                    if (string.IsNullOrWhiteSpace(item.Name) &&
                        string.IsNullOrWhiteSpace(item.Email))
                        continue;

                    if (!item.Xoa)
                        finalList.Add(item);
                }

                bll.SaveAllParticipants(currentEventId, finalList);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                return false;
            }
        }

        // ===== Nút Đóng =====
        private void button1_Click(object sender, EventArgs e)
        {
            if (KiemTraCoThayDoi())
            {
                var hoi = MessageBox.Show(
                    "Có dữ liệu thay đổi, bạn có muốn lưu không?",
                    "Cảnh báo",
                    MessageBoxButtons.YesNoCancel);

                if (hoi == DialogResult.Yes)
                {
                    if (ThucHienLuu())
                    {
                        MessageBox.Show("Đã lưu!");
                        this.Close();
                    }
                }
                else if (hoi == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        // ===== Nút Lưu =====
        private void btnLuuDanhSach_Click(object sender, EventArgs e)
        {
            if (ThucHienLuu())
            {
                MessageBox.Show("Lưu thành công!");
                LoadDuLieu();
            }
        }
    }
}
using CalenderApp.BLL;
using CalenderApp.DTO;
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
    public partial class AppointmentDetailForm : Form
    {
        AppointmentBLL bll = new AppointmentBLL();
        private int currentEventId;
        public AppointmentDetailForm(int eventId)
        {
            InitializeComponent(); 
            currentEventId = eventId;
        }
        BindingList<ParticipantDTO> danhSachTam = new BindingList<ParticipantDTO>(); 
        List<ParticipantDTO> danhSachGoc = new List<ParticipantDTO>();
        private void AppointmentDetailForm_Load_1(object sender, EventArgs e)
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

            dgvNguoiThamGia.AllowUserToAddRows = true;

            danhSachTam.Clear();
            danhSachGoc.Clear(); 

            var participants = bll.GetParticipants(currentEventId);
            if (participants != null)
            {
                foreach (var p in participants)
                {
                    danhSachTam.Add(new ParticipantDTO { ID = p.ID, Name = p.Name, Email = p.Email, Xoa = false });
                    danhSachGoc.Add(new ParticipantDTO { ID = p.ID, Name = p.Name, Email = p.Email, Xoa = false });
                }
            }
            dgvNguoiThamGia.DataSource = danhSachTam;
        }
        private bool KiemTraCoThayDoi()
        {
            dgvNguoiThamGia.EndEdit();
            var danhSachHienTai = danhSachTam.Where(x => !string.IsNullOrWhiteSpace(x.Name) || !string.IsNullOrWhiteSpace(x.Email)).ToList();
            if (danhSachHienTai.Count != danhSachGoc.Count)
            {
                return true;
            }

            foreach (var item in danhSachHienTai)
            {
                if (item.Xoa == true) return true;

                var nguoiGoc = danhSachGoc.FirstOrDefault(g => g.ID == item.ID);

                if (nguoiGoc == null) return true;

                if (item.Name != nguoiGoc.Name || item.Email != nguoiGoc.Email)
                {
                    return true; 
                }
            }

            return false;
        }

        private bool ThucHienLuu()
        {
            dgvNguoiThamGia.EndEdit(); 

            bool coNguoiBiXoa = danhSachTam.Any(x => x.Xoa == true);

            if (coNguoiBiXoa)
            {
                DialogResult xacNhanXoa = MessageBox.Show("Bạn có muốn xóa những người đã chọn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (xacNhanXoa == DialogResult.No)
                {
                    return false; 
                }
            }

            try
            {
                List<ParticipantDTO> danhSachChot = new List<ParticipantDTO>();
                foreach (var item in danhSachTam)
                {
                    if (string.IsNullOrWhiteSpace(item.Name) && string.IsNullOrWhiteSpace(item.Email)) continue;

                    if (item.Xoa == false)
                    {
                        danhSachChot.Add(item);
                    }
                }
                bll.SaveAllParticipants(currentEventId, danhSachChot);
                return true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (KiemTraCoThayDoi() == true)
            {
                DialogResult hoiLuu = MessageBox.Show("Có dữ liệu được thay đổi, bạn có muốn lưu không?", "Cảnh báo chưa lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (hoiLuu == DialogResult.Yes)
                {
                    if (ThucHienLuu() == true)
                    {
                        MessageBox.Show("Đã lưu dữ liệu trước khi thoát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else if (hoiLuu == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnLuuDanhSach_Click(object sender, EventArgs e)
        {
            if (ThucHienLuu() == true)
            {
                MessageBox.Show("Đã lưu toàn bộ thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AppointmentDetailForm_Load_1(sender, e);
            }
        }
    }
}

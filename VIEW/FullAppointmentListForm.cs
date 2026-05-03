using CalenderApp.BLL;
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
    public partial class FullAppointmentListForm : Form
    {
        AppointmentBLL bll = new AppointmentBLL();
        public FullAppointmentListForm()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            // Đổ dữ liệu vào bảng
            dgvAppointments.DataSource = bll.GetList();
            dgvAppointments.Columns["ID"].HeaderText = "Mã sự kiện";
            dgvAppointments.Columns["Title"].HeaderText = "Tên sự kiện";
            dgvAppointments.Columns["Location"].HeaderText = "Vị trí";
            dgvAppointments.Columns["Date"].HeaderText = "Ngày diễn ra";
            dgvAppointments.Columns["StartHour"].HeaderText = "Giờ bắt đầu";
            dgvAppointments.Columns["EndHour"].HeaderText = "Giờ kết thúc";
            dgvAppointments.Columns["Type"].HeaderText = "Kiểu nhóm";

            // tạo sự kiện
            dgvAppointments.Columns["ID"].ReadOnly = true;
            dgvAppointments.Columns["Date"].ReadOnly = true;
            dgvAppointments.Columns["StartHour"].ReadOnly = true;
            dgvAppointments.Columns["EndHour"].ReadOnly = true;
            dgvAppointments.Columns["Type"].ReadOnly = true;
            dgvAppointments.Columns["Title"].ReadOnly = false;
            dgvAppointments.Columns["Location"].ReadOnly = false;
        }

        private void FullAppointmentListForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvAppointments.Rows)
                {
                    if (row.IsNewRow) continue;
                    int id = Convert.ToInt32(row.Cells["ID"].Value);
                    string title = row.Cells["Title"].Value?.ToString() ?? "";
                    string location = row.Cells["Location"].Value?.ToString() ?? "";
                    bll.UpdateAppointment(id, title, location);
                }
                MessageBox.Show("Đã lưu toàn bộ thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                int eventId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["ID"].Value);
                string eventName = dgvAppointments.CurrentRow.Cells["Title"].Value?.ToString() ?? "Sự kiện này";
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa '{eventName}' không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bll.DeleteAppointment(eventId); 
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); 
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sự kiện để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                int eventId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["ID"].Value);
                using (var detailForm = new FullAppointmentDetailForm(eventId))
                {
                    detailForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sự kiện để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

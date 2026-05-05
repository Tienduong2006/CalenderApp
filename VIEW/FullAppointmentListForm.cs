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

        // Cắm cờ theo dõi: Mặc định là chưa có thay đổi nào
        private bool coThayDoi = false;

        public FullAppointmentListForm()
        {
            InitializeComponent();

            // Lắng nghe sự kiện: Hễ người dùng sửa giá trị ô nào là tự động bật cờ
            dgvAppointments.CellValueChanged += DgvAppointments_CellValueChanged;
        }

        private void DgvAppointments_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            coThayDoi = true;
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

            // Đã tải xong dữ liệu mới, đặt lại cờ thay đổi về false
            coThayDoi = false;
        }

        private void FullAppointmentListForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // --- Tách logic Lưu ra thành hàm riêng để tái sử dụng ---
        private bool ThucHienLuu()
        {
            try
            {
                // Chốt dữ liệu ô đang gõ dở
                dgvAppointments.EndEdit();

                foreach (DataGridViewRow row in dgvAppointments.Rows)
                {
                    if (row.IsNewRow) continue;
                    int id = Convert.ToInt32(row.Cells["ID"].Value);
                    string title = row.Cells["Title"].Value?.ToString() ?? "";
                    string location = row.Cells["Location"].Value?.ToString() ?? "";

                    bll.UpdateAppointment(id, title, location);
                }

                // Lưu xong thì hạ cờ xuống
                coThayDoi = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            // Nếu lưu thành công thì báo cáo và tải lại bảng
            if (ThucHienLuu())
            {
                MessageBox.Show("Đã lưu toàn bộ thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Chốt dữ liệu nếu người dùng đang gõ dở 1 ô mà chưa kịp click chuột ra ngoài
            dgvAppointments.EndEdit();

            // Kiểm tra lá cờ
            if (coThayDoi)
            {
                DialogResult result = MessageBox.Show("Có dữ liệu được thay đổi, bạn có muốn lưu không?", "Cảnh báo chưa lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Chọn YES: Lưu xong rồi mới làm mới
                    if (ThucHienLuu())
                    {
                        MessageBox.Show("Đã lưu dữ liệu trước khi làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                else if (result == DialogResult.No)
                {
                    // Chọn NO: Kệ dữ liệu cũ, làm mới luôn
                    LoadData();
                }
                // Nếu chọn CANCEL thì form đứng im không làm gì cả
            }
            else
            {
                // Nếu không có thay đổi gì thì cứ vô tư làm mới thôi
                LoadData();
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
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CalenderApp.VIEW
{
    public partial class ReminderForm : Form
    {
        public List<int> SelectedReminders { get; private set; } = new List<int>();

        public ReminderForm()
        {
            InitializeComponent();

            if (cboThoiGian.Items.Count == 0)
            {
                cboThoiGian.Items.Add("15 phút trước");
                cboThoiGian.Items.Add("1 ngày trước");
            }
            cboThoiGian.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboThoiGian.SelectedItem == null) return;

            string selectedText = cboThoiGian.SelectedItem.ToString();

            if (!lstDanhSachNhac.Items.Contains(selectedText))
            {
                lstDanhSachNhac.Items.Add(selectedText);

                if (selectedText == "15 phút trước") SelectedReminders.Add(15);
                else if (selectedText == "1 ngày trước") SelectedReminders.Add(1440);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
namespace CalenderApp.VIEW
{
    partial class FullAppointmentDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstDanhSachNhac = new System.Windows.Forms.TextBox();
            this.lblKetThuc = new System.Windows.Forms.Label();
            this.lblBatDau = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblViTri = new System.Windows.Forms.Label();
            this.lblTenSuKien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvNguoiThamGia = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiThamGia)).BeginInit();
            this.SuspendLayout();

            // ===== groupBox1 (Thông tin chung) =====
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lstDanhSachNhac);
            this.groupBox1.Controls.Add(this.lblKetThuc);
            this.groupBox1.Controls.Add(this.lblBatDau);
            this.groupBox1.Controls.Add(this.lblNgay);
            this.groupBox1.Controls.Add(this.lblViTri);
            this.groupBox1.Controls.Add(this.lblTenSuKien);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(50, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 260);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Cuộc Hẹn";

            // ===== Label Nhắc Nhở =====
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(430, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Nhắc nhở:";

            // ===== TextBox Nhắc Nhở =====
            this.lstDanhSachNhac.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDanhSachNhac.Location = new System.Drawing.Point(430, 70);
            this.lstDanhSachNhac.Multiline = true;
            this.lstDanhSachNhac.Name = "lstDanhSachNhac";
            this.lstDanhSachNhac.ReadOnly = true;
            this.lstDanhSachNhac.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lstDanhSachNhac.Size = new System.Drawing.Size(220, 160);
            this.lstDanhSachNhac.TabIndex = 10;
            this.lstDanhSachNhac.BackColor = System.Drawing.SystemColors.Window;

            // ===== Labels Hiển Thị Dữ Liệu (In đậm) =====
            System.Drawing.Font dataFont = new System.Drawing.Font("Times New Roman", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.lblTenSuKien.AutoSize = true;
            this.lblTenSuKien.Font = dataFont;
            this.lblTenSuKien.Location = new System.Drawing.Point(180, 40);
            this.lblTenSuKien.Name = "lblTenSuKien";
            this.lblTenSuKien.Text = "---";

            this.lblViTri.AutoSize = true;
            this.lblViTri.Font = dataFont;
            this.lblViTri.Location = new System.Drawing.Point(180, 85);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Text = "---";

            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = dataFont;
            this.lblNgay.Location = new System.Drawing.Point(180, 130);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Text = "---";

            this.lblBatDau.AutoSize = true;
            this.lblBatDau.Font = dataFont;
            this.lblBatDau.Location = new System.Drawing.Point(180, 175);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Text = "---";

            this.lblKetThuc.AutoSize = true;
            this.lblKetThuc.Font = dataFont;
            this.lblKetThuc.Location = new System.Drawing.Point(180, 220);
            this.lblKetThuc.Name = "lblKetThuc";
            this.lblKetThuc.Text = "---";

            // ===== Labels Tiêu Đề (Chữ thường) =====
            System.Drawing.Font titleFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.label1.AutoSize = true;
            this.label1.Font = titleFont;
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Name = "label1";
            this.label1.Text = "Tên sự kiện:";

            this.label2.AutoSize = true;
            this.label2.Font = titleFont;
            this.label2.Location = new System.Drawing.Point(30, 85);
            this.label2.Name = "label2";
            this.label2.Text = "Vị trí:";

            this.label3.AutoSize = true;
            this.label3.Font = titleFont;
            this.label3.Location = new System.Drawing.Point(30, 130);
            this.label3.Name = "label3";
            this.label3.Text = "Ngày diễn ra:";

            this.label4.AutoSize = true;
            this.label4.Font = titleFont;
            this.label4.Location = new System.Drawing.Point(30, 175);
            this.label4.Name = "label4";
            this.label4.Text = "Thời gian bắt đầu:";

            this.label5.AutoSize = true;
            this.label5.Font = titleFont;
            this.label5.Location = new System.Drawing.Point(30, 220);
            this.label5.Name = "label5";
            this.label5.Text = "Thời gian kết thúc:";

            // ===== groupBox2 (Bảng người tham gia) =====
            this.groupBox2.Controls.Add(this.dgvNguoiThamGia);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(50, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Người Tham Gia";

            // ===== DataGridView =====
            this.dgvNguoiThamGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguoiThamGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguoiThamGia.Location = new System.Drawing.Point(20, 35);
            this.dgvNguoiThamGia.Name = "dgvNguoiThamGia";
            this.dgvNguoiThamGia.RowHeadersWidth = 51;
            this.dgvNguoiThamGia.RowTemplate.Height = 24;
            this.dgvNguoiThamGia.Size = new System.Drawing.Size(640, 145);
            this.dgvNguoiThamGia.TabIndex = 0;

            // ===== Button Đóng =====
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(260, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Đóng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // ===== Button Lưu =====
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(410, 525);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 45);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuuDanhSach_Click);

            // ===== Form Main =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 600);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FullAppointmentDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Cuộc Hẹn";
            this.Load += new System.EventHandler(this.FullAppointmentDetailForm_Load);

            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiThamGia)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvNguoiThamGia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblKetThuc;
        private System.Windows.Forms.Label lblBatDau;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Label lblViTri;
        private System.Windows.Forms.Label lblTenSuKien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lstDanhSachNhac;
        private System.Windows.Forms.Label label7;
    }
}
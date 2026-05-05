namespace CalenderApp.VIEW
{
    partial class ReminderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstDanhSachNhac = new System.Windows.Forms.ListBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboThoiGian = new System.Windows.Forms.ComboBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lstDanhSachNhac);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.cboThoiGian);
            this.panel1.Location = new System.Drawing.Point(79, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 239);
            this.panel1.TabIndex = 0;
            // 
            // lstDanhSachNhac
            // 
            this.lstDanhSachNhac.FormattingEnabled = true;
            this.lstDanhSachNhac.ItemHeight = 16;
            this.lstDanhSachNhac.Location = new System.Drawing.Point(19, 65);
            this.lstDanhSachNhac.Name = "lstDanhSachNhac";
            this.lstDanhSachNhac.Size = new System.Drawing.Size(265, 148);
            this.lstDanhSachNhac.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(209, 18);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboThoiGian
            // 
            this.cboThoiGian.FormattingEnabled = true;
            this.cboThoiGian.Items.AddRange(new object[] {
            "15 phút trước",
            "1 ngày trước"});
            this.cboThoiGian.Location = new System.Drawing.Point(19, 17);
            this.cboThoiGian.Name = "cboThoiGian";
            this.cboThoiGian.Size = new System.Drawing.Size(170, 24);
            this.cboThoiGian.TabIndex = 0;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(99, 362);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(89, 30);
            this.btnXacNhan.TabIndex = 1;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(275, 362);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(89, 30);
            this.btnHuyBo.TabIndex = 2;
            this.btnHuyBo.Text = "Hủy";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bộ Nhắc";
            // 
            // ReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.panel1);
            this.Name = "ReminderForm";
            this.Text = "ReminderForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstDanhSachNhac;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cboThoiGian;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Label label1;
    }
}
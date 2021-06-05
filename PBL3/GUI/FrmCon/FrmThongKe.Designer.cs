
namespace PBL3.GUI.FrmCon
{
    partial class FrmThongKe
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
            this.components = new System.ComponentModel.Container();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_tong = new System.Windows.Forms.TextBox();
            this.btnTong = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dtThoiGianSau = new System.Windows.Forms.DateTimePicker();
            this.dt_ThgianTruoc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnustriptBan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuXemCTBan = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvPhieuNhap = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.dt_TimeSau = new System.Windows.Forms.DateTimePicker();
            this.dt_timeTruoc = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.mnuStripPhieuNhap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuXemChiTietNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mnustriptBan.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.mnuStripPhieuNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txt_tong);
            this.tabPage1.Controls.Add(this.btnTong);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 588);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bán hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(761, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 103;
            this.label3.Text = "VNĐ";
            // 
            // txt_tong
            // 
            this.txt_tong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tong.Location = new System.Drawing.Point(541, 75);
            this.txt_tong.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tong.Name = "txt_tong";
            this.txt_tong.Size = new System.Drawing.Size(219, 32);
            this.txt_tong.TabIndex = 102;
            // 
            // btnTong
            // 
            this.btnTong.Location = new System.Drawing.Point(577, 26);
            this.btnTong.Name = "btnTong";
            this.btnTong.Size = new System.Drawing.Size(118, 35);
            this.btnTong.TabIndex = 3;
            this.btnTong.Text = "Tính tổng";
            this.btnTong.UseVisualStyleBackColor = true;
            this.btnTong.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.dtThoiGianSau);
            this.groupBox1.Controls.Add(this.dt_ThgianTruoc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 118);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm theo ngày";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(205, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "Tất cả";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // dtThoiGianSau
            // 
            this.dtThoiGianSau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtThoiGianSau.Location = new System.Drawing.Point(228, 33);
            this.dtThoiGianSau.Name = "dtThoiGianSau";
            this.dtThoiGianSau.Size = new System.Drawing.Size(137, 27);
            this.dtThoiGianSau.TabIndex = 2;
            this.dtThoiGianSau.Value = new System.DateTime(2021, 6, 5, 0, 0, 0, 0);
            // 
            // dt_ThgianTruoc
            // 
            this.dt_ThgianTruoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_ThgianTruoc.Location = new System.Drawing.Point(48, 32);
            this.dt_ThgianTruoc.Name = "dt_ThgianTruoc";
            this.dt_ThgianTruoc.Size = new System.Drawing.Size(123, 27);
            this.dt_ThgianTruoc.TabIndex = 2;
            this.dt_ThgianTruoc.Value = new System.DateTime(2021, 6, 5, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.ContextMenuStrip = this.mnustriptBan;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 146);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(870, 439);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã hoá đơn";
            this.columnHeader1.Width = 154;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nhân viên thanh toán";
            this.columnHeader2.Width = 197;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngày thành toán";
            this.columnHeader3.Width = 158;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Khách hàng";
            this.columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tổng tiền";
            this.columnHeader5.Width = 165;
            // 
            // mnustriptBan
            // 
            this.mnustriptBan.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnustriptBan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuXemCTBan});
            this.mnustriptBan.Name = "mnustriptBan";
            this.mnustriptBan.Size = new System.Drawing.Size(158, 28);
            // 
            // mnuXemCTBan
            // 
            this.mnuXemCTBan.Name = "mnuXemCTBan";
            this.mnuXemCTBan.Size = new System.Drawing.Size(157, 24);
            this.mnuXemCTBan.Text = "Xem chi tiết";
            this.mnuXemCTBan.Click += new System.EventHandler(this.mnuXemCTBan_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 625);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvPhieuNhap);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 588);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nhập hàng";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // lvPhieuNhap
            // 
            this.lvPhieuNhap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvPhieuNhap.ContextMenuStrip = this.mnuStripPhieuNhap;
            this.lvPhieuNhap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPhieuNhap.FullRowSelect = true;
            this.lvPhieuNhap.GridLines = true;
            this.lvPhieuNhap.HideSelection = false;
            this.lvPhieuNhap.Location = new System.Drawing.Point(3, 156);
            this.lvPhieuNhap.Name = "lvPhieuNhap";
            this.lvPhieuNhap.Size = new System.Drawing.Size(870, 429);
            this.lvPhieuNhap.TabIndex = 4;
            this.lvPhieuNhap.UseCompatibleStateImageBehavior = false;
            this.lvPhieuNhap.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Mã phiếu nhập";
            this.columnHeader6.Width = 278;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Nhân viên nhập hàng";
            this.columnHeader7.Width = 266;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ngày nhập hàng";
            this.columnHeader8.Width = 301;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAll);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.dt_TimeSau);
            this.groupBox2.Controls.Add(this.dt_timeTruoc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 118);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm theo ngày";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(205, 65);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(137, 45);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "Tất cả";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // dt_TimeSau
            // 
            this.dt_TimeSau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_TimeSau.Location = new System.Drawing.Point(228, 33);
            this.dt_TimeSau.Name = "dt_TimeSau";
            this.dt_TimeSau.Size = new System.Drawing.Size(137, 27);
            this.dt_TimeSau.TabIndex = 2;
            this.dt_TimeSau.Value = new System.DateTime(2021, 6, 5, 0, 0, 0, 0);
            // 
            // dt_timeTruoc
            // 
            this.dt_timeTruoc.CustomFormat = "";
            this.dt_timeTruoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_timeTruoc.Location = new System.Drawing.Point(48, 32);
            this.dt_timeTruoc.Name = "dt_timeTruoc";
            this.dt_timeTruoc.Size = new System.Drawing.Size(123, 27);
            this.dt_timeTruoc.TabIndex = 2;
            this.dt_timeTruoc.Value = new System.DateTime(2021, 6, 5, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "đến";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Từ";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::PBL3.Properties.Resources.search_icon__4_;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(62, 65);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(120, 45);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::PBL3.Properties.Resources.search_icon__4_;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(62, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 45);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // mnuStripPhieuNhap
            // 
            this.mnuStripPhieuNhap.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuStripPhieuNhap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuXemChiTietNhap});
            this.mnuStripPhieuNhap.Name = "mnuStripPhieuNhap";
            this.mnuStripPhieuNhap.Size = new System.Drawing.Size(158, 28);
            // 
            // mnuXemChiTietNhap
            // 
            this.mnuXemChiTietNhap.Name = "mnuXemChiTietNhap";
            this.mnuXemChiTietNhap.Size = new System.Drawing.Size(210, 24);
            this.mnuXemChiTietNhap.Text = "Xem chi tiết";
            this.mnuXemChiTietNhap.Click += new System.EventHandler(this.mnuXemChiTietNhap_Click);
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 625);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmThongKe";
            this.Text = "FrmThongKe";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mnustriptBan.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.mnuStripPhieuNhap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_tong;
        private System.Windows.Forms.Button btnTong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DateTimePicker dtThoiGianSau;
        private System.Windows.Forms.DateTimePicker dt_ThgianTruoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lvPhieuNhap;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dt_TimeSau;
        private System.Windows.Forms.DateTimePicker dt_timeTruoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip mnustriptBan;
        private System.Windows.Forms.ToolStripMenuItem mnuXemCTBan;
        private System.Windows.Forms.ContextMenuStrip mnuStripPhieuNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuXemChiTietNhap;
    }
}
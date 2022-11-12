namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.bill
{
    partial class ucBillPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbSearch = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dtpTime2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpTime1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.cbbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbFillter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExcel = new FontAwesome.Sharp.IconButton();
            this.lblDate1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDate2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.itemTopProduct1 = new BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item.ItemTopProduct();
            this.itemTransactionHistory1 = new BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item.ItemTransactionHistory();
            this.itemProduct1 = new BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item.ItemProduct();
            this.itemNewCustomer1 = new BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item.ItemNewCustomer();
            this.grbSearch.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSearch
            // 
            this.grbSearch.Controls.Add(this.dtpTime2);
            this.grbSearch.Controls.Add(this.dtpTime1);
            this.grbSearch.Controls.Add(this.btnSearch);
            this.grbSearch.Controls.Add(this.cbbType);
            this.grbSearch.Controls.Add(this.cbbFillter);
            this.grbSearch.Controls.Add(this.txtSearch);
            this.grbSearch.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grbSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.grbSearch.ForeColor = System.Drawing.Color.White;
            this.grbSearch.Location = new System.Drawing.Point(0, 576);
            this.grbSearch.Name = "grbSearch";
            this.grbSearch.Size = new System.Drawing.Size(1358, 154);
            this.grbSearch.TabIndex = 0;
            this.grbSearch.Text = "Tìm kiếm hóa đơn";
            // 
            // dtpTime2
            // 
            this.dtpTime2.Checked = true;
            this.dtpTime2.FillColor = System.Drawing.Color.White;
            this.dtpTime2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTime2.ForeColor = System.Drawing.Color.Black;
            this.dtpTime2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTime2.Location = new System.Drawing.Point(1115, 75);
            this.dtpTime2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTime2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTime2.Name = "dtpTime2";
            this.dtpTime2.Size = new System.Drawing.Size(200, 36);
            this.dtpTime2.TabIndex = 7;
            this.dtpTime2.Value = new System.DateTime(2022, 11, 5, 18, 43, 7, 333);
            // 
            // dtpTime1
            // 
            this.dtpTime1.Checked = true;
            this.dtpTime1.FillColor = System.Drawing.Color.White;
            this.dtpTime1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTime1.ForeColor = System.Drawing.Color.Black;
            this.dtpTime1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTime1.Location = new System.Drawing.Point(894, 75);
            this.dtpTime1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTime1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTime1.Name = "dtpTime1";
            this.dtpTime1.Size = new System.Drawing.Size(200, 36);
            this.dtpTime1.TabIndex = 6;
            this.dtpTime1.Value = new System.DateTime(2022, 11, 5, 18, 43, 3, 680);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearch.IconColor = System.Drawing.Color.White;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 30;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(687, 75);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(121, 36);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // cbbType
            // 
            this.cbbType.BackColor = System.Drawing.Color.Transparent;
            this.cbbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbType.ItemHeight = 30;
            this.cbbType.Location = new System.Drawing.Point(488, 75);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(193, 36);
            this.cbbType.TabIndex = 2;
            // 
            // cbbFillter
            // 
            this.cbbFillter.BackColor = System.Drawing.Color.Transparent;
            this.cbbFillter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbFillter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFillter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbFillter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbFillter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbbFillter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbFillter.ItemHeight = 30;
            this.cbbFillter.Location = new System.Drawing.Point(319, 75);
            this.cbbFillter.Name = "cbbFillter";
            this.cbbFillter.Size = new System.Drawing.Size(163, 36);
            this.cbbFillter.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(38, 75);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(275, 36);
            this.txtSearch.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.itemNewCustomer1);
            this.pnlMain.Controls.Add(this.itemProduct1);
            this.pnlMain.Controls.Add(this.itemTransactionHistory1);
            this.pnlMain.Controls.Add(this.itemTopProduct1);
            this.pnlMain.Controls.Add(this.grbSearch);
            this.pnlMain.Controls.Add(this.pnlTitle);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1358, 730);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.Controls.Add(this.btnExcel);
            this.pnlTitle.Location = new System.Drawing.Point(0, 34);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1358, 100);
            this.pnlTitle.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnExcel.IconColor = System.Drawing.Color.White;
            this.btnExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExcel.IconSize = 30;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(1196, 27);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(119, 39);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = false;
            // 
            // lblDate1
            // 
            this.lblDate1.BackColor = System.Drawing.Color.Transparent;
            this.lblDate1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDate1.ForeColor = System.Drawing.Color.Black;
            this.lblDate1.Location = new System.Drawing.Point(854, 78);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(23, 23);
            this.lblDate1.TabIndex = 4;
            this.lblDate1.Text = "Từ: ";
            // 
            // lblDate2
            // 
            this.lblDate2.BackColor = System.Drawing.Color.Transparent;
            this.lblDate2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDate2.ForeColor = System.Drawing.Color.Black;
            this.lblDate2.Location = new System.Drawing.Point(1100, 75);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(9, 23);
            this.lblDate2.TabIndex = 5;
            this.lblDate2.Text = "-";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(38, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sách hóa đơn";
            // 
            // itemTopProduct1
            // 
            this.itemTopProduct1.BackColor = System.Drawing.Color.White;
            this.itemTopProduct1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.itemTopProduct1.ForeColor = System.Drawing.Color.Black;
            this.itemTopProduct1.Location = new System.Drawing.Point(216, 269);
            this.itemTopProduct1.Name = "itemTopProduct1";
            this.itemTopProduct1.Size = new System.Drawing.Size(445, 41);
            this.itemTopProduct1.TabIndex = 1;
            // 
            // itemTransactionHistory1
            // 
            this.itemTransactionHistory1.BackColor = System.Drawing.Color.White;
            this.itemTransactionHistory1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.itemTransactionHistory1.Location = new System.Drawing.Point(712, 228);
            this.itemTransactionHistory1.Name = "itemTransactionHistory1";
            this.itemTransactionHistory1.Size = new System.Drawing.Size(332, 41);
            this.itemTransactionHistory1.TabIndex = 2;
            // 
            // itemProduct1
            // 
            this.itemProduct1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.itemProduct1.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold);
            this.itemProduct1.Location = new System.Drawing.Point(531, 353);
            this.itemProduct1.Name = "itemProduct1";
            this.itemProduct1.Size = new System.Drawing.Size(262, 164);
            this.itemProduct1.TabIndex = 3;
            // 
            // itemNewCustomer1
            // 
            this.itemNewCustomer1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.itemNewCustomer1.Location = new System.Drawing.Point(824, 353);
            this.itemNewCustomer1.Name = "itemNewCustomer1";
            this.itemNewCustomer1.Size = new System.Drawing.Size(361, 41);
            this.itemNewCustomer1.TabIndex = 4;
            // 
            // ucBillPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "ucBillPanel";
            this.Size = new System.Drawing.Size(1358, 730);
            this.grbSearch.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GroupBox grbSearch;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTime2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTime1;
        private FontAwesome.Sharp.IconButton btnSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbbType;
        private Guna.UI2.WinForms.Guna2ComboBox cbbFillter;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlTitle;
        private FontAwesome.Sharp.IconButton btnExcel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private usercontrol.item.ItemNewCustomer itemNewCustomer1;
        private usercontrol.item.ItemProduct itemProduct1;
        private usercontrol.item.ItemTransactionHistory itemTransactionHistory1;
        private usercontrol.item.ItemTopProduct itemTopProduct1;
    }
}

﻿namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol
{
    partial class EmployeeControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grpSearch = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpList = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvListEmployee = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.btnReload = new FontAwesome.Sharp.IconButton();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.btnInfor = new FontAwesome.Sharp.IconButton();
            this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cbEmployeeCode = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlTitle.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListEmployee)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.Controls.Add(this.iconButton2);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1813, 100);
            this.pnlTitle.TabIndex = 1;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(1652, 22);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(144, 47);
            this.iconButton2.TabIndex = 3;
            this.iconButton2.Text = "Xuất file Excel";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(65, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách Nhân Viên";
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.label3);
            this.grpSearch.Controls.Add(this.label2);
            this.grpSearch.Controls.Add(this.grpList);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.cboStatus);
            this.grpSearch.Controls.Add(this.cbEmployeeCode);
            this.grpSearch.Controls.Add(this.txtName);
            this.grpSearch.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grpSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpSearch.ForeColor = System.Drawing.Color.White;
            this.grpSearch.Location = new System.Drawing.Point(0, 100);
            this.grpSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(1813, 799);
            this.grpSearch.TabIndex = 2;
            this.grpSearch.Text = "Tìm kiếm";
            this.grpSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(267, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tên NV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(77, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mã NV";
            // 
            // grpList
            // 
            this.grpList.BackColor = System.Drawing.Color.GhostWhite;
            this.grpList.Controls.Add(this.dgvListEmployee);
            this.grpList.Controls.Add(this.pnlButton);
            this.grpList.Controls.Add(this.guna2CircleProgressBar1);
            this.grpList.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grpList.CustomBorderThickness = new System.Windows.Forms.Padding(1, 40, 1, 1);
            this.grpList.FillColor = System.Drawing.Color.WhiteSmoke;
            this.grpList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpList.ForeColor = System.Drawing.Color.White;
            this.grpList.Location = new System.Drawing.Point(0, 213);
            this.grpList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(1813, 586);
            this.grpList.TabIndex = 5;
            this.grpList.Text = "Danh sách Nhân Viên";
            this.grpList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.grpList.Click += new System.EventHandler(this.grpList_Click);
            // 
            // dgvListEmployee
            // 
            this.dgvListEmployee.AllowUserToAddRows = false;
            this.dgvListEmployee.AllowUserToDeleteRows = false;
            this.dgvListEmployee.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(189)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListEmployee.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListEmployee.ColumnHeadersHeight = 30;
            this.dgvListEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(187)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListEmployee.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListEmployee.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvListEmployee.Location = new System.Drawing.Point(0, 39);
            this.dgvListEmployee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvListEmployee.Name = "dgvListEmployee";
            this.dgvListEmployee.ReadOnly = true;
            this.dgvListEmployee.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(187)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(187)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListEmployee.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListEmployee.RowHeadersVisible = false;
            this.dgvListEmployee.RowHeadersWidth = 51;
            this.dgvListEmployee.RowTemplate.Height = 30;
            this.dgvListEmployee.Size = new System.Drawing.Size(1809, 454);
            this.dgvListEmployee.TabIndex = 9;
            this.dgvListEmployee.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListEmployee.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListEmployee.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListEmployee.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListEmployee.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListEmployee.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListEmployee.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvListEmployee.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListEmployee.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListEmployee.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.dgvListEmployee.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListEmployee.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListEmployee.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvListEmployee.ThemeStyle.ReadOnly = true;
            this.dgvListEmployee.ThemeStyle.RowsStyle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvListEmployee.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListEmployee.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.dgvListEmployee.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListEmployee.ThemeStyle.RowsStyle.Height = 30;
            this.dgvListEmployee.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListEmployee.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListEmployee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListEmployee_CellClick);
            // 
            // pnlButton
            // 
            this.pnlButton.BackColor = System.Drawing.Color.White;
            this.pnlButton.Controls.Add(this.btnAdd);
            this.pnlButton.Controls.Add(this.btnReload);
            this.pnlButton.Controls.Add(this.btnDelete);
            this.pnlButton.Controls.Add(this.btnInfor);
            this.pnlButton.Location = new System.Drawing.Point(0, 486);
            this.pnlButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(1813, 100);
            this.pnlButton.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAdd.IconColor = System.Drawing.Color.Black;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 30;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(560, 26);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(144, 44);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBack;
            this.btnReload.IconColor = System.Drawing.Color.Black;
            this.btnReload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReload.IconSize = 30;
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReload.Location = new System.Drawing.Point(1596, 26);
            this.btnReload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(144, 44);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Làm Mới";
            this.btnReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnDelete.IconColor = System.Drawing.Color.Black;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 30;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(1087, 26);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 44);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "   Xóa";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInfor
            // 
            this.btnInfor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnInfor.FlatAppearance.BorderSize = 0;
            this.btnInfor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInfor.ForeColor = System.Drawing.Color.White;
            this.btnInfor.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnInfor.IconColor = System.Drawing.Color.Black;
            this.btnInfor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInfor.IconSize = 30;
            this.btnInfor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfor.Location = new System.Drawing.Point(75, 26);
            this.btnInfor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInfor.Name = "btnInfor";
            this.btnInfor.Size = new System.Drawing.Size(144, 44);
            this.btnInfor.TabIndex = 4;
            this.btnInfor.Text = "Chi tiết";
            this.btnInfor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInfor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInfor.UseVisualStyleBackColor = false;
            this.btnInfor.Click += new System.EventHandler(this.btnInfor_Click);
            // 
            // guna2CircleProgressBar1
            // 
            this.guna2CircleProgressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.guna2CircleProgressBar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2CircleProgressBar1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleProgressBar1.Location = new System.Drawing.Point(1167, 171);
            this.guna2CircleProgressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2CircleProgressBar1.Minimum = 0;
            this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar1.Size = new System.Drawing.Size(7, 7);
            this.guna2CircleProgressBar1.TabIndex = 1;
            this.guna2CircleProgressBar1.Text = "guna2CircleProgressBar1";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearch.IconColor = System.Drawing.Color.White;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 25;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSearch.Location = new System.Drawing.Point(579, 103);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(125, 36);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboStatus
            // 
            this.cboStatus.Enabled = false;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(1596, 103);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(199, 36);
            this.cboStatus.TabIndex = 2;
            // 
            // cbEmployeeCode
            // 
            this.cbEmployeeCode.FormattingEnabled = true;
            this.cbEmployeeCode.Location = new System.Drawing.Point(75, 103);
            this.cbEmployeeCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEmployeeCode.Name = "cbEmployeeCode";
            this.cbEmployeeCode.Size = new System.Drawing.Size(192, 36);
            this.cbEmployeeCode.TabIndex = 1;
            this.cbEmployeeCode.SelectedIndexChanged += new System.EventHandler(this.cbEmployeeCode_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(272, 103);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(299, 34);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // EmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.pnlTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EmployeeControl";
            this.Size = new System.Drawing.Size(1813, 898);
            this.Load += new System.EventHandler(this.EmployeeControl_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListEmployee)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox grpSearch;
        private Guna.UI2.WinForms.Guna2GroupBox grpList;
        private FontAwesome.Sharp.IconButton btnSearch;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ComboBox cbEmployeeCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pnlButton;
        private FontAwesome.Sharp.IconButton btnReload;
        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnInfor;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnAdd;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListEmployee;
    }
}

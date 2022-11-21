namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.admin.product
{
    partial class ListProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCreateProduct = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.cbSort = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblQuantityProduct = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtgDetailProduct = new Guna.UI2.WinForms.Guna2DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoAbove10 = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdo7to10 = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdo5to7 = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdo3to5 = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdo3 = new Guna.UI2.WinForms.Guna2RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtgListProduct = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetailProduct)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnSearch);
            this.guna2Panel1.Controls.Add(this.txtSearch);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.iconPictureBox1);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1360, 55);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearch.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnSearch.IconSize = 40;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(1088, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 40);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Animated = true;
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BorderRadius = 18;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(887, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Tìm kiếm sản phẩm . .  .";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(200, 38);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.label1.Location = new System.Drawing.Point(85, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh Sách Sản Phẩm";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ProductHunt;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.MenuHighlight;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 45;
            this.iconPictureBox1.Location = new System.Drawing.Point(34, 8);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(45, 45);
            this.iconPictureBox1.TabIndex = 0;
            this.iconPictureBox1.TabStop = false;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btnCreateProduct);
            this.guna2Panel2.Controls.Add(this.btnDelete);
            this.guna2Panel2.Controls.Add(this.btnEdit);
            this.guna2Panel2.Controls.Add(this.cbSort);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.lblQuantityProduct);
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 55);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1360, 60);
            this.guna2Panel2.TabIndex = 1;
            // 
            // btnCreateProduct
            // 
            this.btnCreateProduct.BorderRadius = 10;
            this.btnCreateProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreateProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreateProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateProduct.ForeColor = System.Drawing.Color.White;
            this.btnCreateProduct.Location = new System.Drawing.Point(1007, 19);
            this.btnCreateProduct.Name = "btnCreateProduct";
            this.btnCreateProduct.Size = new System.Drawing.Size(121, 25);
            this.btnCreateProduct.TabIndex = 9;
            this.btnCreateProduct.Text = "Thêm sản phẩm";
            this.btnCreateProduct.Click += new System.EventHandler(this.btnCreateProduct_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1230, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 25);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(1139, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 25);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cbSort
            // 
            this.cbSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.cbSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSort.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.cbSort.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSort.ItemHeight = 25;
            this.cbSort.Items.AddRange(new object[] {
            "Mặc định",
            "Mã sản phẩm",
            "Tên sản phẩm",
            "Số lượng"});
            this.cbSort.Location = new System.Drawing.Point(442, 13);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(182, 31);
            this.cbSort.StartIndex = 0;
            this.cbSort.TabIndex = 6;
            this.cbSort.SelectedIndexChanged += new System.EventHandler(this.cbSort_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(327, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sắp xếp theo: ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sản Phẩm";
            // 
            // lblQuantityProduct
            // 
            this.lblQuantityProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityProduct.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblQuantityProduct.Location = new System.Drawing.Point(25, 3);
            this.lblQuantityProduct.Name = "lblQuantityProduct";
            this.lblQuantityProduct.Size = new System.Drawing.Size(73, 49);
            this.lblQuantityProduct.TabIndex = 3;
            this.lblQuantityProduct.Text = "40";
            this.lblQuantityProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.dtgDetailProduct);
            this.guna2Panel3.Controls.Add(this.groupBox1);
            this.guna2Panel3.Controls.Add(this.label6);
            this.guna2Panel3.Controls.Add(this.label5);
            this.guna2Panel3.Controls.Add(this.cbCategory);
            this.guna2Panel3.Location = new System.Drawing.Point(926, 154);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(402, 530);
            this.guna2Panel3.TabIndex = 3;
            // 
            // dtgDetailProduct
            // 
            this.dtgDetailProduct.AllowUserToAddRows = false;
            this.dtgDetailProduct.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgDetailProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDetailProduct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDetailProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDetailProduct.ColumnHeadersHeight = 28;
            this.dtgDetailProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgDetailProduct.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDetailProduct.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgDetailProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgDetailProduct.Location = new System.Drawing.Point(24, 252);
            this.dtgDetailProduct.Name = "dtgDetailProduct";
            this.dtgDetailProduct.ReadOnly = true;
            this.dtgDetailProduct.RowHeadersVisible = false;
            this.dtgDetailProduct.RowTemplate.Height = 50;
            this.dtgDetailProduct.Size = new System.Drawing.Size(365, 266);
            this.dtgDetailProduct.TabIndex = 13;
            this.dtgDetailProduct.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgDetailProduct.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgDetailProduct.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgDetailProduct.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgDetailProduct.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgDetailProduct.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dtgDetailProduct.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgDetailProduct.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgDetailProduct.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgDetailProduct.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgDetailProduct.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgDetailProduct.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgDetailProduct.ThemeStyle.HeaderStyle.Height = 28;
            this.dtgDetailProduct.ThemeStyle.ReadOnly = true;
            this.dtgDetailProduct.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgDetailProduct.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgDetailProduct.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgDetailProduct.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgDetailProduct.ThemeStyle.RowsStyle.Height = 50;
            this.dtgDetailProduct.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgDetailProduct.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoAbove10);
            this.groupBox1.Controls.Add(this.rdo7to10);
            this.groupBox1.Controls.Add(this.rdo5to7);
            this.groupBox1.Controls.Add(this.rdo3to5);
            this.groupBox1.Controls.Add(this.rdo3);
            this.groupBox1.Location = new System.Drawing.Point(24, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 116);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // rdoAbove10
            // 
            this.rdoAbove10.AutoSize = true;
            this.rdoAbove10.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdoAbove10.CheckedState.BorderThickness = 0;
            this.rdoAbove10.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdoAbove10.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdoAbove10.CheckedState.InnerOffset = -4;
            this.rdoAbove10.Location = new System.Drawing.Point(204, 52);
            this.rdoAbove10.Name = "rdoAbove10";
            this.rdoAbove10.Size = new System.Drawing.Size(79, 17);
            this.rdoAbove10.TabIndex = 4;
            this.rdoAbove10.Tag = "Price > 1000000";
            this.rdoAbove10.Text = "Trên 1 triệu";
            this.rdoAbove10.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdoAbove10.UncheckedState.BorderThickness = 2;
            this.rdoAbove10.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdoAbove10.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdoAbove10.CheckedChanged += new System.EventHandler(this.rdo3_CheckedChanged);
            // 
            // rdo7to10
            // 
            this.rdo7to10.AutoSize = true;
            this.rdo7to10.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdo7to10.CheckedState.BorderThickness = 0;
            this.rdo7to10.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdo7to10.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdo7to10.CheckedState.InnerOffset = -4;
            this.rdo7to10.Location = new System.Drawing.Point(204, 19);
            this.rdo7to10.Name = "rdo7to10";
            this.rdo7to10.Size = new System.Drawing.Size(121, 17);
            this.rdo7to10.TabIndex = 3;
            this.rdo7to10.Tag = "Price >= 700000 and Price <1000000";
            this.rdo7to10.Text = "700,000 - 1,000,000";
            this.rdo7to10.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdo7to10.UncheckedState.BorderThickness = 2;
            this.rdo7to10.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdo7to10.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdo7to10.CheckedChanged += new System.EventHandler(this.rdo3_CheckedChanged);
            // 
            // rdo5to7
            // 
            this.rdo5to7.AutoSize = true;
            this.rdo5to7.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdo5to7.CheckedState.BorderThickness = 0;
            this.rdo5to7.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdo5to7.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdo5to7.CheckedState.InnerOffset = -4;
            this.rdo5to7.Location = new System.Drawing.Point(40, 84);
            this.rdo5to7.Name = "rdo5to7";
            this.rdo5to7.Size = new System.Drawing.Size(112, 17);
            this.rdo5to7.TabIndex = 2;
            this.rdo5to7.Tag = "Price >=500000 and Price <700000";
            this.rdo5to7.Text = "500,000 - 700,000";
            this.rdo5to7.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdo5to7.UncheckedState.BorderThickness = 2;
            this.rdo5to7.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdo5to7.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdo5to7.CheckedChanged += new System.EventHandler(this.rdo3_CheckedChanged);
            // 
            // rdo3to5
            // 
            this.rdo3to5.AutoSize = true;
            this.rdo3to5.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdo3to5.CheckedState.BorderThickness = 0;
            this.rdo3to5.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdo3to5.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdo3to5.CheckedState.InnerOffset = -4;
            this.rdo3to5.Location = new System.Drawing.Point(40, 52);
            this.rdo3to5.Name = "rdo3to5";
            this.rdo3to5.Size = new System.Drawing.Size(112, 17);
            this.rdo3to5.TabIndex = 1;
            this.rdo3to5.Tag = "Price >= 300000 and Price <500000";
            this.rdo3to5.Text = "300,000 - 500,000";
            this.rdo3to5.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdo3to5.UncheckedState.BorderThickness = 2;
            this.rdo3to5.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdo3to5.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdo3to5.CheckedChanged += new System.EventHandler(this.rdo3_CheckedChanged);
            // 
            // rdo3
            // 
            this.rdo3.AutoSize = true;
            this.rdo3.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdo3.CheckedState.BorderThickness = 0;
            this.rdo3.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdo3.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdo3.CheckedState.InnerOffset = -4;
            this.rdo3.Location = new System.Drawing.Point(40, 19);
            this.rdo3.Name = "rdo3";
            this.rdo3.Size = new System.Drawing.Size(89, 17);
            this.rdo3.TabIndex = 0;
            this.rdo3.Tag = "Price < 300000";
            this.rdo3.Text = "Dưới 300,000";
            this.rdo3.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdo3.UncheckedState.BorderThickness = 2;
            this.rdo3.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdo3.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdo3.CheckedChanged += new System.EventHandler(this.rdo3_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Khoảng giá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Doanh mục";
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCategory.ItemHeight = 25;
            this.cbCategory.Location = new System.Drawing.Point(24, 36);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(178, 31);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // dtgListProduct
            // 
            this.dtgListProduct.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dtgListProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgListProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgListProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgListProduct.ColumnHeadersHeight = 35;
            this.dtgListProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgListProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cImage,
            this.cID,
            this.cName,
            this.cQuantity,
            this.cCategory,
            this.cPImage});
            this.dtgListProduct.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgListProduct.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgListProduct.GridColor = System.Drawing.Color.White;
            this.dtgListProduct.Location = new System.Drawing.Point(34, 154);
            this.dtgListProduct.Name = "dtgListProduct";
            this.dtgListProduct.ReadOnly = true;
            this.dtgListProduct.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgListProduct.RowHeadersVisible = false;
            this.dtgListProduct.RowTemplate.DividerHeight = 6;
            this.dtgListProduct.RowTemplate.Height = 100;
            this.dtgListProduct.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgListProduct.Size = new System.Drawing.Size(886, 530);
            this.dtgListProduct.TabIndex = 2;
            this.dtgListProduct.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgListProduct.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgListProduct.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgListProduct.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgListProduct.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgListProduct.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgListProduct.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dtgListProduct.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dtgListProduct.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgListProduct.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.dtgListProduct.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dtgListProduct.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgListProduct.ThemeStyle.HeaderStyle.Height = 35;
            this.dtgListProduct.ThemeStyle.ReadOnly = true;
            this.dtgListProduct.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgListProduct.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgListProduct.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgListProduct.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgListProduct.ThemeStyle.RowsStyle.Height = 100;
            this.dtgListProduct.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgListProduct.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgListProduct.UseWaitCursor = true;
            this.dtgListProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListProduct_CellClick);
            // 
            // cImage
            // 
            this.cImage.HeaderText = "Ảnh";
            this.cImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.cImage.Name = "cImage";
            this.cImage.ReadOnly = true;
            // 
            // cID
            // 
            this.cID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cID.DataPropertyName = "ProductCode";
            this.cID.FillWeight = 50F;
            this.cID.HeaderText = "Mã sản phẩm";
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            this.cID.Width = 170;
            // 
            // cName
            // 
            this.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cName.DataPropertyName = "NameProduct";
            this.cName.FillWeight = 80F;
            this.cName.HeaderText = "Tên sản phẩm";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.Width = 260;
            // 
            // cQuantity
            // 
            this.cQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cQuantity.DataPropertyName = "Quantity";
            this.cQuantity.FillWeight = 91.33855F;
            this.cQuantity.HeaderText = "Số lượng";
            this.cQuantity.Name = "cQuantity";
            this.cQuantity.ReadOnly = true;
            this.cQuantity.Width = 150;
            // 
            // cCategory
            // 
            this.cCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cCategory.DataPropertyName = "CategoryCode";
            this.cCategory.FillWeight = 91.33855F;
            this.cCategory.HeaderText = "Doanh mục";
            this.cCategory.Name = "cCategory";
            this.cCategory.ReadOnly = true;
            this.cCategory.Width = 180;
            // 
            // cPImage
            // 
            this.cPImage.DataPropertyName = "Image";
            this.cPImage.HeaderText = "Path Image";
            this.cPImage.Name = "cPImage";
            this.cPImage.ReadOnly = true;
            this.cPImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cPImage.Visible = false;
            // 
            // ListProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dtgListProduct);
            this.Name = "ListProduct";
            this.Size = new System.Drawing.Size(1360, 732);
            this.Load += new System.EventHandler(this.listProduct_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetailProduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblQuantityProduct;
        private Guna.UI2.WinForms.Guna2ComboBox cbSort;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cbCategory;
        private FontAwesome.Sharp.IconButton btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2RadioButton rdoAbove10;
        private Guna.UI2.WinForms.Guna2RadioButton rdo7to10;
        private Guna.UI2.WinForms.Guna2RadioButton rdo5to7;
        private Guna.UI2.WinForms.Guna2RadioButton rdo3to5;
        private Guna.UI2.WinForms.Guna2RadioButton rdo3;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button btnCreateProduct;
        private Guna.UI2.WinForms.Guna2DataGridView dtgDetailProduct;
        private Guna.UI2.WinForms.Guna2DataGridView dtgListProduct;
        private System.Windows.Forms.DataGridViewImageColumn cImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPImage;
    }
}

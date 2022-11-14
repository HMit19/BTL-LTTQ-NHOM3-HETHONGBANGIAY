// item procduct in groupbox List Item in cart of storecontrol
namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item
{
    partial class ItemProductOfCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemProductOfCart));
            this.color = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.idItemDetail = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.total = new System.Windows.Forms.Label();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.price = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.quantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.name = new System.Windows.Forms.Label();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.index = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // color
            // 
            this.color.AutoSize = true;
            this.color.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.color.Location = new System.Drawing.Point(461, 18);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(39, 17);
            this.color.TabIndex = 17;
            this.color.Text = "Xanh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(423, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Màu: ";
            // 
            // pnlContainer
            // 
            this.pnlContainer.BorderRadius = 25;
            this.pnlContainer.Controls.Add(this.idItemDetail);
            this.pnlContainer.Controls.Add(this.label12);
            this.pnlContainer.Controls.Add(this.label13);
            this.pnlContainer.Controls.Add(this.btnDelete);
            this.pnlContainer.Controls.Add(this.guna2Separator3);
            this.pnlContainer.Controls.Add(this.total);
            this.pnlContainer.Controls.Add(this.guna2Separator2);
            this.pnlContainer.Controls.Add(this.price);
            this.pnlContainer.Controls.Add(this.size);
            this.pnlContainer.Controls.Add(this.label9);
            this.pnlContainer.Controls.Add(this.quantity);
            this.pnlContainer.Controls.Add(this.name);
            this.pnlContainer.Controls.Add(this.image);
            this.pnlContainer.Controls.Add(this.color);
            this.pnlContainer.Controls.Add(this.index);
            this.pnlContainer.Controls.Add(this.label3);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(5);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(750, 85);
            this.pnlContainer.TabIndex = 20;
            // 
            // idItemDetail
            // 
            this.idItemDetail.AutoSize = true;
            this.idItemDetail.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idItemDetail.Location = new System.Drawing.Point(534, 13);
            this.idItemDetail.Name = "idItemDetail";
            this.idItemDetail.Size = new System.Drawing.Size(0, 17);
            this.idItemDetail.TabIndex = 32;
            this.idItemDetail.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(519, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 17);
            this.label12.TabIndex = 31;
            this.label12.Text = "Thành tiền: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(151, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 17);
            this.label13.TabIndex = 30;
            this.label13.Text = "Đơn giá: ";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDelete.IconColor = System.Drawing.Color.Red;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 30;
            this.btnDelete.Location = new System.Drawing.Point(709, 26);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(27, 33);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator3.FillColor = System.Drawing.Color.LightSlateGray;
            this.guna2Separator3.Location = new System.Drawing.Point(602, 50);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(70, 12);
            this.guna2Separator3.TabIndex = 28;
            // 
            // total
            // 
            this.total.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.total.Location = new System.Drawing.Point(602, 33);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(73, 30);
            this.total.TabIndex = 27;
            this.total.Text = "100,000";
            this.total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator2.FillColor = System.Drawing.Color.LightSlateGray;
            this.guna2Separator2.Location = new System.Drawing.Point(220, 69);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(65, 11);
            this.guna2Separator2.TabIndex = 26;
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.SystemColors.InfoText;
            this.price.Location = new System.Drawing.Point(220, 54);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(65, 17);
            this.price.TabIndex = 25;
            this.price.Text = "100,000";
            this.price.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // size
            // 
            this.size.AutoSize = true;
            this.size.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size.Location = new System.Drawing.Point(458, 54);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(22, 17);
            this.size.TabIndex = 24;
            this.size.Text = "40";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(423, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Size: ";
            // 
            // quantity
            // 
            this.quantity.BackColor = System.Drawing.Color.Transparent;
            this.quantity.BorderRadius = 5;
            this.quantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.quantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quantity.Location = new System.Drawing.Point(359, 33);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(45, 25);
            this.quantity.TabIndex = 22;
            this.quantity.UpDownButtonFillColor = System.Drawing.Color.LightSkyBlue;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.ValueChanged += new System.EventHandler(this.quantity_ValueChanged);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(150, 13);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(193, 34);
            this.name.TabIndex = 21;
            this.name.Text = "Đây là tên của sản phẩm";
            // 
            // image
            // 
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(42, 2);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(80, 81);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 20;
            this.image.TabStop = false;
            // 
            // index
            // 
            this.index.AutoSize = true;
            this.index.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.index.Location = new System.Drawing.Point(10, 35);
            this.index.Name = "index";
            this.index.Size = new System.Drawing.Size(22, 17);
            this.index.TabIndex = 19;
            this.index.Text = "40";
            // 
            // ItemProductOfCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContainer);
            this.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.Name = "ItemProductOfCart";
            this.Size = new System.Drawing.Size(750, 85);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label color;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private System.Windows.Forms.Label index;
        private Guna.UI2.WinForms.Guna2PictureBox image;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private System.Windows.Forms.Label total;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private System.Windows.Forms.Label size;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2NumericUpDown quantity;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private FontAwesome.Sharp.IconButton btnDelete;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label idItemDetail;
    }
}

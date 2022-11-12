// item product in groupbox List Products of storecontrol
namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item
{
    partial class ItemProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemProduct));
            this.pnlContain = new Guna.UI2.WinForms.Guna2Panel();
            this.name = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.Label();
            this.pnlContain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContain
            // 
            this.pnlContain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContain.BackColor = System.Drawing.Color.White;
            this.pnlContain.BorderThickness = 1;
            this.pnlContain.Controls.Add(this.quantity);
            this.pnlContain.Controls.Add(this.name);
            this.pnlContain.Controls.Add(this.price);
            this.pnlContain.Controls.Add(this.image);
            this.pnlContain.Controls.Add(this.label1);
            this.pnlContain.CustomBorderColor = System.Drawing.Color.Black;
            this.pnlContain.CustomBorderThickness = new System.Windows.Forms.Padding(1);
            this.pnlContain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContain.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold);
            this.pnlContain.Location = new System.Drawing.Point(0, 0);
            this.pnlContain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContain.Name = "pnlContain";
            this.pnlContain.Size = new System.Drawing.Size(196, 169);
            this.pnlContain.TabIndex = 0;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.Black;
            this.name.Location = new System.Drawing.Point(18, 116);
            this.name.Margin = new System.Windows.Forms.Padding(0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(159, 19);
            this.name.TabIndex = 8;
            this.name.Text = "Mã giày Nike loại 1";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.DodgerBlue;
            this.price.Location = new System.Drawing.Point(24, 131);
            this.price.Margin = new System.Windows.Forms.Padding(0);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(144, 20);
            this.price.TabIndex = 2;
            this.price.Text = "100,000";
            this.price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // image
            // 
            this.image.FillColor = System.Drawing.Color.Transparent;
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(27, 4);
            this.image.Margin = new System.Windows.Forms.Padding(4);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(141, 115);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(131, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kho: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quantity
            // 
            this.quantity.Font = new System.Drawing.Font("Segoe UI Light", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.ForeColor = System.Drawing.Color.Black;
            this.quantity.Location = new System.Drawing.Point(163, 146);
            this.quantity.Margin = new System.Windows.Forms.Padding(0);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(29, 20);
            this.quantity.TabIndex = 10;
            this.quantity.Text = "10";
            this.quantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ItemProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.pnlContain);
            this.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ItemProduct";
            this.Size = new System.Drawing.Size(196, 169);
            this.pnlContain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlContain;
        private Guna.UI2.WinForms.Guna2PictureBox image;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label quantity;
        private System.Windows.Forms.Label label1;
    }
}

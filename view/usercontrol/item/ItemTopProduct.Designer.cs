// item product in groupbox List Products best seller of homecontrol
namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item
{
    partial class ItemTopProduct
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
            this.panel = new Guna.UI2.WinForms.Guna2Panel();
            this.name = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.panel.BorderThickness = 1;
            this.panel.Controls.Add(this.name);
            this.panel.Controls.Add(this.image);
            this.panel.CustomBorderColor = System.Drawing.Color.Black;
            this.panel.CustomBorderThickness = new System.Windows.Forms.Padding(1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(10);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(115, 120);
            this.panel.TabIndex = 0;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(12, 78);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(91, 37);
            this.name.TabIndex = 1;
            this.name.Text = "Adidas Run Falcon\r\n";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(21, 9);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(74, 63);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // ItemTopProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.Black;
            this.Location = new System.Drawing.Point(10, 10);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "ItemTopProduct";
            this.Size = new System.Drawing.Size(115, 120);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.PictureBox image;
    }
}

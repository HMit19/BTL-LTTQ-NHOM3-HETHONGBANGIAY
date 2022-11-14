namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item
{
    partial class ItemColor
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
            this.color = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // color
            // 
            this.color.BorderColor = System.Drawing.Color.Silver;
            this.color.BorderThickness = 1;
            this.color.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.color.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.color.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.color.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.color.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.color.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.color.ForeColor = System.Drawing.Color.Black;
            this.color.Location = new System.Drawing.Point(0, 0);
            this.color.Margin = new System.Windows.Forms.Padding(0);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(82, 32);
            this.color.TabIndex = 2;
            this.color.Text = "Color";
            this.color.Click += new System.EventHandler(this.color_Click);
            // 
            // ItemColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.color);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ItemColor";
            this.Size = new System.Drawing.Size(82, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button color;
    }
}

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item
{
    partial class ItemSize
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
            this.size = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // size
            // 
            this.size.BorderColor = System.Drawing.Color.Silver;
            this.size.BorderThickness = 1;
            this.size.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.size.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.size.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.size.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.size.Dock = System.Windows.Forms.DockStyle.Fill;
            this.size.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.size.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size.ForeColor = System.Drawing.Color.Black;
            this.size.Location = new System.Drawing.Point(0, 0);
            this.size.Margin = new System.Windows.Forms.Padding(0);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(57, 32);
            this.size.TabIndex = 2;
            this.size.Text = "Size";
            this.size.Click += new System.EventHandler(this.size_Click);
            // 
            // ItemSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.size);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ItemSize";
            this.Size = new System.Drawing.Size(57, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button size;
    }
}

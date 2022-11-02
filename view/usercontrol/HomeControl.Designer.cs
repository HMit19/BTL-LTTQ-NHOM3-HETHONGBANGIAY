namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.Manager
{
    partial class HomeControl
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
            this.dataStore1 = new BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.Manager.SumaryControl();
            this.SuspendLayout();
            // 
            // dataStore1
            // 
            this.dataStore1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataStore1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataStore1.Location = new System.Drawing.Point(184, 94);
            this.dataStore1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataStore1.Name = "dataStore1";
            this.dataStore1.Size = new System.Drawing.Size(320, 151);
            this.dataStore1.TabIndex = 0;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataStore1);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(1358, 713);
            this.ResumeLayout(false);

        }

        #endregion

        private SumaryControl dataStore1;
    }
}

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view
{
    partial class Form1
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
            this.customerInforControl1 = new BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.CustomerInforControl();
            this.importBillControl1 = new BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.ImportBillControl();
            this.saleBillControl1 = new BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.SaleBillControl();
            this.SuspendLayout();
            // 
            // customerInforControl1
            // 
            this.customerInforControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerInforControl1.Location = new System.Drawing.Point(313, 12);
            this.customerInforControl1.Name = "customerInforControl1";
            this.customerInforControl1.Size = new System.Drawing.Size(549, 921);
            this.customerInforControl1.TabIndex = 1;
            // 
            // importBillControl1
            // 
            this.importBillControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBillControl1.Location = new System.Drawing.Point(868, 12);
            this.importBillControl1.Name = "importBillControl1";
            this.importBillControl1.Size = new System.Drawing.Size(549, 867);
            this.importBillControl1.TabIndex = 2;
            // 
            // saleBillControl1
            // 
            this.saleBillControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleBillControl1.Location = new System.Drawing.Point(46, 32);
            this.saleBillControl1.Margin = new System.Windows.Forms.Padding(4);
            this.saleBillControl1.Name = "saleBillControl1";
            this.saleBillControl1.Size = new System.Drawing.Size(549, 867);
            this.saleBillControl1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1444, 956);
            this.Controls.Add(this.saleBillControl1);
            this.Controls.Add(this.importBillControl1);
            this.Controls.Add(this.customerInforControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private usercontrol.CustomerInforControl customerInforControl1;
        private usercontrol.ImportBillControl importBillControl1;
        private usercontrol.SaleBillControl saleBillControl1;
    }
}
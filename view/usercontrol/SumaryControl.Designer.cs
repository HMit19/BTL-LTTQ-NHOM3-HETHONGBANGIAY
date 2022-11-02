namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.Manager
{
    partial class SumaryControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SumaryControl));
            this.titleItem = new System.Windows.Forms.Label();
            this.detailItem = new System.Windows.Forms.Label();
            this.valueItem = new System.Windows.Forms.Label();
            this.iconItem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconItem)).BeginInit();
            this.SuspendLayout();
            // 
            // titleItem
            // 
            this.titleItem.AutoSize = true;
            this.titleItem.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleItem.Location = new System.Drawing.Point(111, 12);
            this.titleItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleItem.Name = "titleItem";
            this.titleItem.Size = new System.Drawing.Size(110, 25);
            this.titleItem.TabIndex = 0;
            this.titleItem.Text = "Type data";
            // 
            // detailItem
            // 
            this.detailItem.AutoSize = true;
            this.detailItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailItem.Location = new System.Drawing.Point(112, 106);
            this.detailItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.detailItem.Name = "detailItem";
            this.detailItem.Size = new System.Drawing.Size(42, 21);
            this.detailItem.TabIndex = 1;
            this.detailItem.Text = "text";
            // 
            // valueItem
            // 
            this.valueItem.AutoSize = true;
            this.valueItem.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueItem.Location = new System.Drawing.Point(111, 60);
            this.valueItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valueItem.Name = "valueItem";
            this.valueItem.Size = new System.Drawing.Size(70, 25);
            this.valueItem.TabIndex = 2;
            this.valueItem.Text = "Value";
            // 
            // iconItem
            // 
            this.iconItem.Image = ((System.Drawing.Image)(resources.GetObject("iconItem.Image")));
            this.iconItem.Location = new System.Drawing.Point(22, 37);
            this.iconItem.Name = "iconItem";
            this.iconItem.Size = new System.Drawing.Size(60, 65);
            this.iconItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconItem.TabIndex = 3;
            this.iconItem.TabStop = false;
            // 
            // SumaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iconItem);
            this.Controls.Add(this.valueItem);
            this.Controls.Add(this.detailItem);
            this.Controls.Add(this.titleItem);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SumaryControl";
            this.Size = new System.Drawing.Size(299, 144);
            ((System.ComponentModel.ISupportInitialize)(this.iconItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleItem;
        private System.Windows.Forms.Label detailItem;
        private System.Windows.Forms.Label valueItem;
        private System.Windows.Forms.PictureBox iconItem;
    }
}

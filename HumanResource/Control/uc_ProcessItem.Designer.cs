namespace HumanResource
{
    partial class uc_ProcessItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_ProcessItem));
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.lbTitle = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ovalShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(169, 184);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // ovalShape1
            // 
            this.ovalShape1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ovalShape1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ovalShape1.BackgroundImage")));
            this.ovalShape1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ovalShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.ovalShape1.BorderColor = System.Drawing.Color.White;
            this.ovalShape1.BorderWidth = 5;
            this.ovalShape1.FillGradientColor = System.Drawing.Color.Maroon;
            this.ovalShape1.Location = new System.Drawing.Point(23, 20);
            this.ovalShape1.Name = "ovalShape1";
            this.ovalShape1.Size = new System.Drawing.Size(122, 122);
            this.ovalShape1.Click += new System.EventHandler(this.ovalShape1_Click);
            this.ovalShape1.MouseEnter += new System.EventHandler(this.ovalShape1_MouseEnter);
            this.ovalShape1.MouseLeave += new System.EventHandler(this.ovalShape1_MouseLeave);
            // 
            // lbTitle
            // 
            this.lbTitle.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbTitle.Location = new System.Drawing.Point(46, 159);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(77, 16);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "ĐẶT PHÒNG";
            // 
            // uc_ProcessItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "uc_ProcessItem";
            this.Size = new System.Drawing.Size(169, 184);
            this.Load += new System.EventHandler(this.uc_Process_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape1;
        private DevExpress.XtraEditors.LabelControl lbTitle;
    }
}

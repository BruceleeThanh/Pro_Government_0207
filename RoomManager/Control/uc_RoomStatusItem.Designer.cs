namespace RoomManager
{
    partial class uc_RoomStatusItem
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
            this.components = new System.ComponentModel.Container();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lblSku = new DevExpress.XtraEditors.LabelControl();
            this.toolTip = new DevExpress.Utils.ToolTipController(this.components);
            this.lbWarning = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(122, 124);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.Gainsboro;
            this.rectangleShape1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.rectangleShape1.BorderWidth = 5;
            this.rectangleShape1.FillGradientColor = System.Drawing.Color.Gainsboro;
            this.rectangleShape1.Location = new System.Drawing.Point(11, 8);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(100, 105);
            this.rectangleShape1.Tag = "xxxxxxxxxxxxxxxxxxx";
            this.rectangleShape1.Click += new System.EventHandler(this.rectangleShape1_Click);
            this.rectangleShape1.MouseEnter += new System.EventHandler(this.rectangleShape1_MouseEnter);
            this.rectangleShape1.MouseLeave += new System.EventHandler(this.rectangleShape1_MouseLeave);
            // 
            // lblSku
            // 
            this.lblSku.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblSku.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.lblSku.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.lblSku.Appearance.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSku.Appearance.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblSku.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblSku.Location = new System.Drawing.Point(40, 17);
            this.lblSku.Name = "lblSku";
            this.lblSku.Size = new System.Drawing.Size(45, 32);
            this.lblSku.TabIndex = 4;
            this.lblSku.Text = "101";
            this.lblSku.ToolTipController = this.toolTip;
            this.lblSku.Click += new System.EventHandler(this.lblSku_Click_1);
            // 
            // toolTip
            // 
            this.toolTip.ToolTipLocation = DevExpress.Utils.ToolTipLocation.TopRight;
            // 
            // lbWarning
            // 
            this.lbWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWarning.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbWarning.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbWarning.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbWarning.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbWarning.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbWarning.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbWarning.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightTop;
            this.lbWarning.Location = new System.Drawing.Point(15, 56);
            this.lbWarning.Name = "lbWarning";
            this.lbWarning.Size = new System.Drawing.Size(93, 54);
            this.lbWarning.TabIndex = 5;
            this.lbWarning.Text = "Mai trả phòng";
            this.lbWarning.Visible = false;
            this.lbWarning.Click += new System.EventHandler(this.lbWarning_Click);
            // 
            // uc_RoomStatusItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.lbWarning);
            this.Controls.Add(this.lblSku);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "uc_RoomStatusItem";
            this.Size = new System.Drawing.Size(122, 124);
            this.Load += new System.EventHandler(this.uc_RoomStatusItem_Load);
            this.Click += new System.EventHandler(this.uc_RoomStatusItem_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private DevExpress.XtraEditors.LabelControl lblSku;
        private DevExpress.Utils.ToolTipController toolTip;
        private DevExpress.XtraEditors.LabelControl lbWarning;
    }
}

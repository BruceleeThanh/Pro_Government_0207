namespace RoomManager
{
    partial class frmTsk_GetCheckOutTime
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpCheckOutActual = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCheckOutActual.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCheckOutActual.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(122, 97);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "CheckOut";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(112, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 17);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "GIỜ CHECKOUT";
            // 
            // dtpCheckOutActual
            // 
            this.dtpCheckOutActual.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpCheckOutActual.EditValue = null;
            this.dtpCheckOutActual.Location = new System.Drawing.Point(55, 53);
            this.dtpCheckOutActual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpCheckOutActual.Name = "dtpCheckOutActual";
            this.dtpCheckOutActual.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpCheckOutActual.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpCheckOutActual.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtpCheckOutActual.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpCheckOutActual.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtpCheckOutActual.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpCheckOutActual.Properties.Mask.EditMask = "([012]?[1-9]|[123]0|31)/(0?[1-9]|1[012])/([123][0-9])?[0-9][0-9] (0?\\d|1\\d|2[0-3]" +
    "):[0-5]\\d";
            this.dtpCheckOutActual.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.dtpCheckOutActual.Size = new System.Drawing.Size(217, 22);
            this.dtpCheckOutActual.TabIndex = 38;
            // 
            // frmTsk_GetCheckOutTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 150);
            this.Controls.Add(this.dtpCheckOutActual);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTsk_GetCheckOutTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giờ Checkout";
            this.Load += new System.EventHandler(this.frmTsk_GetCheckOutTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpCheckOutActual.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCheckOutActual.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtpCheckOutActual;
    }
}
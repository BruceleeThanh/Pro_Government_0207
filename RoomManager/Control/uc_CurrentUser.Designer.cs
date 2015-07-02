namespace RoomManager
{
    partial class uc_CurrentUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_CurrentUser));
            this.imgUser = new DevExpress.XtraEditors.PictureEdit();
            this.lbUsername = new DevExpress.XtraEditors.LabelControl();
            this.lblNames = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.btnDetailSystemUser = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.imgUser.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgUser
            // 
            this.imgUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imgUser.EditValue = ((object)(resources.GetObject("imgUser.EditValue")));
            this.imgUser.Location = new System.Drawing.Point(3, 3);
            this.imgUser.Name = "imgUser";
            this.imgUser.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.imgUser.Size = new System.Drawing.Size(160, 160);
            this.imgUser.TabIndex = 0;
            // 
            // lbUsername
            // 
            this.lbUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbUsername.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbUsername.Location = new System.Drawing.Point(20, 32);
            this.lbUsername.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(66, 16);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "Username";
            // 
            // lblNames
            // 
            this.lblNames.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNames.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblNames.Location = new System.Drawing.Point(20, 88);
            this.lblNames.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(40, 13);
            this.lblNames.TabIndex = 2;
            this.lblNames.Text = "Names";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Location = new System.Drawing.Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tên đăng nhập:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Location = new System.Drawing.Point(3, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Họ và tên:";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Location = new System.Drawing.Point(3, 114);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Số điện thoại:";
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblPhone.Location = new System.Drawing.Point(20, 142);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(37, 13);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Phone";
            // 
            // btnDetailSystemUser
            // 
            this.btnDetailSystemUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDetailSystemUser.Enabled = false;
            this.btnDetailSystemUser.Location = new System.Drawing.Point(82, 165);
            this.btnDetailSystemUser.Name = "btnDetailSystemUser";
            this.btnDetailSystemUser.Size = new System.Drawing.Size(75, 21);
            this.btnDetailSystemUser.TabIndex = 3;
            this.btnDetailSystemUser.Text = "Chi tiết";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbUsername, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDetailSystemUser, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPhone, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblNames, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 170);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(160, 220);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // uc_CurrentUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.imgUser);
            this.Name = "uc_CurrentUser";
            this.Size = new System.Drawing.Size(166, 540);
            this.Load += new System.EventHandler(this.uc_CurrentUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgUser.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit imgUser;
        private DevExpress.XtraEditors.LabelControl lbUsername;
        private DevExpress.XtraEditors.LabelControl lblNames;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.SimpleButton btnDetailSystemUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

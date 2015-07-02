namespace HumanResource
{
    partial class frmUpd_Permits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpd_Permits));
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbbDisable = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbxIsContent = new DevExpress.XtraEditors.CheckEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.cbxIsAdmin = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblID = new DevExpress.XtraEditors.LabelControl();
            this.cbxIsPartner = new DevExpress.XtraEditors.CheckEdit();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.cbbDisable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxIsContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxIsAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxIsPartner.Properties)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(191, 5);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(82, 28);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(12, 259);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Khóa";
            // 
            // cbbDisable
            // 
            this.cbbDisable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbDisable.EditValue = "False";
            this.cbbDisable.Location = new System.Drawing.Point(93, 256);
            this.cbbDisable.Name = "cbbDisable";
            this.cbbDisable.Properties.Appearance.Options.UseTextOptions = true;
            this.cbbDisable.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbbDisable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbDisable.Properties.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbbDisable.Size = new System.Drawing.Size(200, 20);
            this.cbbDisable.TabIndex = 15;
            // 
            // cbbStatus
            // 
            this.cbbStatus.EditValue = "1";
            this.cbbStatus.Location = new System.Drawing.Point(93, 213);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Properties.Appearance.Options.UseTextOptions = true;
            this.cbbStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbStatus.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbbStatus.Size = new System.Drawing.Size(200, 20);
            this.cbbStatus.TabIndex = 14;
            // 
            // cbbType
            // 
            this.cbbType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbType.EditValue = "1";
            this.cbbType.Location = new System.Drawing.Point(93, 182);
            this.cbbType.Name = "cbbType";
            this.cbbType.Properties.Appearance.Options.UseTextOptions = true;
            this.cbbType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbType.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbbType.Size = new System.Drawing.Size(200, 20);
            this.cbbType.TabIndex = 13;
            // 
            // cbxIsContent
            // 
            this.cbxIsContent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxIsContent.Location = new System.Drawing.Point(130, 113);
            this.cbxIsContent.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.cbxIsContent.Name = "cbxIsContent";
            this.cbxIsContent.Properties.Caption = "Check/ UnCheck";
            this.cbxIsContent.Size = new System.Drawing.Size(119, 19);
            this.cbxIsContent.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.Location = new System.Drawing.Point(93, 77);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 9;
            // 
            // cbxIsAdmin
            // 
            this.cbxIsAdmin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxIsAdmin.Location = new System.Drawing.Point(130, 43);
            this.cbxIsAdmin.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.cbxIsAdmin.Name = "cbxIsAdmin";
            this.cbxIsAdmin.Properties.Caption = "Check/ UnCheck";
            this.cbxIsAdmin.Size = new System.Drawing.Size(119, 19);
            this.cbxIsAdmin.TabIndex = 10;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(12, 186);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(23, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Loại";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(12, 221);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Trạng thái";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(12, 151);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(57, 13);
            this.labelControl8.TabIndex = 7;
            this.labelControl8.Text = "Is Partner";
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Location = new System.Drawing.Point(12, 116);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(59, 13);
            this.labelControl9.TabIndex = 8;
            this.labelControl9.Text = "Is Content";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(12, 81);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(59, 13);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "Tên quyền";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(12, 46);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(50, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Is Admin";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "ID Permit";
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblID.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(130, 11);
            this.lblID.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(20, 13);
            this.lblID.TabIndex = 18;
            this.lblID.Text = "Null";
            // 
            // cbxIsPartner
            // 
            this.cbxIsPartner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxIsPartner.Location = new System.Drawing.Point(130, 148);
            this.cbxIsPartner.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.cbxIsPartner.Name = "cbxIsPartner";
            this.cbxIsPartner.Properties.Caption = "Check/ UnCheck";
            this.cbxIsPartner.Size = new System.Drawing.Size(119, 19);
            this.cbxIsPartner.TabIndex = 19;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel7, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(306, 362);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.66666F));
            this.tableLayoutPanel6.Controls.Add(this.labelControl1, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbbDisable, 2, 7);
            this.tableLayoutPanel6.Controls.Add(this.labelControl2, 1, 7);
            this.tableLayoutPanel6.Controls.Add(this.labelControl5, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.lblID, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbbStatus, 2, 6);
            this.tableLayoutPanel6.Controls.Add(this.cbxIsAdmin, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.labelControl4, 1, 6);
            this.tableLayoutPanel6.Controls.Add(this.cbbType, 2, 5);
            this.tableLayoutPanel6.Controls.Add(this.labelControl7, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.labelControl6, 1, 5);
            this.tableLayoutPanel6.Controls.Add(this.cbxIsContent, 2, 3);
            this.tableLayoutPanel6.Controls.Add(this.txtName, 2, 2);
            this.tableLayoutPanel6.Controls.Add(this.labelControl8, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.labelControl9, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.cbxIsPartner, 2, 4);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 8;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(300, 287);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.45752F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.54248F));
            this.tableLayoutPanel7.Controls.Add(this.btnEdit, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 323);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(306, 39);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // frmUpd_Permits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 362);
            this.Controls.Add(this.tableLayoutPanel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpd_Permits";
            this.Text = "Sửa Permit";
            this.Load += new System.EventHandler(this.frmUpd_Permits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbbDisable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxIsContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxIsAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxIsPartner.Properties)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cbbDisable;
        private DevExpress.XtraEditors.ComboBoxEdit cbbStatus;
        private DevExpress.XtraEditors.ComboBoxEdit cbbType;
        private DevExpress.XtraEditors.CheckEdit cbxIsContent;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.CheckEdit cbxIsAdmin;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblID;
        private DevExpress.XtraEditors.CheckEdit cbxIsPartner;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
    }
}
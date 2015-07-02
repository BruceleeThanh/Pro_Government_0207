namespace HumanResource.FormObject
{
    partial class frmUpd_Designation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpd_Designation));
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboDisable = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.txaNote = new System.Windows.Forms.TextBox();
            this.txtSignedBy = new DevExpress.XtraEditors.TextEdit();
            this.txtFileData = new DevExpress.XtraEditors.TextEdit();
            this.txtDesignationCode = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpExpireDate = new DevExpress.XtraEditors.DateEdit();
            this.dtpSignedDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDisable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesignationCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpExpireDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpExpireDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSignedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSignedDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(300, 150);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(40, 20);
            this.comboBoxEdit1.TabIndex = 55;
            // 
            // btnUpload
            // 
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.Location = new System.Drawing.Point(346, 147);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(64, 23);
            this.btnUpload.TabIndex = 54;
            this.btnUpload.Text = "Tải lên";
            // 
            // cboType
            // 
            this.cboType.EditValue = "1";
            this.cboType.Location = new System.Drawing.Point(152, 278);
            this.cboType.Name = "cboType";
            this.cboType.Properties.Appearance.Options.UseTextOptions = true;
            this.cboType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboType.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cboType.Size = new System.Drawing.Size(36, 20);
            this.cboType.TabIndex = 51;
            // 
            // cboStatus
            // 
            this.cboStatus.EditValue = "1";
            this.cboStatus.Location = new System.Drawing.Point(256, 278);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Properties.Appearance.Options.UseTextOptions = true;
            this.cboStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStatus.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cboStatus.Size = new System.Drawing.Size(40, 20);
            this.cboStatus.TabIndex = 52;
            // 
            // cboDisable
            // 
            this.cboDisable.EditValue = "True";
            this.cboDisable.Location = new System.Drawing.Point(356, 278);
            this.cboDisable.Name = "cboDisable";
            this.cboDisable.Properties.Appearance.Options.UseTextOptions = true;
            this.cboDisable.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboDisable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDisable.Properties.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboDisable.Size = new System.Drawing.Size(55, 20);
            this.cboDisable.TabIndex = 53;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl12.Location = new System.Drawing.Point(304, 281);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(41, 13);
            this.labelControl12.TabIndex = 48;
            this.labelControl12.Text = "Disable";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl11.Location = new System.Drawing.Point(194, 281);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(58, 13);
            this.labelControl11.TabIndex = 49;
            this.labelControl11.Text = "Trạng thái";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Location = new System.Drawing.Point(116, 281);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(23, 13);
            this.labelControl10.TabIndex = 50;
            this.labelControl10.Text = "Loại";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.Appearance.Options.UseFont = true;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(210, 321);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(84, 30);
            this.btnAddNew.TabIndex = 47;
            this.btnAddNew.Text = "Sửa";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(325, 321);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 30);
            this.btnReset.TabIndex = 46;
            this.btnReset.Text = "Làm lại";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txaNote
            // 
            this.txaNote.Location = new System.Drawing.Point(133, 177);
            this.txaNote.Multiline = true;
            this.txaNote.Name = "txaNote";
            this.txaNote.Size = new System.Drawing.Size(277, 81);
            this.txaNote.TabIndex = 45;
            // 
            // txtSignedBy
            // 
            this.txtSignedBy.Location = new System.Drawing.Point(133, 69);
            this.txtSignedBy.Name = "txtSignedBy";
            this.txtSignedBy.Size = new System.Drawing.Size(279, 20);
            this.txtSignedBy.TabIndex = 42;
            // 
            // txtFileData
            // 
            this.txtFileData.Location = new System.Drawing.Point(133, 151);
            this.txtFileData.Name = "txtFileData";
            this.txtFileData.Size = new System.Drawing.Size(161, 20);
            this.txtFileData.TabIndex = 41;
            // 
            // txtDesignationCode
            // 
            this.txtDesignationCode.Location = new System.Drawing.Point(133, 43);
            this.txtDesignationCode.Name = "txtDesignationCode";
            this.txtDesignationCode.Size = new System.Drawing.Size(279, 20);
            this.txtDesignationCode.TabIndex = 40;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 20);
            this.txtName.TabIndex = 39;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Location = new System.Drawing.Point(57, 153);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(39, 13);
            this.labelControl7.TabIndex = 38;
            this.labelControl7.Text = "Tệp tin";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Location = new System.Drawing.Point(55, 180);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 13);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Ghi chú";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(22, 130);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(74, 13);
            this.labelControl5.TabIndex = 36;
            this.labelControl5.Text = "Ngày hết hạn";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(51, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 35;
            this.labelControl4.Text = "Ngày ký";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(47, 76);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 34;
            this.labelControl3.Text = "Người ký";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(19, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 13);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "Số quyết định";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(75, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 13);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Tên";
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpExpireDate.EditValue = null;
            this.dtpExpireDate.Location = new System.Drawing.Point(133, 125);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpExpireDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dtpExpireDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpExpireDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpExpireDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpExpireDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpExpireDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpExpireDate.Properties.Mask.BeepOnError = true;
            this.dtpExpireDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpExpireDate.Size = new System.Drawing.Size(161, 20);
            this.dtpExpireDate.TabIndex = 56;
            // 
            // dtpSignedDate
            // 
            this.dtpSignedDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpSignedDate.EditValue = null;
            this.dtpSignedDate.Location = new System.Drawing.Point(133, 96);
            this.dtpSignedDate.Name = "dtpSignedDate";
            this.dtpSignedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpSignedDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dtpSignedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpSignedDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpSignedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpSignedDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpSignedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpSignedDate.Properties.Mask.BeepOnError = true;
            this.dtpSignedDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpSignedDate.Size = new System.Drawing.Size(161, 20);
            this.dtpSignedDate.TabIndex = 56;
            // 
            // frmUpd_Designation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 372);
            this.Controls.Add(this.dtpSignedDate);
            this.Controls.Add(this.dtpExpireDate);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.cboDisable);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txaNote);
            this.Controls.Add(this.txtSignedBy);
            this.Controls.Add(this.txtFileData);
            this.Controls.Add(this.txtDesignationCode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUpd_Designation";
            this.Text = "Chỉnh sửa Quyết định";
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDisable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesignationCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpExpireDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpExpireDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSignedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSignedDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraEditors.ComboBoxEdit cboDisable;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private System.Windows.Forms.TextBox txaNote;
        private DevExpress.XtraEditors.TextEdit txtSignedBy;
        private DevExpress.XtraEditors.TextEdit txtFileData;
        private DevExpress.XtraEditors.TextEdit txtDesignationCode;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtpExpireDate;
        private DevExpress.XtraEditors.DateEdit dtpSignedDate;
    }
}
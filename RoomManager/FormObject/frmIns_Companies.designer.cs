namespace RoomManager
{
    partial class frmIns_Companies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIns_Companies));
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cboDisable = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueCustomerType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTaxNumberCode = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDisable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCustomerType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxNumberCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl16
            // 
            this.labelControl16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Location = new System.Drawing.Point(3, 170);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl16.Size = new System.Drawing.Size(81, 17);
            this.labelControl16.TabIndex = 10;
            this.labelControl16.Text = "Trạng thái";
            // 
            // cboStatus
            // 
            this.cboStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboStatus.EditValue = "1";
            this.cboStatus.Location = new System.Drawing.Point(101, 168);
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
            this.cboStatus.Size = new System.Drawing.Size(216, 20);
            this.cboStatus.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.Location = new System.Drawing.Point(101, 9);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 200;
            this.txtName.Properties.NullValuePrompt = "Nhập tối đa 200  ký tự.";
            this.txtName.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtName.Size = new System.Drawing.Size(216, 20);
            this.txtName.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.69697F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.30303F));
            this.tableLayoutPanel4.Controls.Add(this.labelControl13, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelControl8, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.cboDisable, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.labelControl16, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.cboStatus, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.labelControl1, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.lueCustomerType, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelControl3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.txtTaxNumberCode, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtAddress, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 21);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(330, 243);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Location = new System.Drawing.Point(3, 11);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl13.Size = new System.Drawing.Size(86, 16);
            this.labelControl13.TabIndex = 2;
            this.labelControl13.Text = "Tên công ty";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(3, 213);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelControl8.Size = new System.Drawing.Size(61, 16);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "Disable";
            // 
            // cboDisable
            // 
            this.cboDisable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboDisable.EditValue = "False";
            this.cboDisable.Location = new System.Drawing.Point(101, 211);
            this.cboDisable.Name = "cboDisable";
            this.cboDisable.Properties.Appearance.Options.UseTextOptions = true;
            this.cboDisable.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboDisable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDisable.Properties.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboDisable.Size = new System.Drawing.Size(216, 20);
            this.cboDisable.TabIndex = 13;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(3, 129);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(43, 17);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Loại";
            // 
            // lueCustomerType
            // 
            this.lueCustomerType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lueCustomerType.Location = new System.Drawing.Point(101, 127);
            this.lueCustomerType.Name = "lueCustomerType";
            this.lueCustomerType.Properties.Appearance.Options.UseTextOptions = true;
            this.lueCustomerType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lueCustomerType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCustomerType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Type")});
            this.lueCustomerType.Properties.NullText = "";
            this.lueCustomerType.Properties.NullValuePrompt = "Chọn loại";
            this.lueCustomerType.Properties.NullValuePromptShowForEmptyValue = true;
            this.lueCustomerType.Size = new System.Drawing.Size(216, 20);
            this.lueCustomerType.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(3, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl2.Size = new System.Drawing.Size(90, 17);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Mã số thuế ";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(3, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl3.Size = new System.Drawing.Size(55, 17);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Địa chỉ";
            // 
            // txtTaxNumberCode
            // 
            this.txtTaxNumberCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTaxNumberCode.Location = new System.Drawing.Point(101, 47);
            this.txtTaxNumberCode.Name = "txtTaxNumberCode";
            this.txtTaxNumberCode.Properties.MaxLength = 100;
            this.txtTaxNumberCode.Properties.NullValuePrompt = "Nhập tối đa 100  ký tự.";
            this.txtTaxNumberCode.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTaxNumberCode.Size = new System.Drawing.Size(216, 20);
            this.txtTaxNumberCode.TabIndex = 5;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAddress.Location = new System.Drawing.Point(101, 86);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.MaxLength = 250;
            this.txtAddress.Properties.NullValuePrompt = "Nhập tối đa 250  ký tự.";
            this.txtAddress.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtAddress.Size = new System.Drawing.Size(216, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 308);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.84848F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.15151F));
            this.tableLayoutPanel3.Controls.Add(this.btnAddNew, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 264);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(330, 44);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.Appearance.Options.UseFont = true;
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(117, 8);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(105, 28);
            this.btnAddNew.TabIndex = 15;
            this.btnAddNew.Text = "Cập nhật";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // frmIns_Companies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 308);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(600, 150);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIns_Companies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mới công ty";
            this.Load += new System.EventHandler(this.frmIns_Companies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDisable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCustomerType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxNumberCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cboDisable;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueCustomerType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtTaxNumberCode;
        private DevExpress.XtraEditors.TextEdit txtAddress;
    }
}
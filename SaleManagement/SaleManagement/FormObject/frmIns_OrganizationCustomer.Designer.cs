namespace SaleManagement
{
    partial class frmIns_OrganizationCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIns_OrganizationCustomer));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.teBirthDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.teFullName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.teIDCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.teEmail1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.teMobile = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.teAdress = new DevExpress.XtraEditors.TextEdit();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbCreate = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teBirthDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBirthDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teIDCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmail1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAdress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 257F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl17, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.teBirthDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.teFullName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl16, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.teIDCode, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl19, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.teEmail1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl18, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.teMobile, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.teAdress, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(719, 147);
            this.tableLayoutPanel1.TabIndex = 120;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(3, 73);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl17.Size = new System.Drawing.Size(52, 13);
            this.labelControl17.TabIndex = 103;
            this.labelControl17.Text = "Ngày sinh";
            // 
            // teBirthDate
            // 
            this.teBirthDate.EditValue = null;
            this.teBirthDate.Location = new System.Drawing.Point(132, 73);
            this.teBirthDate.Name = "teBirthDate";
            this.teBirthDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teBirthDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.teBirthDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teBirthDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.teBirthDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teBirthDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.teBirthDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.teBirthDate.Size = new System.Drawing.Size(193, 20);
            this.teBirthDate.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(3, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 92;
            this.labelControl2.Text = "Tên đầy đủ";
            // 
            // teFullName
            // 
            this.teFullName.Location = new System.Drawing.Point(132, 38);
            this.teFullName.Name = "teFullName";
            this.teFullName.Size = new System.Drawing.Size(193, 20);
            this.teFullName.TabIndex = 97;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(389, 38);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(89, 13);
            this.labelControl16.TabIndex = 104;
            this.labelControl16.Text = "Số CMND/Hộ chiếu";
            // 
            // teIDCode
            // 
            this.teIDCode.Location = new System.Drawing.Point(509, 38);
            this.teIDCode.Name = "teIDCode";
            this.teIDCode.Size = new System.Drawing.Size(193, 20);
            this.teIDCode.TabIndex = 110;
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl19.Location = new System.Drawing.Point(389, 73);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl19.Size = new System.Drawing.Size(67, 13);
            this.labelControl19.TabIndex = 101;
            this.labelControl19.Text = "Địa chỉ Email ";
            // 
            // teEmail1
            // 
            this.teEmail1.Location = new System.Drawing.Point(509, 73);
            this.teEmail1.Name = "teEmail1";
            this.teEmail1.Size = new System.Drawing.Size(193, 20);
            this.teEmail1.TabIndex = 3;
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(3, 108);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl18.Size = new System.Drawing.Size(105, 13);
            this.labelControl18.TabIndex = 102;
            this.labelControl18.Text = "Số điện thoại di động";
            // 
            // teMobile
            // 
            this.teMobile.Location = new System.Drawing.Point(132, 108);
            this.teMobile.Name = "teMobile";
            this.teMobile.Properties.Mask.EditMask = "\\d+";
            this.teMobile.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teMobile.Size = new System.Drawing.Size(193, 20);
            this.teMobile.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(389, 108);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(80, 13);
            this.labelControl5.TabIndex = 95;
            this.labelControl5.Text = "Địa chỉ nhà riêng";
            // 
            // teAdress
            // 
            this.teAdress.Location = new System.Drawing.Point(509, 108);
            this.teAdress.Name = "teAdress";
            this.teAdress.Size = new System.Drawing.Size(193, 20);
            this.teAdress.TabIndex = 5;
            // 
            // sbCancel
            // 
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancel.Image = ((System.Drawing.Image)(resources.GetObject("sbCancel.Image")));
            this.sbCancel.Location = new System.Drawing.Point(374, 167);
            this.sbCancel.Margin = new System.Windows.Forms.Padding(0);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.sbCancel.Size = new System.Drawing.Size(75, 23);
            this.sbCancel.TabIndex = 123;
            this.sbCancel.Text = "Hủy";
            // 
            // sbCreate
            // 
            this.sbCreate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCreate.Appearance.Options.UseFont = true;
            this.sbCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbCreate.Image = ((System.Drawing.Image)(resources.GetObject("sbCreate.Image")));
            this.sbCreate.Location = new System.Drawing.Point(250, 167);
            this.sbCreate.Margin = new System.Windows.Forms.Padding(0);
            this.sbCreate.Name = "sbCreate";
            this.sbCreate.Size = new System.Drawing.Size(75, 23);
            this.sbCreate.TabIndex = 122;
            this.sbCreate.Text = "Tạo mới";
            this.sbCreate.Click += new System.EventHandler(this.sbCreate_Click);
            // 
            // CreateOrganizationCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 215);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbCreate);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateOrganizationCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo mới khách hàng";
            this.Load += new System.EventHandler(this.CreateOrganizationCustomer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teBirthDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBirthDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teIDCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmail1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAdress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.DateEdit teBirthDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit teFullName;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.TextEdit teIDCode;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.TextEdit teEmail1;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit teMobile;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit teAdress;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbCreate;
    }
}
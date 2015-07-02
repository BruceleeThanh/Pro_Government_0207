namespace SaleManagement
{
    partial class frmIns_Customers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIns_Customers));
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.btnCreateNew = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.cboDisable = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lueStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.cbbCustomerType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpBirthday = new DevExpress.XtraEditors.DateEdit();
            this.txtIdentifier1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtNames = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtInfo = new DevExpress.XtraEditors.MemoEdit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDisable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbCustomerType.Properties)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBirthday.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBirthday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdentifier1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNames.Properties)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl17
            // 
            this.labelControl17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Location = new System.Drawing.Point(125, 14);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(23, 13);
            this.labelControl17.TabIndex = 8;
            this.labelControl17.Text = "Loại";
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCreateNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCreateNew.Appearance.Options.UseFont = true;
            this.btnCreateNew.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateNew.Image")));
            this.btnCreateNew.Location = new System.Drawing.Point(443, 3);
            this.btnCreateNew.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(88, 28);
            this.btnCreateNew.TabIndex = 0;
            this.btnCreateNew.Text = "Thêm mới";
            this.btnCreateNew.Click += new System.EventHandler(this.btCreateNew_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(534, 335);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.89449F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.10552F));
            this.tableLayoutPanel4.Controls.Add(this.btnCreateNew, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 300);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(534, 35);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.20773F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(528, 278);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.08496F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.4053F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.50974F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel9, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelControl1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl15, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelControl3, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtNames, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl4, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel8, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelControl10, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelControl9, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtAddress, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtInfo, 2, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.843F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.85161F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.85161F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.843F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.61078F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(522, 272);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 5;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Controls.Add(this.cboDisable, 4, 0);
            this.tableLayoutPanel9.Controls.Add(this.lueStatus, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.labelControl17, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.cbbCustomerType, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.labelControl2, 3, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(116, 231);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(406, 41);
            this.tableLayoutPanel9.TabIndex = 26;
            // 
            // cboDisable
            // 
            this.cboDisable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboDisable.EditValue = "False";
            this.cboDisable.Location = new System.Drawing.Point(309, 10);
            this.cboDisable.Name = "cboDisable";
            this.cboDisable.Properties.Appearance.Options.UseTextOptions = true;
            this.cboDisable.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboDisable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDisable.Properties.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboDisable.Size = new System.Drawing.Size(83, 20);
            this.cboDisable.TabIndex = 10;
            // 
            // lueStatus
            // 
            this.lueStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lueStatus.Location = new System.Drawing.Point(3, 10);
            this.lueStatus.Name = "lueStatus";
            this.lueStatus.Properties.Appearance.Options.UseTextOptions = true;
            this.lueStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lueStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Trạng thái")});
            this.lueStatus.Properties.NullText = "";
            this.lueStatus.Size = new System.Drawing.Size(109, 20);
            this.lueStatus.TabIndex = 24;
            // 
            // cbbCustomerType
            // 
            this.cbbCustomerType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbCustomerType.EditValue = "1";
            this.cbbCustomerType.Location = new System.Drawing.Point(162, 10);
            this.cbbCustomerType.Name = "cbbCustomerType";
            this.cbbCustomerType.Properties.Appearance.Options.UseTextOptions = true;
            this.cbbCustomerType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbbCustomerType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbCustomerType.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbbCustomerType.Size = new System.Drawing.Size(75, 20);
            this.cbbCustomerType.TabIndex = 25;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(250, 14);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "Disable";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.dtpBirthday, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.txtIdentifier1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.labelControl5, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(116, 41);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(406, 41);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpBirthday.EditValue = null;
            this.dtpBirthday.Location = new System.Drawing.Point(254, 10);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpBirthday.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpBirthday.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpBirthday.Size = new System.Drawing.Size(138, 20);
            this.dtpBirthday.TabIndex = 26;
            // 
            // txtIdentifier1
            // 
            this.txtIdentifier1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIdentifier1.Location = new System.Drawing.Point(3, 10);
            this.txtIdentifier1.Name = "txtIdentifier1";
            this.txtIdentifier1.Properties.MaxLength = 50;
            this.txtIdentifier1.Properties.NullValuePrompt = "Tối đa 50 ký tự.";
            this.txtIdentifier1.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtIdentifier1.Size = new System.Drawing.Size(174, 20);
            this.txtIdentifier1.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(190, 14);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 13);
            this.labelControl5.TabIndex = 27;
            this.labelControl5.Text = "Ngày sinh";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(15, 14);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên";
            // 
            // labelControl15
            // 
            this.labelControl15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Location = new System.Drawing.Point(15, 55);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(32, 13);
            this.labelControl15.TabIndex = 1;
            this.labelControl15.Text = "CMND";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(8, 245);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "Trạng thái";
            // 
            // txtNames
            // 
            this.txtNames.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNames.Location = new System.Drawing.Point(119, 10);
            this.txtNames.Name = "txtNames";
            this.txtNames.Properties.MaxLength = 50;
            this.txtNames.Properties.NullValuePrompt = "Nhập tối đa 50 ký tự.";
            this.txtNames.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtNames.Size = new System.Drawing.Size(390, 20);
            this.txtNames.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(8, 191);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl4.Size = new System.Drawing.Size(63, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Thông tin";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.txtTel, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.labelControl8, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.txtEmail, 2, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(116, 123);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(406, 41);
            this.tableLayoutPanel8.TabIndex = 25;
            // 
            // txtTel
            // 
            this.txtTel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTel.Location = new System.Drawing.Point(3, 10);
            this.txtTel.Name = "txtTel";
            this.txtTel.Properties.Mask.EditMask = "\\d\\d\\d\\d-\\d\\d\\d-\\d\\d\\d";
            this.txtTel.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtTel.Properties.MaxLength = 20;
            this.txtTel.Properties.NullValuePrompt = "Chỉ được nhập số.";
            this.txtTel.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTel.Size = new System.Drawing.Size(174, 20);
            this.txtTel.TabIndex = 4;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(190, 14);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(30, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEmail.Location = new System.Drawing.Point(234, 10);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Mask.EditMask = "\\w*@\\w*\\.\\w*";
            this.txtEmail.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtEmail.Properties.MaxLength = 50;
            this.txtEmail.Properties.NullValuePrompt = "NhakhachChinhphu@gmail.com";
            this.txtEmail.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtEmail.Size = new System.Drawing.Size(158, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Location = new System.Drawing.Point(15, 137);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(73, 13);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Số điện thoại";
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Location = new System.Drawing.Point(15, 96);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(38, 13);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Địa chỉ";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAddress.Location = new System.Drawing.Point(119, 92);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.MaxLength = 200;
            this.txtAddress.Properties.NullValuePrompt = "Nhập tối đa 200 ký tự.";
            this.txtAddress.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtAddress.Size = new System.Drawing.Size(390, 20);
            this.txtAddress.TabIndex = 4;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(119, 167);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(389, 61);
            this.txtInfo.TabIndex = 29;
            this.txtInfo.UseOptimizedRendering = true;
            // 
            // frmIns_Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(534, 335);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIns_Customers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mới khách hàng";
            this.Load += new System.EventHandler(this.frmAddNewCustomers_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDisable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbCustomerType.Properties)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBirthday.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBirthday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdentifier1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNames.Properties)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCreateNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.ComboBoxEdit cboDisable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private DevExpress.XtraEditors.TextEdit txtIdentifier1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit txtNames;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private DevExpress.XtraEditors.TextEdit txtTel;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueStatus;
        private DevExpress.XtraEditors.DateEdit dtpBirthday;
        private DevExpress.XtraEditors.ComboBoxEdit cbbCustomerType;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.MemoEdit txtInfo;
    }
}
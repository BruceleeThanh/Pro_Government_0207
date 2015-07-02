namespace RoomManager
{
    partial class frmTsk_CheckIn_Group_Step2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTsk_CheckIn_Group_Step2));
            this.lueIDCustomers = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAddCustomers = new DevExpress.XtraEditors.SimpleButton();
            this.lueIDCompanies = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAddCompanies = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearchCompanies = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lueIDCustomerGroups = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAddCustomerGroups = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearchCustomerGroups = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearchCustomers = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtBookingMoney = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.txtSubject = new DevExpress.XtraEditors.TextEdit();
            this.txaDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txaNote = new DevExpress.XtraEditors.MemoEdit();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.lueIDCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueIDCompanies.Properties)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueIDCustomerGroups.Properties)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookingMoney.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txaDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txaNote.Properties)).BeginInit();
            this.tableLayoutPanel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // lueIDCustomers
            // 
            this.lueIDCustomers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lueIDCustomers.Location = new System.Drawing.Point(3, 6);
            this.lueIDCustomers.Name = "lueIDCustomers";
            this.lueIDCustomers.Properties.Appearance.Options.UseTextOptions = true;
            this.lueIDCustomers.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lueIDCustomers.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lueIDCustomers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueIDCustomers.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 18, "Tên")});
            this.lueIDCustomers.Properties.NullText = "--- Chọn lựa ---";
            this.lueIDCustomers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueIDCustomers.Size = new System.Drawing.Size(180, 20);
            this.lueIDCustomers.TabIndex = 25;
            // 
            // btnAddCustomers
            // 
            this.btnAddCustomers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddCustomers.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomers.Appearance.Options.UseFont = true;
            this.btnAddCustomers.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCustomers.Image")));
            this.btnAddCustomers.Location = new System.Drawing.Point(192, 6);
            this.btnAddCustomers.Name = "btnAddCustomers";
            this.btnAddCustomers.Size = new System.Drawing.Size(70, 20);
            this.btnAddCustomers.TabIndex = 26;
            this.btnAddCustomers.Text = "Thêm";
            this.btnAddCustomers.Click += new System.EventHandler(this.btnAddCustomers_Click);
            // 
            // lueIDCompanies
            // 
            this.lueIDCompanies.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lueIDCompanies.Location = new System.Drawing.Point(3, 6);
            this.lueIDCompanies.Name = "lueIDCompanies";
            this.lueIDCompanies.Properties.Appearance.Options.UseTextOptions = true;
            this.lueIDCompanies.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lueIDCompanies.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lueIDCompanies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueIDCompanies.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 18, "Tên")});
            this.lueIDCompanies.Properties.NullText = "--- Chọn lựa ---";
            this.lueIDCompanies.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueIDCompanies.Size = new System.Drawing.Size(180, 20);
            this.lueIDCompanies.TabIndex = 15;
            this.lueIDCompanies.EditValueChanged += new System.EventHandler(this.lueIDCompanies_EditValueChanged);
            // 
            // btnAddCompanies
            // 
            this.btnAddCompanies.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddCompanies.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCompanies.Appearance.Options.UseFont = true;
            this.btnAddCompanies.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCompanies.Image")));
            this.btnAddCompanies.Location = new System.Drawing.Point(195, 6);
            this.btnAddCompanies.Name = "btnAddCompanies";
            this.btnAddCompanies.Size = new System.Drawing.Size(69, 20);
            this.btnAddCompanies.TabIndex = 16;
            this.btnAddCompanies.Text = "Thêm";
            this.btnAddCompanies.Click += new System.EventHandler(this.btnAddCompanies_Click);
            // 
            // btnSearchCompanies
            // 
            this.btnSearchCompanies.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearchCompanies.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCompanies.Appearance.Options.UseFont = true;
            this.btnSearchCompanies.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCompanies.Image")));
            this.btnSearchCompanies.Location = new System.Drawing.Point(270, 6);
            this.btnSearchCompanies.Name = "btnSearchCompanies";
            this.btnSearchCompanies.Size = new System.Drawing.Size(85, 20);
            this.btnSearchCompanies.TabIndex = 17;
            this.btnSearchCompanies.Text = "Tìm kiếm";
            this.btnSearchCompanies.Click += new System.EventHandler(this.btnSearchCompanies_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.80117F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.4386F));
            this.tableLayoutPanel8.Controls.Add(this.lueIDCompanies, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnAddCompanies, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnSearchCompanies, 2, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(121, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(358, 33);
            this.tableLayoutPanel8.TabIndex = 14;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.50877F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.73099F));
            this.tableLayoutPanel6.Controls.Add(this.lueIDCustomerGroups, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnAddCustomerGroups, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnSearchCustomerGroups, 2, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(121, 42);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(358, 33);
            this.tableLayoutPanel6.TabIndex = 19;
            // 
            // lueIDCustomerGroups
            // 
            this.lueIDCustomerGroups.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.lueIDCustomerGroups.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lueIDCustomerGroups.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lueIDCustomerGroups.Location = new System.Drawing.Point(3, 6);
            this.lueIDCustomerGroups.Name = "lueIDCustomerGroups";
            this.lueIDCustomerGroups.Properties.Appearance.Options.UseTextOptions = true;
            this.lueIDCustomerGroups.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lueIDCustomerGroups.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lueIDCustomerGroups.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueIDCustomerGroups.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 18, "Tên")});
            this.lueIDCustomerGroups.Properties.NullText = "--- Chọn lựa ---";
            this.lueIDCustomerGroups.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueIDCustomerGroups.Size = new System.Drawing.Size(180, 20);
            this.lueIDCustomerGroups.TabIndex = 20;
            this.lueIDCustomerGroups.EditValueChanged += new System.EventHandler(this.lueIDCustomerGroups_EditValueChanged);
            // 
            // btnAddCustomerGroups
            // 
            this.btnAddCustomerGroups.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddCustomerGroups.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomerGroups.Appearance.Options.UseFont = true;
            this.btnAddCustomerGroups.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCustomerGroups.Image")));
            this.btnAddCustomerGroups.Location = new System.Drawing.Point(194, 6);
            this.btnAddCustomerGroups.Name = "btnAddCustomerGroups";
            this.btnAddCustomerGroups.Size = new System.Drawing.Size(69, 20);
            this.btnAddCustomerGroups.TabIndex = 21;
            this.btnAddCustomerGroups.Text = "Thêm";
            this.btnAddCustomerGroups.Click += new System.EventHandler(this.btnAddCustomerGroups_Click);
            // 
            // btnSearchCustomerGroups
            // 
            this.btnSearchCustomerGroups.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearchCustomerGroups.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCustomerGroups.Appearance.Options.UseFont = true;
            this.btnSearchCustomerGroups.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCustomerGroups.Image")));
            this.btnSearchCustomerGroups.Location = new System.Drawing.Point(269, 6);
            this.btnSearchCustomerGroups.Name = "btnSearchCustomerGroups";
            this.btnSearchCustomerGroups.Size = new System.Drawing.Size(86, 20);
            this.btnSearchCustomerGroups.TabIndex = 22;
            this.btnSearchCustomerGroups.Text = "Tìm kiếm";
            this.btnSearchCustomerGroups.Click += new System.EventHandler(this.btnSearchCustomerGroups_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.21637F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.34503F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.73099F));
            this.tableLayoutPanel7.Controls.Add(this.lueIDCustomers, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnAddCustomers, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnSearchCustomers, 2, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(121, 81);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(358, 33);
            this.tableLayoutPanel7.TabIndex = 24;
            // 
            // btnSearchCustomers
            // 
            this.btnSearchCustomers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearchCustomers.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCustomers.Appearance.Options.UseFont = true;
            this.btnSearchCustomers.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCustomers.Image")));
            this.btnSearchCustomers.Location = new System.Drawing.Point(268, 6);
            this.btnSearchCustomers.Name = "btnSearchCustomers";
            this.btnSearchCustomers.Size = new System.Drawing.Size(87, 20);
            this.btnSearchCustomers.TabIndex = 27;
            this.btnSearchCustomers.Text = "Tìm kiếm";
            this.btnSearchCustomers.Click += new System.EventHandler(this.btnSearchCustomers_Click);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.48133F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.51867F));
            this.tableLayoutPanel11.Controls.Add(this.labelControl1, 0, 3);
            this.tableLayoutPanel11.Controls.Add(this.labelControl8, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.labelControl9, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.labelControl10, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel6, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel7, 1, 2);
            this.tableLayoutPanel11.Controls.Add(this.txtBookingMoney, 1, 3);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 4;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(482, 157);
            this.tableLayoutPanel11.TabIndex = 12;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(3, 128);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(77, 17);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "Đặt trước";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(3, 89);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl8.Size = new System.Drawing.Size(109, 17);
            this.labelControl8.TabIndex = 23;
            this.labelControl8.Text = "Người đại diện";
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Location = new System.Drawing.Point(3, 50);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl9.Size = new System.Drawing.Size(45, 16);
            this.labelControl9.TabIndex = 18;
            this.labelControl9.Text = "Nhóm";
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Location = new System.Drawing.Point(3, 11);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl10.Size = new System.Drawing.Size(60, 16);
            this.labelControl10.TabIndex = 13;
            this.labelControl10.Text = "Công ty";
            // 
            // txtBookingMoney
            // 
            this.txtBookingMoney.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBookingMoney.Location = new System.Drawing.Point(124, 127);
            this.txtBookingMoney.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.txtBookingMoney.Name = "txtBookingMoney";
            this.txtBookingMoney.Properties.DisplayFormat.FormatString = "{0:0,0}";
            this.txtBookingMoney.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtBookingMoney.Properties.EditFormat.FormatString = "{0:0,0}";
            this.txtBookingMoney.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtBookingMoney.Properties.Mask.EditMask = "n0";
            this.txtBookingMoney.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBookingMoney.Properties.MaxLength = 10;
            this.txtBookingMoney.Properties.NullValuePrompt = "Chỉ nhập số.";
            this.txtBookingMoney.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtBookingMoney.Size = new System.Drawing.Size(180, 20);
            this.txtBookingMoney.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel11);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 180);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   Thông tin khách đặt  ";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnNext.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(722, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 30);
            this.btnNext.TabIndex = 32;
            this.btnNext.Text = "Tiếp theo";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 1;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.tableLayoutPanel20, 0, 2);
            this.tableLayoutPanel14.Controls.Add(this.tableLayoutPanel16, 0, 1);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 3;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(853, 442);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.ColumnCount = 2;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel20.Controls.Add(this.btnNext, 1, 0);
            this.tableLayoutPanel20.Controls.Add(this.btnBack, 0, 0);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(3, 400);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 1;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(847, 39);
            this.tableLayoutPanel20.TabIndex = 30;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBack.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(616, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 31;
            this.btnBack.Text = "Quay lại";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.67651F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.32349F));
            this.tableLayoutPanel16.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.tableLayoutPanel18, 1, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(847, 365);
            this.tableLayoutPanel16.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel17);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 359);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "   Thông tin chung  ";
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.72727F));
            this.tableLayoutPanel17.Controls.Add(this.labelControl13, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.labelControl14, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.labelControl17, 0, 2);
            this.tableLayoutPanel17.Controls.Add(this.txtSubject, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.txaDescription, 1, 1);
            this.tableLayoutPanel17.Controls.Add(this.txaNote, 1, 2);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 3;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(341, 336);
            this.tableLayoutPanel17.TabIndex = 3;
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Location = new System.Drawing.Point(3, 11);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl13.Size = new System.Drawing.Size(60, 17);
            this.labelControl13.TabIndex = 4;
            this.labelControl13.Text = "Tiêu đề";
            // 
            // labelControl14
            // 
            this.labelControl14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Location = new System.Drawing.Point(3, 105);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl14.Size = new System.Drawing.Size(49, 17);
            this.labelControl14.TabIndex = 6;
            this.labelControl14.Text = "Mô tả";
            // 
            // labelControl17
            // 
            this.labelControl17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Location = new System.Drawing.Point(3, 253);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl17.Size = new System.Drawing.Size(56, 16);
            this.labelControl17.TabIndex = 8;
            this.labelControl17.Text = "Ghi chú";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSubject.Location = new System.Drawing.Point(96, 10);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Properties.MaxLength = 150;
            this.txtSubject.Properties.NullValuePrompt = "Nhập tối đa 150 ký  tự.";
            this.txtSubject.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSubject.Size = new System.Drawing.Size(242, 20);
            this.txtSubject.TabIndex = 5;
            // 
            // txaDescription
            // 
            this.txaDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txaDescription.Location = new System.Drawing.Point(96, 53);
            this.txaDescription.Name = "txaDescription";
            this.txaDescription.Properties.MaxLength = 250;
            this.txaDescription.Properties.NullValuePrompt = "Tối đa 250 ký tự.";
            this.txaDescription.Properties.NullValuePromptShowForEmptyValue = true;
            this.txaDescription.Size = new System.Drawing.Size(242, 120);
            this.txaDescription.TabIndex = 7;
            this.txaDescription.UseOptimizedRendering = true;
            // 
            // txaNote
            // 
            this.txaNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txaNote.Location = new System.Drawing.Point(96, 201);
            this.txaNote.Name = "txaNote";
            this.txaNote.Properties.MaxLength = 250;
            this.txaNote.Properties.NullValuePrompt = "Tối đa 250 ký tự.";
            this.txaNote.Properties.NullValuePromptShowForEmptyValue = true;
            this.txaNote.Size = new System.Drawing.Size(242, 120);
            this.txaNote.TabIndex = 9;
            this.txaNote.UseOptimizedRendering = true;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 1;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(353, 0);
            this.tableLayoutPanel18.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 2;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(494, 365);
            this.tableLayoutPanel18.TabIndex = 10;
            // 
            // frmTsk_CheckIn_Group_Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 442);
            this.Controls.Add(this.tableLayoutPanel14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTsk_CheckIn_Group_Step2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin đặt phòng";
            this.Load += new System.EventHandler(this.frmTsk_CheckIn_Group_Step2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueIDCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueIDCompanies.Properties)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueIDCustomerGroups.Properties)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookingMoney.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txaDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txaNote.Properties)).EndInit();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueIDCustomers;
        private DevExpress.XtraEditors.SimpleButton btnAddCustomers;
        private DevExpress.XtraEditors.LookUpEdit lueIDCompanies;
        private DevExpress.XtraEditors.SimpleButton btnAddCompanies;
        private DevExpress.XtraEditors.SimpleButton btnSearchCompanies;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private DevExpress.XtraEditors.LookUpEdit lueIDCustomerGroups;
        private DevExpress.XtraEditors.SimpleButton btnAddCustomerGroups;
        private DevExpress.XtraEditors.SimpleButton btnSearchCustomerGroups;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.TextEdit txtSubject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.SimpleButton btnSearchCustomers;
        private DevExpress.XtraEditors.TextEdit txtBookingMoney;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txaDescription;
        private DevExpress.XtraEditors.MemoEdit txaNote;

    }
}
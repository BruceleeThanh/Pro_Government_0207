namespace HumanResource
{
    partial class frmLst_SystemUsers_Divisions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLst_SystemUsers_Divisions));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bt_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpChooseDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboDivisions = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDisable = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colSystemUsers_Birthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystemUsers_Identifier1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystemUsers_Username = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDivisions_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.viewSystemUsers_Divisions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSystemUsers_Divisions_AvaiableDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystemUsers_Divisions_ExpireDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvSystemUsers_Divisions = new DevExpress.XtraGrid.GridControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bt_Edit_BookingRooms_Services = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colSystemUsers_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Delete)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpChooseDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpChooseDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDivisions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSystemUsers_Divisions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemUsers_Divisions)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Edit_BookingRooms_Services)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn8.Caption = "Địa chỉ";
            this.gridColumn8.FieldName = "Address";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            // 
            // bt_Delete
            // 
            this.bt_Delete.AutoHeight = false;
            this.bt_Delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("bt_Delete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Tên khách hàng";
            this.gridColumn1.FieldName = "Names";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "Số CMND";
            this.gridColumn2.FieldName = "Identifier1";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.Caption = "Hộ chiếu";
            this.gridColumn3.FieldName = "Identifier2";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.Caption = "aa";
            this.gridColumn4.FieldName = "Identifier3";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn5.Caption = "Quốc tịch";
            this.gridColumn5.FieldName = "Nationality";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn6.Caption = "Ngày sinh";
            this.gridColumn6.FieldName = "Birthday";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn7.Caption = "Số điện thoại";
            this.gridColumn7.FieldName = "Tel";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Appearance.Options.UseFont = true;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(711, 11);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(90, 23);
            this.btnAddNew.TabIndex = 18;
            this.btnAddNew.Text = "Thêm mới";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.btnAddNew, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(834, 46);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.btnSearch, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtpChooseDate, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelControl2, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.cboDivisions, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(44, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(661, 40);
            this.tableLayoutPanel4.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(381, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 23);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(3, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Tên phòng";
            // 
            // dtpChooseDate
            // 
            this.dtpChooseDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpChooseDate.EditValue = null;
            this.dtpChooseDate.Location = new System.Drawing.Point(232, 10);
            this.dtpChooseDate.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.dtpChooseDate.Name = "dtpChooseDate";
            this.dtpChooseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpChooseDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpChooseDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpChooseDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpChooseDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpChooseDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpChooseDate.Properties.Mask.EditMask = "MM/dd/yyyy";
            this.dtpChooseDate.Size = new System.Drawing.Size(143, 20);
            this.dtpChooseDate.TabIndex = 15;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(192, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Ngày";
            // 
            // cboDivisions
            // 
            this.cboDivisions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboDivisions.Location = new System.Drawing.Point(68, 10);
            this.cboDivisions.Name = "cboDivisions";
            this.cboDivisions.Properties.Appearance.Options.UseTextOptions = true;
            this.cboDivisions.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboDivisions.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDivisions.Properties.NullText = "Tất cả";
            this.cboDivisions.Size = new System.Drawing.Size(118, 20);
            this.cboDivisions.TabIndex = 22;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnDelete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn10.Caption = "Email";
            this.gridColumn10.FieldName = "Email";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn21.AppearanceHeader.Options.UseFont = true;
            this.gridColumn21.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.Caption = "Edit";
            this.gridColumn21.ColumnEdit = this.btnDisable;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 0;
            this.gridColumn21.Width = 52;
            // 
            // btnDisable
            // 
            this.btnDisable.AutoHeight = false;
            this.btnDisable.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnDisable.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // colSystemUsers_Birthday
            // 
            this.colSystemUsers_Birthday.AppearanceCell.Options.UseTextOptions = true;
            this.colSystemUsers_Birthday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Birthday.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSystemUsers_Birthday.AppearanceHeader.Options.UseFont = true;
            this.colSystemUsers_Birthday.AppearanceHeader.Options.UseTextOptions = true;
            this.colSystemUsers_Birthday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Birthday.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSystemUsers_Birthday.Caption = "Ngày sinh";
            this.colSystemUsers_Birthday.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colSystemUsers_Birthday.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSystemUsers_Birthday.FieldName = "SystemUsers_Birthday";
            this.colSystemUsers_Birthday.Name = "colSystemUsers_Birthday";
            this.colSystemUsers_Birthday.OptionsColumn.AllowEdit = false;
            this.colSystemUsers_Birthday.OptionsColumn.AllowFocus = false;
            this.colSystemUsers_Birthday.OptionsColumn.ReadOnly = true;
            this.colSystemUsers_Birthday.Visible = true;
            this.colSystemUsers_Birthday.VisibleIndex = 4;
            this.colSystemUsers_Birthday.Width = 106;
            // 
            // colSystemUsers_Identifier1
            // 
            this.colSystemUsers_Identifier1.AppearanceCell.Options.UseTextOptions = true;
            this.colSystemUsers_Identifier1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Identifier1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSystemUsers_Identifier1.AppearanceHeader.Options.UseFont = true;
            this.colSystemUsers_Identifier1.AppearanceHeader.Options.UseTextOptions = true;
            this.colSystemUsers_Identifier1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Identifier1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSystemUsers_Identifier1.Caption = "CMND";
            this.colSystemUsers_Identifier1.FieldName = "SystemUsers_Identifier1";
            this.colSystemUsers_Identifier1.Name = "colSystemUsers_Identifier1";
            this.colSystemUsers_Identifier1.OptionsColumn.AllowEdit = false;
            this.colSystemUsers_Identifier1.OptionsColumn.AllowFocus = false;
            this.colSystemUsers_Identifier1.OptionsColumn.ReadOnly = true;
            this.colSystemUsers_Identifier1.Visible = true;
            this.colSystemUsers_Identifier1.VisibleIndex = 3;
            this.colSystemUsers_Identifier1.Width = 101;
            // 
            // colSystemUsers_Username
            // 
            this.colSystemUsers_Username.AppearanceCell.Options.UseTextOptions = true;
            this.colSystemUsers_Username.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Username.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSystemUsers_Username.AppearanceHeader.Options.UseFont = true;
            this.colSystemUsers_Username.AppearanceHeader.Options.UseTextOptions = true;
            this.colSystemUsers_Username.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Username.Caption = "Tên";
            this.colSystemUsers_Username.FieldName = "SystemUsers_Name";
            this.colSystemUsers_Username.Name = "colSystemUsers_Username";
            this.colSystemUsers_Username.OptionsColumn.AllowEdit = false;
            this.colSystemUsers_Username.OptionsColumn.AllowFocus = false;
            this.colSystemUsers_Username.Visible = true;
            this.colSystemUsers_Username.VisibleIndex = 2;
            this.colSystemUsers_Username.Width = 131;
            // 
            // colDivisions_Name
            // 
            this.colDivisions_Name.AppearanceCell.Options.UseTextOptions = true;
            this.colDivisions_Name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDivisions_Name.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDivisions_Name.AppearanceHeader.Options.UseFont = true;
            this.colDivisions_Name.AppearanceHeader.Options.UseTextOptions = true;
            this.colDivisions_Name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDivisions_Name.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDivisions_Name.Caption = "Tên phòng";
            this.colDivisions_Name.FieldName = "Divisions_Name";
            this.colDivisions_Name.Name = "colDivisions_Name";
            this.colDivisions_Name.OptionsColumn.AllowEdit = false;
            this.colDivisions_Name.OptionsColumn.AllowFocus = false;
            this.colDivisions_Name.OptionsColumn.ReadOnly = true;
            this.colDivisions_Name.Visible = true;
            this.colDivisions_Name.VisibleIndex = 1;
            this.colDivisions_Name.Width = 147;
            // 
            // viewSystemUsers_Divisions
            // 
            this.viewSystemUsers_Divisions.ColumnPanelRowHeight = 40;
            this.viewSystemUsers_Divisions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn21,
            this.colDivisions_Name,
            this.colSystemUsers_Username,
            this.colSystemUsers_Identifier1,
            this.colSystemUsers_Birthday,
            this.colSystemUsers_Divisions_AvaiableDate,
            this.colSystemUsers_Divisions_ExpireDate,
            this.gridColumn9});
            this.viewSystemUsers_Divisions.GridControl = this.dgvSystemUsers_Divisions;
            this.viewSystemUsers_Divisions.Name = "viewSystemUsers_Divisions";
            this.viewSystemUsers_Divisions.OptionsView.EnableAppearanceEvenRow = true;
            this.viewSystemUsers_Divisions.OptionsView.ShowFooter = true;
            this.viewSystemUsers_Divisions.OptionsView.ShowGroupPanel = false;
            this.viewSystemUsers_Divisions.OptionsView.ShowIndicator = false;
            this.viewSystemUsers_Divisions.RowHeight = 25;
            // 
            // colSystemUsers_Divisions_AvaiableDate
            // 
            this.colSystemUsers_Divisions_AvaiableDate.AppearanceCell.Options.UseTextOptions = true;
            this.colSystemUsers_Divisions_AvaiableDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Divisions_AvaiableDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSystemUsers_Divisions_AvaiableDate.AppearanceHeader.Options.UseFont = true;
            this.colSystemUsers_Divisions_AvaiableDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colSystemUsers_Divisions_AvaiableDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Divisions_AvaiableDate.Caption = "Ngày đến";
            this.colSystemUsers_Divisions_AvaiableDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colSystemUsers_Divisions_AvaiableDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSystemUsers_Divisions_AvaiableDate.FieldName = "SystemUsers_Divisions_AvaiableDate";
            this.colSystemUsers_Divisions_AvaiableDate.Name = "colSystemUsers_Divisions_AvaiableDate";
            this.colSystemUsers_Divisions_AvaiableDate.OptionsColumn.AllowEdit = false;
            this.colSystemUsers_Divisions_AvaiableDate.OptionsColumn.AllowFocus = false;
            this.colSystemUsers_Divisions_AvaiableDate.Visible = true;
            this.colSystemUsers_Divisions_AvaiableDate.VisibleIndex = 5;
            this.colSystemUsers_Divisions_AvaiableDate.Width = 109;
            // 
            // colSystemUsers_Divisions_ExpireDate
            // 
            this.colSystemUsers_Divisions_ExpireDate.AppearanceCell.Options.UseTextOptions = true;
            this.colSystemUsers_Divisions_ExpireDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Divisions_ExpireDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSystemUsers_Divisions_ExpireDate.AppearanceHeader.Options.UseFont = true;
            this.colSystemUsers_Divisions_ExpireDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colSystemUsers_Divisions_ExpireDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Divisions_ExpireDate.Caption = "Ngày đi";
            this.colSystemUsers_Divisions_ExpireDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colSystemUsers_Divisions_ExpireDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSystemUsers_Divisions_ExpireDate.FieldName = "SystemUsers_Divisions_ExpireDate";
            this.colSystemUsers_Divisions_ExpireDate.Name = "colSystemUsers_Divisions_ExpireDate";
            this.colSystemUsers_Divisions_ExpireDate.OptionsColumn.AllowEdit = false;
            this.colSystemUsers_Divisions_ExpireDate.OptionsColumn.AllowFocus = false;
            this.colSystemUsers_Divisions_ExpireDate.Visible = true;
            this.colSystemUsers_Divisions_ExpireDate.VisibleIndex = 6;
            this.colSystemUsers_Divisions_ExpireDate.Width = 104;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Disable";
            this.gridColumn9.FieldName = "SystemUsers_Divisions_Disable";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 70;
            // 
            // dgvSystemUsers_Divisions
            // 
            this.dgvSystemUsers_Divisions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSystemUsers_Divisions.Location = new System.Drawing.Point(3, 3);
            this.dgvSystemUsers_Divisions.MainView = this.viewSystemUsers_Divisions;
            this.dgvSystemUsers_Divisions.Name = "dgvSystemUsers_Divisions";
            this.dgvSystemUsers_Divisions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDisable,
            this.btnDelete});
            this.dgvSystemUsers_Divisions.Size = new System.Drawing.Size(822, 371);
            this.dgvSystemUsers_Divisions.TabIndex = 11;
            this.dgvSystemUsers_Divisions.UseEmbeddedNavigator = true;
            this.dgvSystemUsers_Divisions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewSystemUsers_Divisions});
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.dgvSystemUsers_Divisions, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(828, 377);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 462);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // bt_Edit_BookingRooms_Services
            // 
            this.bt_Edit_BookingRooms_Services.AutoHeight = false;
            this.bt_Edit_BookingRooms_Services.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("bt_Edit_BookingRooms_Services.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.bt_Edit_BookingRooms_Services.Name = "bt_Edit_BookingRooms_Services";
            this.bt_Edit_BookingRooms_Services.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // colSystemUsers_Name
            // 
            this.colSystemUsers_Name.AppearanceCell.Options.UseTextOptions = true;
            this.colSystemUsers_Name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Name.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSystemUsers_Name.AppearanceHeader.Options.UseFont = true;
            this.colSystemUsers_Name.AppearanceHeader.Options.UseTextOptions = true;
            this.colSystemUsers_Name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystemUsers_Name.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSystemUsers_Name.Caption = "Tên";
            this.colSystemUsers_Name.FieldName = "SystemUsers_Name";
            this.colSystemUsers_Name.Name = "colSystemUsers_Name";
            this.colSystemUsers_Name.OptionsColumn.AllowEdit = false;
            this.colSystemUsers_Name.OptionsColumn.AllowFocus = false;
            this.colSystemUsers_Name.OptionsColumn.ReadOnly = true;
            this.colSystemUsers_Name.Width = 137;
            // 
            // frmLst_SystemUsers_Divisions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLst_SystemUsers_Divisions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách người trong phòng ban";
            this.Load += new System.EventHandler(this.frmLst_SystemUsers_Divisions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bt_Delete)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpChooseDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpChooseDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDivisions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSystemUsers_Divisions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemUsers_Divisions)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bt_Edit_BookingRooms_Services)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bt_Delete;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDisable;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemUsers_Birthday;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemUsers_Identifier1;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemUsers_Username;
        private DevExpress.XtraGrid.Columns.GridColumn colDivisions_Name;
        private DevExpress.XtraGrid.Views.Grid.GridView viewSystemUsers_Divisions;
        private DevExpress.XtraGrid.GridControl dgvSystemUsers_Divisions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bt_Edit_BookingRooms_Services;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboDivisions;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemUsers_Divisions_AvaiableDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemUsers_Divisions_ExpireDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemUsers_Name;
        private DevExpress.XtraEditors.DateEdit dtpChooseDate;
    }
}
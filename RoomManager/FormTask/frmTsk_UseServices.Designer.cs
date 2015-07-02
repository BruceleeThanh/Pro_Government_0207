namespace RoomManager
{
    partial class frmTsk_UseServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTsk_UseServices));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtPercenTax = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvRooms = new DevExpress.XtraGrid.GridControl();
            this.grvRooms = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CodeRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SkuColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompanyColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.dtpDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbCurrentRoom = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.dgvServices = new DevExpress.XtraGrid.GridControl();
            this.grvServices = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bnAddService = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.NameService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvServiceInRoom = new DevExpress.XtraGrid.GridControl();
            this.grvServiceInRoom = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grcPercentTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grcSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grcIDBookingRoomService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercenTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnAddService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceInRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvServiceInRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuantity
            // 
            this.txtQuantity.AutoHeight = false;
            this.txtQuantity.DisplayFormat.FormatString = "{0:0,0}";
            this.txtQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.EditFormat.FormatString = "{0:0,0}";
            this.txtQuantity.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.Mask.EditMask = "n0";
            this.txtQuantity.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQuantity.MaxLength = 10;
            this.txtQuantity.Name = "txtQuantity";
            // 
            // txtPercenTax
            // 
            this.txtPercenTax.AutoHeight = false;
            this.txtPercenTax.DisplayFormat.FormatString = "{0:0,0}";
            this.txtPercenTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPercenTax.EditFormat.FormatString = "{0:0,0}";
            this.txtPercenTax.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPercenTax.Mask.EditMask = "n0";
            this.txtPercenTax.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPercenTax.MaxLength = 3;
            this.txtPercenTax.Name = "txtPercenTax";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1243, 516);
            this.splitContainerControl1.SplitterPosition = 0;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.55089F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.24717F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.28271F));
            this.tableLayoutPanel1.Controls.Add(this.dgvRooms, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvServices, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvServiceInRoom, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAddNew, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1096, 516);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dgvRooms
            // 
            this.dgvRooms.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRooms.Location = new System.Drawing.Point(3, 46);
            this.dgvRooms.MainView = this.grvRooms;
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.Size = new System.Drawing.Size(120, 431);
            this.dgvRooms.TabIndex = 0;
            this.dgvRooms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRooms});
            // 
            // grvRooms
            // 
            this.grvRooms.ColumnPanelRowHeight = 40;
            this.grvRooms.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CodeRoom,
            this.SkuColumn,
            this.CustomerColumn,
            this.CompanyColumn});
            this.grvRooms.GridControl = this.dgvRooms;
            this.grvRooms.Name = "grvRooms";
            this.grvRooms.OptionsView.EnableAppearanceOddRow = true;
            this.grvRooms.OptionsView.ShowFooter = true;
            this.grvRooms.OptionsView.ShowGroupPanel = false;
            this.grvRooms.OptionsView.ShowIndicator = false;
            this.grvRooms.RowHeight = 25;
            this.grvRooms.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grvRoom_RowClick);
            // 
            // CodeRoom
            // 
            this.CodeRoom.Caption = "CodeRoom";
            this.CodeRoom.FieldName = "Code";
            this.CodeRoom.Name = "CodeRoom";
            // 
            // SkuColumn
            // 
            this.SkuColumn.AppearanceCell.Options.UseTextOptions = true;
            this.SkuColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SkuColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.SkuColumn.AppearanceHeader.Options.UseFont = true;
            this.SkuColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.SkuColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SkuColumn.Caption = "Số phòng";
            this.SkuColumn.FieldName = "RoomSku";
            this.SkuColumn.Name = "SkuColumn";
            this.SkuColumn.OptionsColumn.AllowEdit = false;
            this.SkuColumn.OptionsColumn.AllowFocus = false;
            this.SkuColumn.Visible = true;
            this.SkuColumn.VisibleIndex = 0;
            this.SkuColumn.Width = 98;
            // 
            // CustomerColumn
            // 
            this.CustomerColumn.AppearanceCell.Options.UseTextOptions = true;
            this.CustomerColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CustomerColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CustomerColumn.AppearanceHeader.Options.UseFont = true;
            this.CustomerColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.CustomerColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CustomerColumn.Caption = "Khách";
            this.CustomerColumn.FieldName = "Customers_Name";
            this.CustomerColumn.Name = "CustomerColumn";
            this.CustomerColumn.OptionsColumn.AllowEdit = false;
            this.CustomerColumn.Width = 92;
            // 
            // CompanyColumn
            // 
            this.CompanyColumn.AppearanceCell.Options.UseTextOptions = true;
            this.CompanyColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CompanyColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CompanyColumn.AppearanceHeader.Options.UseFont = true;
            this.CompanyColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.CompanyColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CompanyColumn.Caption = "Đơn vị";
            this.CompanyColumn.FieldName = "Companies_Name";
            this.CompanyColumn.Name = "CompanyColumn";
            this.CompanyColumn.OptionsColumn.AllowEdit = false;
            this.CompanyColumn.Width = 99;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.dtpDate);
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.lbCurrentRoom);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(129, 3);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(686, 37);
            this.panelControl3.TabIndex = 0;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDate.EditValue = null;
            this.dtpDate.Location = new System.Drawing.Point(445, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dtpDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDate.Properties.Mask.BeepOnError = true;
            this.dtpDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpDate.Size = new System.Drawing.Size(138, 20);
            this.dtpDate.TabIndex = 50;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(234, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(0, 13);
            this.labelControl3.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(291, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ngày dùng dịch vụ:";
            // 
            // lbCurrentRoom
            // 
            this.lbCurrentRoom.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbCurrentRoom.Location = new System.Drawing.Point(49, 6);
            this.lbCurrentRoom.Name = "lbCurrentRoom";
            this.lbCurrentRoom.Size = new System.Drawing.Size(57, 13);
            this.lbCurrentRoom.TabIndex = 0;
            this.lbCurrentRoom.Text = "Phòng số :";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(821, 483);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvServices
            // 
            this.dgvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServices.EmbeddedNavigator.Enabled = false;
            this.dgvServices.Location = new System.Drawing.Point(821, 46);
            this.dgvServices.MainView = this.grvServices;
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bnAddService});
            this.dgvServices.Size = new System.Drawing.Size(272, 431);
            this.dgvServices.TabIndex = 0;
            this.dgvServices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvServices});
            // 
            // grvServices
            // 
            this.grvServices.ColumnPanelRowHeight = 35;
            this.grvServices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.NameService});
            this.grvServices.GridControl = this.dgvServices;
            this.grvServices.Name = "grvServices";
            this.grvServices.OptionsFind.AlwaysVisible = true;
            this.grvServices.OptionsView.EnableAppearanceOddRow = true;
            this.grvServices.OptionsView.ShowFooter = true;
            this.grvServices.OptionsView.ShowGroupPanel = false;
            this.grvServices.OptionsView.ShowIndicator = false;
            this.grvServices.RowHeight = 25;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Thêm";
            this.gridColumn10.ColumnEdit = this.bnAddService;
            this.gridColumn10.FieldName = "ID";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 54;
            // 
            // bnAddService
            // 
            this.bnAddService.AutoHeight = false;
            this.bnAddService.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("bnAddService.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.bnAddService.Name = "bnAddService";
            this.bnAddService.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.bnAddService.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnAddService_ButtonClick);
            // 
            // NameService
            // 
            this.NameService.AppearanceCell.Options.UseTextOptions = true;
            this.NameService.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameService.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.NameService.AppearanceHeader.Options.UseFont = true;
            this.NameService.AppearanceHeader.Options.UseTextOptions = true;
            this.NameService.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameService.Caption = "Tên dịch vụ";
            this.NameService.FieldName = "Name";
            this.NameService.Name = "NameService";
            this.NameService.OptionsColumn.AllowEdit = false;
            this.NameService.OptionsColumn.AllowFocus = false;
            this.NameService.Visible = true;
            this.NameService.VisibleIndex = 1;
            this.NameService.Width = 195;
            // 
            // dgvServiceInRoom
            // 
            this.dgvServiceInRoom.Location = new System.Drawing.Point(129, 46);
            this.dgvServiceInRoom.MainView = this.grvServiceInRoom;
            this.dgvServiceInRoom.Name = "dgvServiceInRoom";
            this.dgvServiceInRoom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.btnDelete});
            this.dgvServiceInRoom.Size = new System.Drawing.Size(686, 431);
            this.dgvServiceInRoom.TabIndex = 0;
            this.dgvServiceInRoom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvServiceInRoom});
            // 
            // grvServiceInRoom
            // 
            this.grvServiceInRoom.ColumnPanelRowHeight = 40;
            this.grvServiceInRoom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Date,
            this.ServiceName,
            this.grcQuantity,
            this.Unit,
            this.grcDate,
            this.grcCost,
            this.grcPercentTax,
            this.grcSum,
            this.gridColumn1,
            this.grcIDBookingRoomService});
            this.grvServiceInRoom.GridControl = this.dgvServiceInRoom;
            this.grvServiceInRoom.GroupFormat = "Numeric \"{0:0,0}\"";
            this.grvServiceInRoom.GroupPanelText = "GroupPanel Text";
            this.grvServiceInRoom.Name = "grvServiceInRoom";
            this.grvServiceInRoom.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvServiceInRoom.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvServiceInRoom.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.grvServiceInRoom.OptionsView.EnableAppearanceOddRow = true;
            this.grvServiceInRoom.OptionsView.ShowFooter = true;
            this.grvServiceInRoom.OptionsView.ShowGroupPanel = false;
            this.grvServiceInRoom.OptionsView.ShowIndicator = false;
            this.grvServiceInRoom.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvServiceInRoom.RowHeight = 25;
            this.grvServiceInRoom.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvServiceInRoom_CellValueChanged);
            // 
            // Date
            // 
            this.Date.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Date.AppearanceHeader.Options.UseFont = true;
            this.Date.AppearanceHeader.Options.UseTextOptions = true;
            this.Date.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Date.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.Date.Caption = "Ngày ";
            this.Date.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.Date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Date.FieldName = "Date";
            this.Date.Name = "Date";
            this.Date.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Sum", "Numeric \"{0:0,0}\"")});
            this.Date.Width = 80;
            // 
            // ServiceName
            // 
            this.ServiceName.AppearanceCell.Options.UseTextOptions = true;
            this.ServiceName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ServiceName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ServiceName.AppearanceHeader.Options.UseFont = true;
            this.ServiceName.AppearanceHeader.Options.UseTextOptions = true;
            this.ServiceName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ServiceName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.ServiceName.Caption = "Dịch vụ";
            this.ServiceName.FieldName = "Service_Name";
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.OptionsColumn.AllowEdit = false;
            this.ServiceName.OptionsColumn.AllowFocus = false;
            this.ServiceName.Visible = true;
            this.ServiceName.VisibleIndex = 1;
            this.ServiceName.Width = 166;
            // 
            // grcQuantity
            // 
            this.grcQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcQuantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.grcQuantity.AppearanceHeader.Options.UseFont = true;
            this.grcQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grcQuantity.Caption = "SL";
            this.grcQuantity.ColumnEdit = this.repositoryItemTextEdit3;
            this.grcQuantity.DisplayFormat.FormatString = "{0:0,0}";
            this.grcQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcQuantity.FieldName = "Quantity";
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.Visible = true;
            this.grcQuantity.VisibleIndex = 2;
            this.grcQuantity.Width = 59;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Mask.EditMask = "n0";
            this.repositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit3.MaxLength = 7;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // Unit
            // 
            this.Unit.AppearanceCell.Options.UseTextOptions = true;
            this.Unit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Unit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Unit.AppearanceHeader.Options.UseFont = true;
            this.Unit.AppearanceHeader.Options.UseTextOptions = true;
            this.Unit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Unit.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.Unit.Caption = "Đơn vị";
            this.Unit.FieldName = "Service_Unit";
            this.Unit.Name = "Unit";
            this.Unit.OptionsColumn.AllowEdit = false;
            this.Unit.OptionsColumn.AllowFocus = false;
            this.Unit.Visible = true;
            this.Unit.VisibleIndex = 3;
            this.Unit.Width = 54;
            // 
            // grcDate
            // 
            this.grcDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.grcDate.AppearanceHeader.Options.UseFont = true;
            this.grcDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grcDate.Caption = "Ngày SD";
            this.grcDate.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm";
            this.grcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcDate.FieldName = "Date";
            this.grcDate.Name = "grcDate";
            this.grcDate.OptionsColumn.AllowFocus = false;
            this.grcDate.Visible = true;
            this.grcDate.VisibleIndex = 0;
            this.grcDate.Width = 116;
            // 
            // grcCost
            // 
            this.grcCost.AppearanceCell.Options.UseTextOptions = true;
            this.grcCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCost.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.grcCost.AppearanceHeader.Options.UseFont = true;
            this.grcCost.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCost.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grcCost.Caption = "Giá";
            this.grcCost.ColumnEdit = this.repositoryItemTextEdit2;
            this.grcCost.DisplayFormat.FormatString = "{0:0,0}";
            this.grcCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcCost.FieldName = "Cost";
            this.grcCost.Name = "grcCost";
            this.grcCost.Visible = true;
            this.grcCost.VisibleIndex = 4;
            this.grcCost.Width = 116;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.DisplayFormat.FormatString = "{0:0,0}";
            this.repositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.EditFormat.FormatString = "n";
            this.repositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.Mask.EditMask = "n0";
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit2.MaxLength = 10;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // grcPercentTax
            // 
            this.grcPercentTax.AppearanceCell.Options.UseTextOptions = true;
            this.grcPercentTax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcPercentTax.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.grcPercentTax.AppearanceHeader.Options.UseFont = true;
            this.grcPercentTax.AppearanceHeader.Options.UseTextOptions = true;
            this.grcPercentTax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcPercentTax.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grcPercentTax.Caption = "VAT";
            this.grcPercentTax.ColumnEdit = this.repositoryItemTextEdit1;
            this.grcPercentTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcPercentTax.FieldName = "PercentTax";
            this.grcPercentTax.Name = "grcPercentTax";
            this.grcPercentTax.Visible = true;
            this.grcPercentTax.VisibleIndex = 5;
            this.grcPercentTax.Width = 48;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "n0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.MaxLength = 3;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // grcSum
            // 
            this.grcSum.AppearanceCell.Options.UseTextOptions = true;
            this.grcSum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcSum.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.grcSum.AppearanceHeader.Options.UseFont = true;
            this.grcSum.AppearanceHeader.Options.UseTextOptions = true;
            this.grcSum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcSum.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grcSum.Caption = "Tổng tiền";
            this.grcSum.DisplayFormat.FormatString = "{0:0,0}";
            this.grcSum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcSum.FieldName = "Sum";
            this.grcSum.GroupFormat.FormatString = "Numeric \"{0:0,0}\"";
            this.grcSum.Name = "grcSum";
            this.grcSum.OptionsColumn.AllowEdit = false;
            this.grcSum.OptionsColumn.AllowFocus = false;
            this.grcSum.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Sum", "{0:0,0}")});
            this.grcSum.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.grcSum.Visible = true;
            this.grcSum.VisibleIndex = 6;
            this.grcSum.Width = 158;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Hủy";
            this.gridColumn1.ColumnEdit = this.btnDelete;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 83;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnDelete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnDelete_ButtonClick);
            // 
            // grcIDBookingRoomService
            // 
            this.grcIDBookingRoomService.Caption = "IDBookingRoomService";
            this.grcIDBookingRoomService.FieldName = "ID";
            this.grcIDBookingRoomService.Name = "grcIDBookingRoomService";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.Appearance.Options.UseFont = true;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(821, 10);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(126, 23);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "Thêm dịch vụ";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // frmTsk_UseServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 516);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTsk_UseServices";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sử Dụng Dịch Vụ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTsk_UseServices_FormClosing);
            this.Load += new System.EventHandler(this.frmTsk_UseServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercenTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnAddService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceInRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvServiceInRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl dgvServiceInRoom;
        private DevExpress.XtraGrid.Views.Grid.GridView grvServiceInRoom;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn Date;
        private DevExpress.XtraGrid.Columns.GridColumn ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn grcQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lbCurrentRoom;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn Unit;
        private DevExpress.XtraGrid.Columns.GridColumn grcDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcCost;
        private DevExpress.XtraGrid.Columns.GridColumn grcPercentTax;
        private DevExpress.XtraGrid.GridControl dgvServices;
        private DevExpress.XtraGrid.Views.Grid.GridView grvServices;
        private DevExpress.XtraGrid.Columns.GridColumn NameService;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bnAddService;
        private DevExpress.XtraGrid.GridControl dgvRooms;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRooms;
        private DevExpress.XtraGrid.Columns.GridColumn SkuColumn;
        private DevExpress.XtraGrid.Columns.GridColumn grcSum;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerColumn;
        private DevExpress.XtraGrid.Columns.GridColumn CompanyColumn;
        private DevExpress.XtraGrid.Columns.GridColumn CodeRoom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtPercenTax;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        private DevExpress.XtraEditors.DateEdit dtpDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private DevExpress.XtraGrid.Columns.GridColumn grcIDBookingRoomService;

    }
}
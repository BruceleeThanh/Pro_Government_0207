namespace RoomManager
{
    partial class frmTsk_SplitBillHalls_Step1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTsk_SplitBillHalls_Step1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgvHalls = new DevExpress.XtraGrid.GridControl();
            this.viewHalls = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChooseRooms = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtChooseHalls = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgvServices = new DevExpress.XtraGrid.GridControl();
            this.viewServices = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercentTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChooseService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtChooseService = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSplit = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChooseHalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChooseService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSplit, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(934, 612);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgvHalls);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(928, 284);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách hội trường";
            // 
            // dgvHalls
            // 
            this.dgvHalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHalls.Location = new System.Drawing.Point(2, 21);
            this.dgvHalls.MainView = this.viewHalls;
            this.dgvHalls.Name = "dgvHalls";
            this.dgvHalls.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtChooseHalls});
            this.dgvHalls.Size = new System.Drawing.Size(924, 261);
            this.dgvHalls.TabIndex = 3;
            this.dgvHalls.UseEmbeddedNavigator = true;
            this.dgvHalls.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewHalls});
            // 
            // viewHalls
            // 
            this.viewHalls.ColumnPanelRowHeight = 35;
            this.viewHalls.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn9,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn5,
            this.colChooseRooms});
            this.viewHalls.GridControl = this.dgvHalls;
            this.viewHalls.Name = "viewHalls";
            this.viewHalls.OptionsView.EnableAppearanceEvenRow = true;
            this.viewHalls.OptionsView.ShowGroupPanel = false;
            this.viewHalls.RowHeight = 30;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Tên hội trường";
            this.gridColumn6.FieldName = "Sku";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 160;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Ngày tạo";
            this.gridColumn9.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn9.FieldName = "Date";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 130;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Giá hội trường";
            this.gridColumn7.DisplayFormat.FormatString = "n0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Cost";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 170;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Thuế";
            this.gridColumn8.DisplayFormat.FormatString = "n";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "PercentTax";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Thành tiền (VND)";
            this.gridColumn5.DisplayFormat.FormatString = "n0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Total";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 230;
            // 
            // colChooseRooms
            // 
            this.colChooseRooms.AppearanceCell.Options.UseTextOptions = true;
            this.colChooseRooms.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChooseRooms.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.colChooseRooms.AppearanceHeader.Options.UseFont = true;
            this.colChooseRooms.AppearanceHeader.Options.UseTextOptions = true;
            this.colChooseRooms.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChooseRooms.Caption = "Tách hóa đơn";
            this.colChooseRooms.ColumnEdit = this.txtChooseHalls;
            this.colChooseRooms.FieldName = "IndexSubHalls";
            this.colChooseRooms.Name = "colChooseRooms";
            this.colChooseRooms.Visible = true;
            this.colChooseRooms.VisibleIndex = 5;
            this.colChooseRooms.Width = 110;
            // 
            // txtChooseHalls
            // 
            this.txtChooseHalls.AutoHeight = false;
            this.txtChooseHalls.Mask.EditMask = "d";
            this.txtChooseHalls.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtChooseHalls.MaxLength = 2;
            this.txtChooseHalls.Name = "txtChooseHalls";
            this.txtChooseHalls.EditValueChanged += new System.EventHandler(this.txtChooseHalls_EditValueChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgvServices);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 293);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(928, 284);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Danh sách dịch vụ";
            // 
            // dgvServices
            // 
            this.dgvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServices.Location = new System.Drawing.Point(2, 21);
            this.dgvServices.MainView = this.viewServices;
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtChooseService});
            this.dgvServices.Size = new System.Drawing.Size(924, 261);
            this.dgvServices.TabIndex = 15;
            this.dgvServices.UseEmbeddedNavigator = true;
            this.dgvServices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewServices,
            this.gridView3});
            // 
            // viewServices
            // 
            this.viewServices.ColumnPanelRowHeight = 30;
            this.viewServices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.colDate,
            this.gridColumn2,
            this.colCost,
            this.colQuantity,
            this.colPercentTax,
            this.gridColumn4,
            this.colChooseService});
            this.viewServices.GridControl = this.dgvServices;
            this.viewServices.Name = "viewServices";
            this.viewServices.OptionsView.EnableAppearanceEvenRow = true;
            this.viewServices.OptionsView.ShowFooter = true;
            this.viewServices.OptionsView.ShowGroupPanel = false;
            this.viewServices.OptionsView.ShowIndicator = false;
            this.viewServices.RowHeight = 25;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Hội trường";
            this.gridColumn3.FieldName = "SkuHall";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 90;
            // 
            // colDate
            // 
            this.colDate.AppearanceCell.Options.UseTextOptions = true;
            this.colDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.colDate.AppearanceHeader.Options.UseFont = true;
            this.colDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDate.Caption = "Ngày";
            this.colDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.FieldName = "Date";
            this.colDate.MinWidth = 15;
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.OptionsColumn.AllowFocus = false;
            this.colDate.OptionsColumn.ReadOnly = true;
            this.colDate.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "Tên dịch vụ";
            this.gridColumn2.FieldName = "NameService";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 150;
            // 
            // colCost
            // 
            this.colCost.AppearanceCell.Options.UseTextOptions = true;
            this.colCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCost.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.colCost.AppearanceHeader.Options.UseFont = true;
            this.colCost.AppearanceHeader.Options.UseTextOptions = true;
            this.colCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCost.Caption = "Đơn giá (VND)";
            this.colCost.DisplayFormat.FormatString = "n0";
            this.colCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCost.FieldName = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.OptionsColumn.AllowEdit = false;
            this.colCost.OptionsColumn.AllowFocus = false;
            this.colCost.Visible = true;
            this.colCost.VisibleIndex = 3;
            this.colCost.Width = 150;
            // 
            // colQuantity
            // 
            this.colQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.colQuantity.AppearanceHeader.Options.UseFont = true;
            this.colQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQuantity.Caption = "Số lượng";
            this.colQuantity.DisplayFormat.FormatString = "n0";
            this.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowEdit = false;
            this.colQuantity.OptionsColumn.AllowFocus = false;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 4;
            this.colQuantity.Width = 100;
            // 
            // colPercentTax
            // 
            this.colPercentTax.AppearanceCell.Options.UseTextOptions = true;
            this.colPercentTax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercentTax.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.colPercentTax.AppearanceHeader.Options.UseFont = true;
            this.colPercentTax.AppearanceHeader.Options.UseTextOptions = true;
            this.colPercentTax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercentTax.Caption = "Thuế";
            this.colPercentTax.DisplayFormat.FormatString = "n";
            this.colPercentTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercentTax.FieldName = "PercentTax";
            this.colPercentTax.Name = "colPercentTax";
            this.colPercentTax.OptionsColumn.AllowEdit = false;
            this.colPercentTax.OptionsColumn.AllowFocus = false;
            this.colPercentTax.Visible = true;
            this.colPercentTax.VisibleIndex = 5;
            this.colPercentTax.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Thành tiền (VND)";
            this.gridColumn4.DisplayFormat.FormatString = "n0";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Total";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 150;
            // 
            // colChooseService
            // 
            this.colChooseService.AppearanceCell.Options.UseTextOptions = true;
            this.colChooseService.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChooseService.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.colChooseService.AppearanceHeader.Options.UseFont = true;
            this.colChooseService.AppearanceHeader.Options.UseTextOptions = true;
            this.colChooseService.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChooseService.Caption = "Tách hóa đơn";
            this.colChooseService.ColumnEdit = this.txtChooseService;
            this.colChooseService.FieldName = "IndexSubServices";
            this.colChooseService.Name = "colChooseService";
            this.colChooseService.Visible = true;
            this.colChooseService.VisibleIndex = 7;
            this.colChooseService.Width = 100;
            // 
            // txtChooseService
            // 
            this.txtChooseService.AutoHeight = false;
            this.txtChooseService.Mask.EditMask = "d";
            this.txtChooseService.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtChooseService.MaxLength = 2;
            this.txtChooseService.Name = "txtChooseService";
            this.txtChooseService.EditValueChanged += new System.EventHandler(this.txtChooseService_EditValueChanged);
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.dgvServices;
            this.gridView3.Name = "gridView3";
            // 
            // btnSplit
            // 
            this.btnSplit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSplit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSplit.Appearance.Options.UseFont = true;
            this.btnSplit.Image = ((System.Drawing.Image)(resources.GetObject("btnSplit.Image")));
            this.btnSplit.Location = new System.Drawing.Point(791, 583);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(140, 25);
            this.btnSplit.TabIndex = 1;
            this.btnSplit.Text = "Tách hóa đơn";
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // frmTsk_SplitBillHalls_Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 612);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTsk_SplitBillHalls_Step1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tách hóa đơn bước 1";
            this.Load += new System.EventHandler(this.frmTsk_SplitBill_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChooseHalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChooseService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl dgvServices;
        private DevExpress.XtraGrid.Views.Grid.GridView viewServices;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colPercentTax;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCost;
        private DevExpress.XtraGrid.Columns.GridColumn colChooseService;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.GridControl dgvHalls;
        private DevExpress.XtraGrid.Views.Grid.GridView viewHalls;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn colChooseRooms;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtChooseHalls;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtChooseService;
        private DevExpress.XtraEditors.SimpleButton btnSplit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}
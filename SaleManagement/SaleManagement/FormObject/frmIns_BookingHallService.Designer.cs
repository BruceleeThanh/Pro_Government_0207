namespace SaleManagement
{
    partial class frmIns_BookingServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIns_BookingServices));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gcServiceList = new DevExpress.XtraGrid.GridControl();
            this.gvServiceList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rceCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.sbCreate = new DevExpress.XtraEditors.SimpleButton();
            this.sbClear = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcServiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvServiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rceCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 950F));
            this.tableLayoutPanel1.Controls.Add(this.gcServiceList, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 430F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 430);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // gcServiceList
            // 
            this.gcServiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcServiceList.Location = new System.Drawing.Point(3, 3);
            this.gcServiceList.MainView = this.gvServiceList;
            this.gcServiceList.Name = "gcServiceList";
            this.gcServiceList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rceCheck});
            this.gcServiceList.Size = new System.Drawing.Size(944, 424);
            this.gcServiceList.TabIndex = 49;
            this.gcServiceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvServiceList});
            // 
            // gvServiceList
            // 
            this.gvServiceList.ColumnPanelRowHeight = 40;
            this.gvServiceList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn6,
            this.gridColumn7});
            this.gvServiceList.GridControl = this.gcServiceList;
            this.gvServiceList.Name = "gvServiceList";
            this.gvServiceList.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gvServiceList.OptionsSelection.MultiSelect = true;
            this.gvServiceList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvServiceList.OptionsView.EnableAppearanceEvenRow = true;
            this.gvServiceList.OptionsView.ShowGroupPanel = false;
            this.gvServiceList.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvServiceList.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvServiceList_CustomDrawCell);
            this.gvServiceList.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvServiceList_CustomRowCellEdit);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Tên";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 540;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Chọn";
            this.gridColumn9.FieldName = "Check";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.FixedWidth = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 51;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "ID";
            this.gridColumn10.FieldName = "ID";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Giá tham khảo";
            this.gridColumn6.DisplayFormat.FormatString = "n0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "CostRef";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 235;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Đơn vị";
            this.gridColumn7.FieldName = "Unit";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 354;
            // 
            // rceCheck
            // 
            this.rceCheck.AutoHeight = false;
            this.rceCheck.Caption = "Check";
            this.rceCheck.Name = "rceCheck";
            this.rceCheck.ValueChecked = "Y";
            this.rceCheck.ValueGrayed = 2;
            this.rceCheck.ValueUnchecked = "N";
            this.rceCheck.CheckedChanged += new System.EventHandler(this.rceCheck_CheckedChanged);
            // 
            // sbCreate
            // 
            this.sbCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbCreate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCreate.Appearance.Options.UseFont = true;
            this.sbCreate.Image = ((System.Drawing.Image)(resources.GetObject("sbCreate.Image")));
            this.sbCreate.Location = new System.Drawing.Point(434, 452);
            this.sbCreate.Name = "sbCreate";
            this.sbCreate.Size = new System.Drawing.Size(75, 23);
            this.sbCreate.TabIndex = 4;
            this.sbCreate.Text = "Chọn";
            this.sbCreate.Click += new System.EventHandler(this.sbCreate_Click);
            // 
            // sbClear
            // 
            this.sbClear.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbClear.Appearance.Options.UseFont = true;
            this.sbClear.Image = ((System.Drawing.Image)(resources.GetObject("sbClear.Image")));
            this.sbClear.Location = new System.Drawing.Point(545, 452);
            this.sbClear.Name = "sbClear";
            this.sbClear.Size = new System.Drawing.Size(75, 23);
            this.sbClear.TabIndex = 5;
            this.sbClear.Text = "Làm lại";
            this.sbClear.Click += new System.EventHandler(this.sbClear_Click);
            // 
            // frmIns_BookingServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 503);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.sbClear);
            this.Controls.Add(this.sbCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIns_BookingServices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo dịch vụ";
            this.Load += new System.EventHandler(this.AddBookingService_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcServiceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvServiceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rceCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton sbCreate;
        private DevExpress.XtraEditors.SimpleButton sbClear;
        private DevExpress.XtraGrid.GridControl gcServiceList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvServiceList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rceCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}
namespace RoomManager
{
    partial class frm_UnPay
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
            this.label1 = new System.Windows.Forms.Label();
            this.lueIDCompanies = new DevExpress.XtraEditors.LookUpEdit();
            this.dgvPaymentViewUnPay = new DevExpress.XtraGrid.GridControl();
            this.grvPaymentViewUnPay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDBookingRs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnReLoadData = new System.Windows.Forms.Button();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueIDCompanies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentViewUnPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPaymentViewUnPay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Công ty";
            // 
            // lueIDCompanies
            // 
            this.lueIDCompanies.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lueIDCompanies.Location = new System.Drawing.Point(118, 40);
            this.lueIDCompanies.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.lueIDCompanies.Name = "lueIDCompanies";
            this.lueIDCompanies.Properties.Appearance.Options.UseTextOptions = true;
            this.lueIDCompanies.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lueIDCompanies.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lueIDCompanies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueIDCompanies.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên công ty")});
            this.lueIDCompanies.Properties.NullText = "";
            this.lueIDCompanies.Properties.NullValuePrompt = "Chọn tên công ty đã tồn tại";
            this.lueIDCompanies.Properties.NullValuePromptShowForEmptyValue = true;
            this.lueIDCompanies.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueIDCompanies.Size = new System.Drawing.Size(260, 20);
            this.lueIDCompanies.TabIndex = 3;
            this.lueIDCompanies.EditValueChanged += new System.EventHandler(this.lueIDCompanies_EditValueChanged);
            // 
            // dgvPaymentViewUnPay
            // 
            this.dgvPaymentViewUnPay.Location = new System.Drawing.Point(51, 98);
            this.dgvPaymentViewUnPay.MainView = this.grvPaymentViewUnPay;
            this.dgvPaymentViewUnPay.Name = "dgvPaymentViewUnPay";
            this.dgvPaymentViewUnPay.Size = new System.Drawing.Size(1292, 493);
            this.dgvPaymentViewUnPay.TabIndex = 4;
            this.dgvPaymentViewUnPay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPaymentViewUnPay});
            // 
            // grvPaymentViewUnPay
            // 
            this.grvPaymentViewUnPay.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDBookingRs,
            this.gridColumn1,
            this.gridColumn2,
            this.IDService,
            this.ServiceName,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.grvPaymentViewUnPay.GridControl = this.dgvPaymentViewUnPay;
            this.grvPaymentViewUnPay.Name = "grvPaymentViewUnPay";
            // 
            // IDBookingRs
            // 
            this.IDBookingRs.Caption = "IDBookingRs";
            this.IDBookingRs.FieldName = "BookingRs_ID";
            this.IDBookingRs.Name = "IDBookingRs";
            this.IDBookingRs.OptionsColumn.AllowEdit = false;
            this.IDBookingRs.Visible = true;
            this.IDBookingRs.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ObjectType";
            this.gridColumn1.FieldName = "ObjectType";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã";
            this.gridColumn2.FieldName = "SkuObject";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // IDService
            // 
            this.IDService.Caption = "ID Service";
            this.IDService.FieldName = "IDBookingService";
            this.IDService.Name = "IDService";
            this.IDService.Visible = true;
            this.IDService.VisibleIndex = 3;
            // 
            // ServiceName
            // 
            this.ServiceName.Caption = "Tên d.vụ";
            this.ServiceName.FieldName = "Services_Name";
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.Visible = true;
            this.ServiceName.VisibleIndex = 4;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Time1";
            this.gridColumn3.FieldName = "Time1";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Time2";
            this.gridColumn4.FieldName = "Time2";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Trạng thái d.vụ";
            this.gridColumn5.FieldName = "DisplayService_PaymentStatus";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Trạng thái phòng/h.trường";
            this.gridColumn6.FieldName = "DisplayObject_PaymentStatus";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Trạng thái BookingRs";
            this.gridColumn7.FieldName = "DisplayBillR_PaymentStatus";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Mã hóa đơn lẻ d.vụ";
            this.gridColumn9.FieldName = "Services_SubPayment";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 11;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Mã hóa đơn lẻ Object";
            this.gridColumn8.FieldName = "Object_SubPayment";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tiền d.vụ";
            this.gridColumn10.DisplayFormat.FormatString = "{0:0,0}";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Services_Cost";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 12;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Tiền phòng / Tiền hội trường";
            this.gridColumn11.DisplayFormat.FormatString = "{0:0,0}";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "DisplayMoneySumRoom";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 13;
            // 
            // btnReLoadData
            // 
            this.btnReLoadData.Location = new System.Drawing.Point(399, 38);
            this.btnReLoadData.Name = "btnReLoadData";
            this.btnReLoadData.Size = new System.Drawing.Size(157, 23);
            this.btnReLoadData.TabIndex = 6;
            this.btnReLoadData.Text = "Dữ liệu chưa thanh toán";
            this.btnReLoadData.UseVisualStyleBackColor = true;
            this.btnReLoadData.Click += new System.EventHandler(this.btnReLoadData_Click);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Tiền pending";
            this.gridColumn12.DisplayFormat.FormatString = "{0:0,0}";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "DisplayMoneyPendingRoom";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 14;
            // 
            // frm_UnPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 626);
            this.Controls.Add(this.btnReLoadData);
            this.Controls.Add(this.dgvPaymentViewUnPay);
            this.Controls.Add(this.lueIDCompanies);
            this.Controls.Add(this.label1);
            this.Name = "frm_UnPay";
            this.Text = "frm_UnPay";
            this.Load += new System.EventHandler(this.frm_UnPay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueIDCompanies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentViewUnPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPaymentViewUnPay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lueIDCompanies;
        private DevExpress.XtraGrid.GridControl dgvPaymentViewUnPay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPaymentViewUnPay;
        private DevExpress.XtraGrid.Columns.GridColumn IDBookingRs;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn IDService;
        private DevExpress.XtraGrid.Columns.GridColumn ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.Button btnReLoadData;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}
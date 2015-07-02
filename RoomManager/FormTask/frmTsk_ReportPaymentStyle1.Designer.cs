namespace RoomManager
{
    partial class frmTsk_ReportPaymentStyle1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTsk_ReportPaymentStyle1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvReportPaymentStyle1 = new DevExpress.XtraGrid.GridControl();
            this.grvReportPaymentStyle1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtNote = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrintGroupPayment = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintPersonalPayment = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportPaymentStyle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReportPaymentStyle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvReportPaymentStyle1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.07633F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.923664F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1150, 545);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvReportPaymentStyle1
            // 
            this.dgvReportPaymentStyle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportPaymentStyle1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReportPaymentStyle1.Location = new System.Drawing.Point(3, 2);
            this.dgvReportPaymentStyle1.MainView = this.grvReportPaymentStyle1;
            this.dgvReportPaymentStyle1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReportPaymentStyle1.Name = "dgvReportPaymentStyle1";
            this.dgvReportPaymentStyle1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtNote});
            this.dgvReportPaymentStyle1.Size = new System.Drawing.Size(1144, 468);
            this.dgvReportPaymentStyle1.TabIndex = 1;
            this.dgvReportPaymentStyle1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReportPaymentStyle1});
            // 
            // grvReportPaymentStyle1
            // 
            this.grvReportPaymentStyle1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.grvReportPaymentStyle1.GridControl = this.dgvReportPaymentStyle1;
            this.grvReportPaymentStyle1.Name = "grvReportPaymentStyle1";
            this.grvReportPaymentStyle1.OptionsView.ColumnAutoWidth = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ngày";
            this.gridColumn1.FieldName = "Date";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ghi chú";
            this.gridColumn2.ColumnEdit = this.txtNote;
            this.gridColumn2.FieldName = "Note";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 177;
            // 
            // txtNote
            // 
            this.txtNote.AutoHeight = false;
            this.txtNote.Name = "txtNote";
            this.txtNote.Leave += new System.EventHandler(this.txtNote_Leave);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Số người";
            this.gridColumn3.DisplayFormat.FormatString = "{0:0,0}";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "CountCustomerInGroup";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tiền phòng";
            this.gridColumn4.DisplayFormat.FormatString = "{0:0,0}";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Room_Fee";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 135;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tiền tiệc";
            this.gridColumn5.DisplayFormat.FormatString = "{0:0,0}";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Hall_Fee";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 182;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.05264F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.94737F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel2.Controls.Add(this.btnPrintGroupPayment, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPrintPersonalPayment, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 475);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1144, 46);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnPrintGroupPayment
            // 
            this.btnPrintGroupPayment.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPrintGroupPayment.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnPrintGroupPayment.Appearance.Options.UseFont = true;
            this.btnPrintGroupPayment.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintGroupPayment.Image")));
            this.btnPrintGroupPayment.Location = new System.Drawing.Point(959, 6);
            this.btnPrintGroupPayment.Margin = new System.Windows.Forms.Padding(3, 4, 23, 4);
            this.btnPrintGroupPayment.Name = "btnPrintGroupPayment";
            this.btnPrintGroupPayment.Size = new System.Drawing.Size(162, 33);
            this.btnPrintGroupPayment.TabIndex = 2;
            this.btnPrintGroupPayment.Text = "In  phiếu thu tiệc";
            this.btnPrintGroupPayment.Click += new System.EventHandler(this.btnPrintGroupPayment_Click);
            // 
            // btnPrintPersonalPayment
            // 
            this.btnPrintPersonalPayment.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPrintPersonalPayment.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnPrintPersonalPayment.Appearance.Options.UseFont = true;
            this.btnPrintPersonalPayment.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPersonalPayment.Image")));
            this.btnPrintPersonalPayment.Location = new System.Drawing.Point(738, 6);
            this.btnPrintPersonalPayment.Margin = new System.Windows.Forms.Padding(3, 4, 23, 4);
            this.btnPrintPersonalPayment.Name = "btnPrintPersonalPayment";
            this.btnPrintPersonalPayment.Size = new System.Drawing.Size(189, 33);
            this.btnPrintPersonalPayment.TabIndex = 3;
            this.btnPrintPersonalPayment.Text = "In phiếu thu khách lẻ";
            this.btnPrintPersonalPayment.Click += new System.EventHandler(this.btnPrintPersonalPayment_Click);
            // 
            // frmTsk_ReportPaymentStyle1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 545);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTsk_ReportPaymentStyle1";
            this.Text = "frmTsk_ReportPaymentStyle1";
            this.Load += new System.EventHandler(this.frmTsk_ReportPaymentStyle1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportPaymentStyle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReportPaymentStyle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl dgvReportPaymentStyle1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvReportPaymentStyle1;
        private DevExpress.XtraEditors.SimpleButton btnPrintGroupPayment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnPrintPersonalPayment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtNote;

    }
}
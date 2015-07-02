namespace RoomManager
{
    partial class frmTsk_StatusInMonth_Room
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTsk_StatusInMonth_Room));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dtpCheckPoint = new DevExpress.XtraEditors.DateEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCheckPoint.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCheckPoint.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 63);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1022, 466);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cRoom,
            this.c1,
            this.c2,
            this.c3,
            this.c4,
            this.c5,
            this.c6,
            this.c7,
            this.c8,
            this.c9,
            this.c10,
            this.c11,
            this.c12,
            this.c13,
            this.c14,
            this.c15,
            this.c16,
            this.c17,
            this.c18,
            this.c19,
            this.c20,
            this.c21,
            this.c22,
            this.c23,
            this.c24,
            this.c25,
            this.c26,
            this.c27,
            this.c28,
            this.c29,
            this.c30,
            this.c31,
            this.cTotal});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridView1.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // cRoom
            // 
            this.cRoom.Caption = "P";
            this.cRoom.FieldName = "Sku";
            this.cRoom.Name = "cRoom";
            this.cRoom.OptionsColumn.AllowEdit = false;
            this.cRoom.Visible = true;
            this.cRoom.VisibleIndex = 0;
            // 
            // c1
            // 
            this.c1.Caption = "1";
            this.c1.FieldName = "Date1";
            this.c1.Name = "c1";
            this.c1.OptionsColumn.AllowEdit = false;
            this.c1.Visible = true;
            this.c1.VisibleIndex = 1;
            // 
            // c2
            // 
            this.c2.Caption = "2";
            this.c2.FieldName = "Date2";
            this.c2.Name = "c2";
            this.c2.OptionsColumn.AllowEdit = false;
            this.c2.Visible = true;
            this.c2.VisibleIndex = 2;
            // 
            // c3
            // 
            this.c3.Caption = "3";
            this.c3.FieldName = "Date3";
            this.c3.Name = "c3";
            this.c3.OptionsColumn.AllowEdit = false;
            this.c3.Visible = true;
            this.c3.VisibleIndex = 3;
            // 
            // c4
            // 
            this.c4.Caption = "4";
            this.c4.FieldName = "Date4";
            this.c4.Name = "c4";
            this.c4.OptionsColumn.AllowEdit = false;
            this.c4.Visible = true;
            this.c4.VisibleIndex = 4;
            // 
            // c5
            // 
            this.c5.Caption = "5";
            this.c5.FieldName = "Date5";
            this.c5.Name = "c5";
            this.c5.OptionsColumn.AllowEdit = false;
            this.c5.Visible = true;
            this.c5.VisibleIndex = 5;
            // 
            // c6
            // 
            this.c6.Caption = "6";
            this.c6.FieldName = "Date6";
            this.c6.Name = "c6";
            this.c6.OptionsColumn.AllowEdit = false;
            this.c6.Visible = true;
            this.c6.VisibleIndex = 6;
            // 
            // c7
            // 
            this.c7.Caption = "7";
            this.c7.FieldName = "Date7";
            this.c7.Name = "c7";
            this.c7.OptionsColumn.AllowEdit = false;
            this.c7.Visible = true;
            this.c7.VisibleIndex = 7;
            // 
            // c8
            // 
            this.c8.Caption = "8";
            this.c8.FieldName = "Date8";
            this.c8.Name = "c8";
            this.c8.OptionsColumn.AllowEdit = false;
            this.c8.Visible = true;
            this.c8.VisibleIndex = 8;
            // 
            // c9
            // 
            this.c9.Caption = "9";
            this.c9.FieldName = "Date9";
            this.c9.Name = "c9";
            this.c9.OptionsColumn.AllowEdit = false;
            this.c9.Visible = true;
            this.c9.VisibleIndex = 9;
            // 
            // c10
            // 
            this.c10.Caption = "10";
            this.c10.FieldName = "Date10";
            this.c10.Name = "c10";
            this.c10.OptionsColumn.AllowEdit = false;
            this.c10.Visible = true;
            this.c10.VisibleIndex = 10;
            // 
            // c11
            // 
            this.c11.Caption = "11";
            this.c11.FieldName = "Date11";
            this.c11.Name = "c11";
            this.c11.OptionsColumn.AllowEdit = false;
            this.c11.Visible = true;
            this.c11.VisibleIndex = 11;
            // 
            // c12
            // 
            this.c12.Caption = "12";
            this.c12.FieldName = "Date12";
            this.c12.Name = "c12";
            this.c12.OptionsColumn.AllowEdit = false;
            this.c12.Visible = true;
            this.c12.VisibleIndex = 12;
            // 
            // c13
            // 
            this.c13.Caption = "13";
            this.c13.FieldName = "Date13";
            this.c13.Name = "c13";
            this.c13.OptionsColumn.AllowEdit = false;
            this.c13.Visible = true;
            this.c13.VisibleIndex = 13;
            // 
            // c14
            // 
            this.c14.Caption = "14";
            this.c14.FieldName = "Date14";
            this.c14.Name = "c14";
            this.c14.OptionsColumn.AllowEdit = false;
            this.c14.Visible = true;
            this.c14.VisibleIndex = 14;
            // 
            // c15
            // 
            this.c15.Caption = "15";
            this.c15.FieldName = "Date15";
            this.c15.Name = "c15";
            this.c15.OptionsColumn.AllowEdit = false;
            this.c15.Visible = true;
            this.c15.VisibleIndex = 15;
            // 
            // c16
            // 
            this.c16.Caption = "16";
            this.c16.FieldName = "Date16";
            this.c16.Name = "c16";
            this.c16.OptionsColumn.AllowEdit = false;
            this.c16.Visible = true;
            this.c16.VisibleIndex = 16;
            // 
            // c17
            // 
            this.c17.Caption = "17";
            this.c17.FieldName = "Date17";
            this.c17.Name = "c17";
            this.c17.OptionsColumn.AllowEdit = false;
            this.c17.Visible = true;
            this.c17.VisibleIndex = 17;
            // 
            // c18
            // 
            this.c18.Caption = "18";
            this.c18.FieldName = "Date18";
            this.c18.Name = "c18";
            this.c18.OptionsColumn.AllowEdit = false;
            this.c18.Visible = true;
            this.c18.VisibleIndex = 18;
            // 
            // c19
            // 
            this.c19.Caption = "19";
            this.c19.FieldName = "Date19";
            this.c19.Name = "c19";
            this.c19.OptionsColumn.AllowEdit = false;
            this.c19.Visible = true;
            this.c19.VisibleIndex = 19;
            // 
            // c20
            // 
            this.c20.Caption = "20";
            this.c20.FieldName = "Date20";
            this.c20.Name = "c20";
            this.c20.OptionsColumn.AllowEdit = false;
            this.c20.Visible = true;
            this.c20.VisibleIndex = 20;
            // 
            // c21
            // 
            this.c21.Caption = "21";
            this.c21.FieldName = "Date21";
            this.c21.Name = "c21";
            this.c21.OptionsColumn.AllowEdit = false;
            this.c21.Visible = true;
            this.c21.VisibleIndex = 21;
            // 
            // c22
            // 
            this.c22.Caption = "22";
            this.c22.FieldName = "Date22";
            this.c22.Name = "c22";
            this.c22.OptionsColumn.AllowEdit = false;
            this.c22.Visible = true;
            this.c22.VisibleIndex = 22;
            // 
            // c23
            // 
            this.c23.Caption = "23";
            this.c23.FieldName = "Date23";
            this.c23.Name = "c23";
            this.c23.OptionsColumn.AllowEdit = false;
            this.c23.Visible = true;
            this.c23.VisibleIndex = 23;
            // 
            // c24
            // 
            this.c24.Caption = "24";
            this.c24.FieldName = "Date24";
            this.c24.Name = "c24";
            this.c24.OptionsColumn.AllowEdit = false;
            this.c24.Visible = true;
            this.c24.VisibleIndex = 24;
            // 
            // c25
            // 
            this.c25.Caption = "25";
            this.c25.FieldName = "Date25";
            this.c25.Name = "c25";
            this.c25.OptionsColumn.AllowEdit = false;
            this.c25.Visible = true;
            this.c25.VisibleIndex = 25;
            // 
            // c26
            // 
            this.c26.Caption = "26";
            this.c26.FieldName = "Date26";
            this.c26.Name = "c26";
            this.c26.OptionsColumn.AllowEdit = false;
            this.c26.Visible = true;
            this.c26.VisibleIndex = 26;
            // 
            // c27
            // 
            this.c27.Caption = "27";
            this.c27.FieldName = "Date27";
            this.c27.Name = "c27";
            this.c27.OptionsColumn.AllowEdit = false;
            this.c27.Visible = true;
            this.c27.VisibleIndex = 27;
            // 
            // c28
            // 
            this.c28.Caption = "28";
            this.c28.FieldName = "Date28";
            this.c28.Name = "c28";
            this.c28.OptionsColumn.AllowEdit = false;
            this.c28.Visible = true;
            this.c28.VisibleIndex = 28;
            // 
            // c29
            // 
            this.c29.Caption = "29";
            this.c29.FieldName = "Date29";
            this.c29.Name = "c29";
            this.c29.OptionsColumn.AllowEdit = false;
            this.c29.Visible = true;
            this.c29.VisibleIndex = 29;
            // 
            // c30
            // 
            this.c30.Caption = "30";
            this.c30.FieldName = "Date30";
            this.c30.Name = "c30";
            this.c30.OptionsColumn.AllowEdit = false;
            this.c30.Visible = true;
            this.c30.VisibleIndex = 30;
            // 
            // c31
            // 
            this.c31.Caption = "31";
            this.c31.FieldName = "Date31";
            this.c31.Name = "c31";
            this.c31.OptionsColumn.AllowEdit = false;
            this.c31.Visible = true;
            this.c31.VisibleIndex = 31;
            // 
            // cTotal
            // 
            this.cTotal.Caption = "SL";
            this.cTotal.FieldName = "TotalCustomer";
            this.cTotal.Name = "cTotal";
            this.cTotal.OptionsColumn.AllowEdit = false;
            this.cTotal.Visible = true;
            this.cTotal.VisibleIndex = 32;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPrint, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.39706F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.60294F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 566);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.03822F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.96178F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 568F));
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtpCheckPoint, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1022, 53);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(323, 22);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpCheckPoint
            // 
            this.dtpCheckPoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpCheckPoint.EditValue = null;
            this.dtpCheckPoint.Location = new System.Drawing.Point(134, 26);
            this.dtpCheckPoint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpCheckPoint.Name = "dtpCheckPoint";
            this.dtpCheckPoint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpCheckPoint.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpCheckPoint.Size = new System.Drawing.Size(178, 20);
            this.dtpCheckPoint.TabIndex = 3;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(930, 536);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(6, 3, 12, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 26);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmTsk_StatusInMonth_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 566);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTsk_StatusInMonth_Room";
            this.Text = "Hiệu suất phòng trong tháng";
            this.Load += new System.EventHandler(this.frmTsk_StatusInMonth_Room_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpCheckPoint.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCheckPoint.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn c1;
        private DevExpress.XtraGrid.Columns.GridColumn c2;
        private DevExpress.XtraGrid.Columns.GridColumn c3;
        private DevExpress.XtraGrid.Columns.GridColumn c4;
        private DevExpress.XtraGrid.Columns.GridColumn c5;
        private DevExpress.XtraGrid.Columns.GridColumn c6;
        private DevExpress.XtraGrid.Columns.GridColumn c7;
        private DevExpress.XtraGrid.Columns.GridColumn c8;
        private DevExpress.XtraGrid.Columns.GridColumn c9;
        private DevExpress.XtraGrid.Columns.GridColumn c10;
        private DevExpress.XtraGrid.Columns.GridColumn c11;
        private DevExpress.XtraGrid.Columns.GridColumn c12;
        private DevExpress.XtraGrid.Columns.GridColumn c13;
        private DevExpress.XtraGrid.Columns.GridColumn c14;
        private DevExpress.XtraGrid.Columns.GridColumn c15;
        private DevExpress.XtraGrid.Columns.GridColumn c16;
        private DevExpress.XtraGrid.Columns.GridColumn c17;
        private DevExpress.XtraGrid.Columns.GridColumn c18;
        private DevExpress.XtraGrid.Columns.GridColumn c19;
        private DevExpress.XtraGrid.Columns.GridColumn c20;
        private DevExpress.XtraGrid.Columns.GridColumn c21;
        private DevExpress.XtraGrid.Columns.GridColumn c22;
        private DevExpress.XtraGrid.Columns.GridColumn c23;
        private DevExpress.XtraGrid.Columns.GridColumn c24;
        private DevExpress.XtraGrid.Columns.GridColumn c25;
        private DevExpress.XtraGrid.Columns.GridColumn c26;
        private DevExpress.XtraGrid.Columns.GridColumn c27;
        private DevExpress.XtraGrid.Columns.GridColumn c28;
        private DevExpress.XtraGrid.Columns.GridColumn c29;
        private DevExpress.XtraGrid.Columns.GridColumn c30;
        private DevExpress.XtraGrid.Columns.GridColumn c31;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.DateEdit dtpCheckPoint;
        private DevExpress.XtraGrid.Columns.GridColumn cRoom;
        private DevExpress.XtraGrid.Columns.GridColumn cTotal;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
    }
}
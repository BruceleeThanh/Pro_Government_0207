namespace RoomManager
{
    partial class frmIns_CheckPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIns_CheckPoint));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tetFrom = new DevExpress.XtraEditors.TimeEdit();
            this.tetTo = new DevExpress.XtraEditors.TimeEdit();
            this.cbbAddTime = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbbDisable = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbAddTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbDisable.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(322, 446);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.38012F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.61988F));
            this.tableLayoutPanel4.Controls.Add(this.btnAdd, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 401);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(322, 45);
            this.tableLayoutPanel4.TabIndex = 14;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(124, 5);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 34);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Cập nhật";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelControl7, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.tetFrom, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tetTo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbbAddTime, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbbType, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbbStatus, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cbbDisable, 1, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 35);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(316, 362);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(11, 21);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(11, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(19, 17);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Từ";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(11, 81);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(11, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 17);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Đến";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(11, 141);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(11, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 17);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "AddTime";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(11, 201);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(11, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 17);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Loại";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(11, 261);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(11, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 17);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Trạng Thái";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(11, 322);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(11, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 17);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Khóa";
            // 
            // tetFrom
            // 
            this.tetFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tetFrom.EditValue = new System.DateTime(2014, 2, 18, 0, 0, 0, 0);
            this.tetFrom.Location = new System.Drawing.Point(104, 18);
            this.tetFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tetFrom.Name = "tetFrom";
            this.tetFrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.tetFrom.Properties.Appearance.Options.UseFont = true;
            this.tetFrom.Properties.Appearance.Options.UseTextOptions = true;
            this.tetFrom.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tetFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tetFrom.Size = new System.Drawing.Size(202, 24);
            this.tetFrom.TabIndex = 3;
            // 
            // tetTo
            // 
            this.tetTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tetTo.EditValue = new System.DateTime(2014, 2, 18, 0, 0, 0, 0);
            this.tetTo.Location = new System.Drawing.Point(104, 78);
            this.tetTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tetTo.Name = "tetTo";
            this.tetTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.tetTo.Properties.Appearance.Options.UseFont = true;
            this.tetTo.Properties.Appearance.Options.UseTextOptions = true;
            this.tetTo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tetTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tetTo.Size = new System.Drawing.Size(202, 24);
            this.tetTo.TabIndex = 5;
            // 
            // cbbAddTime
            // 
            this.cbbAddTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbAddTime.EditValue = "---Chọn Lựa---";
            this.cbbAddTime.Location = new System.Drawing.Point(104, 138);
            this.cbbAddTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbAddTime.Name = "cbbAddTime";
            this.cbbAddTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.cbbAddTime.Properties.Appearance.Options.UseFont = true;
            this.cbbAddTime.Properties.Appearance.Options.UseTextOptions = true;
            this.cbbAddTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbbAddTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbAddTime.Properties.Items.AddRange(new object[] {
            "Một ngày",
            "Nửa ngày"});
            this.cbbAddTime.Size = new System.Drawing.Size(202, 24);
            this.cbbAddTime.TabIndex = 7;
            // 
            // cbbType
            // 
            this.cbbType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbType.EditValue = "---Chọn Lựa---";
            this.cbbType.Location = new System.Drawing.Point(104, 198);
            this.cbbType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbType.Name = "cbbType";
            this.cbbType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.cbbType.Properties.Appearance.Options.UseFont = true;
            this.cbbType.Properties.Appearance.Options.UseTextOptions = true;
            this.cbbType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbType.Properties.Items.AddRange(new object[] {
            "Check In Sớm",
            "Check Out Muộn"});
            this.cbbType.Size = new System.Drawing.Size(202, 24);
            this.cbbType.TabIndex = 9;
            // 
            // cbbStatus
            // 
            this.cbbStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbStatus.EditValue = "1";
            this.cbbStatus.Location = new System.Drawing.Point(104, 258);
            this.cbbStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.cbbStatus.Properties.Appearance.Options.UseFont = true;
            this.cbbStatus.Properties.Appearance.Options.UseTextOptions = true;
            this.cbbStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbStatus.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbbStatus.Size = new System.Drawing.Size(202, 24);
            this.cbbStatus.TabIndex = 11;
            // 
            // cbbDisable
            // 
            this.cbbDisable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbDisable.EditValue = "False";
            this.cbbDisable.Location = new System.Drawing.Point(104, 319);
            this.cbbDisable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbDisable.Name = "cbbDisable";
            this.cbbDisable.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.cbbDisable.Properties.Appearance.Options.UseFont = true;
            this.cbbDisable.Properties.Appearance.Options.UseTextOptions = true;
            this.cbbDisable.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbbDisable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbDisable.Properties.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbbDisable.Size = new System.Drawing.Size(202, 24);
            this.cbbDisable.TabIndex = 13;
            // 
            // frmIns_CheckPoint
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 446);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIns_CheckPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Check Point";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbAddTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbDisable.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TimeEdit tetFrom;
        private DevExpress.XtraEditors.TimeEdit tetTo;
        private DevExpress.XtraEditors.ComboBoxEdit cbbAddTime;
        private DevExpress.XtraEditors.ComboBoxEdit cbbType;
        private DevExpress.XtraEditors.ComboBoxEdit cbbStatus;
        private DevExpress.XtraEditors.ComboBoxEdit cbbDisable;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;

    }
}
namespace RoomManager
{
    partial class frmIns_Guest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIns_Guest));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sbCreate = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lueNationality = new DevExpress.XtraEditors.LookUpEdit();
            this.cbbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtInfo = new DevExpress.XtraEditors.MemoEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNationality.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.sbCreate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(313, 281);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // sbCreate
            // 
            this.sbCreate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sbCreate.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCreate.Appearance.Options.UseFont = true;
            this.sbCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbCreate.Image = ((System.Drawing.Image)(resources.GetObject("sbCreate.Image")));
            this.sbCreate.Location = new System.Drawing.Point(202, 250);
            this.sbCreate.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.sbCreate.Name = "sbCreate";
            this.sbCreate.Size = new System.Drawing.Size(101, 25);
            this.sbCreate.TabIndex = 10;
            this.sbCreate.Text = "Cập nhật";
            this.sbCreate.Click += new System.EventHandler(this.sbCreate_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.29316F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.70684F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lueNationality, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbbType, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtInfo, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(307, 238);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(12, 139);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 17);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Loại";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(12, 80);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 17);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Quốc tịch";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 21);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tên";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(12, 199);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 16);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Thông tin";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.Location = new System.Drawing.Point(102, 19);
            this.txtName.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtName.Size = new System.Drawing.Size(202, 20);
            this.txtName.TabIndex = 3;
            // 
            // lueNationality
            // 
            this.lueNationality.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lueNationality.Location = new System.Drawing.Point(102, 78);
            this.lueNationality.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.lueNationality.Name = "lueNationality";
            this.lueNationality.Properties.Appearance.Options.UseTextOptions = true;
            this.lueNationality.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lueNationality.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNationality.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Quốc gia")});
            this.lueNationality.Properties.NullText = "";
            this.lueNationality.Size = new System.Drawing.Size(202, 20);
            this.lueNationality.TabIndex = 5;
            // 
            // cbbType
            // 
            this.cbbType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbType.EditValue = "1";
            this.cbbType.Location = new System.Drawing.Point(102, 137);
            this.cbbType.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cbbType.Name = "cbbType";
            this.cbbType.Properties.Appearance.Options.UseTextOptions = true;
            this.cbbType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbType.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbbType.Size = new System.Drawing.Size(202, 20);
            this.cbbType.TabIndex = 7;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(102, 180);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(202, 55);
            this.txtInfo.TabIndex = 9;
            this.txtInfo.UseOptimizedRendering = true;
            // 
            // frmIns_Guest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 281);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIns_Guest";
            this.Text = "Thêm mới khách mời";
            this.Load += new System.EventHandler(this.frmIns_Guest_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNationality.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton sbCreate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LookUpEdit lueNationality;
        private DevExpress.XtraEditors.ComboBoxEdit cbbType;
        private DevExpress.XtraEditors.MemoEdit txtInfo;
    }
}
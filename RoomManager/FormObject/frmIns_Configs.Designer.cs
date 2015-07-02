namespace RoomManager
{
    partial class frmIns_Configs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIns_Configs));
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtValue = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccessKey = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboGroup = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccessKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGroup.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl16
            // 
            this.labelControl16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Location = new System.Drawing.Point(20, 114);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl16.Size = new System.Drawing.Size(81, 17);
            this.labelControl16.TabIndex = 6;
            this.labelControl16.Text = "Trạng thái";
            // 
            // cboStatus
            // 
            this.cboStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboStatus.EditValue = "--- Chọn lựa ---";
            this.cboStatus.Location = new System.Drawing.Point(115, 112);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Properties.Appearance.Options.UseTextOptions = true;
            this.cboStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStatus.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cboStatus.Size = new System.Drawing.Size(185, 20);
            this.cboStatus.TabIndex = 7;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(20, 163);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelControl8.Size = new System.Drawing.Size(43, 17);
            this.labelControl8.TabIndex = 8;
            this.labelControl8.Text = "Loại";
            // 
            // cboType
            // 
            this.cboType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboType.EditValue = "--- Chọn  lựa---";
            this.cboType.Location = new System.Drawing.Point(115, 161);
            this.cboType.Name = "cboType";
            this.cboType.Properties.Appearance.Options.UseTextOptions = true;
            this.cboType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboType.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cboType.Size = new System.Drawing.Size(185, 20);
            this.cboType.TabIndex = 9;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtValue.Location = new System.Drawing.Point(115, 63);
            this.txtValue.Name = "txtValue";
            this.txtValue.Properties.MaxLength = 200;
            this.txtValue.Properties.NullValuePrompt = "Nhập tối đa 200 ký tự.";
            this.txtValue.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtValue.Size = new System.Drawing.Size(185, 20);
            this.txtValue.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.637982F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.18868F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.46541F));
            this.tableLayoutPanel4.Controls.Add(this.labelControl13, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelControl16, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.cboStatus, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelControl8, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.cboType, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtValue, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelControl1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtAccessKey, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelControl2, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.cboGroup, 2, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(318, 246);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Location = new System.Drawing.Point(20, 65);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelControl13.Size = new System.Drawing.Size(55, 17);
            this.labelControl13.TabIndex = 4;
            this.labelControl13.Text = "Giá trị";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(20, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(80, 16);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "AccessKey";
            // 
            // txtAccessKey
            // 
            this.txtAccessKey.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccessKey.Location = new System.Drawing.Point(115, 14);
            this.txtAccessKey.Name = "txtAccessKey";
            this.txtAccessKey.Properties.MaxLength = 100;
            this.txtAccessKey.Properties.NullValuePrompt = "Nhập tối đa 100 ký tự.";
            this.txtAccessKey.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtAccessKey.Size = new System.Drawing.Size(185, 20);
            this.txtAccessKey.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(20, 213);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelControl2.Size = new System.Drawing.Size(50, 16);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Nhóm";
            // 
            // cboGroup
            // 
            this.cboGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboGroup.EditValue = "--- Chọn  lựa---";
            this.cboGroup.Location = new System.Drawing.Point(115, 211);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Properties.Appearance.Options.UseTextOptions = true;
            this.cboGroup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGroup.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cboGroup.Size = new System.Drawing.Size(185, 20);
            this.cboGroup.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(324, 312);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.03704F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.96296F));
            this.tableLayoutPanel3.Controls.Add(this.btnAddNew, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 273);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(324, 39);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.Appearance.Options.UseFont = true;
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(126, 5);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(110, 28);
            this.btnAddNew.TabIndex = 13;
            this.btnAddNew.Text = "Cập nhật";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmIns_Configs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 312);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIns_Configs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mới Config";
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccessKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGroup.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private DevExpress.XtraEditors.TextEdit txtValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAccessKey;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
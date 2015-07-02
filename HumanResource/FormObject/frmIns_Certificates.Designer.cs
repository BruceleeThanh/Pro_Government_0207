namespace HumanResource
{
    partial class frmIns_Certificates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIns_Certificates));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCertificate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtOrganization = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lueCertificateTypes = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCertificate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrganization.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCertificateTypes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 158);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.90476F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.09524F));
            this.tableLayoutPanel5.Controls.Add(this.btnAddNew, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 126);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(357, 32);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.Appearance.Options.UseFont = true;
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(227, 3);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(90, 26);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Thêm mới";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.18519F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCertificate, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtOrganization, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lueCertificateTypes, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 14);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(354, 109);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(22, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelControl2.Size = new System.Drawing.Size(102, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Chuyên nghành";
            // 
            // txtCertificate
            // 
            this.txtCertificate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCertificate.Location = new System.Drawing.Point(134, 8);
            this.txtCertificate.Name = "txtCertificate";
            this.txtCertificate.Properties.MaxLength = 50;
            this.txtCertificate.Properties.NullValuePrompt = "Nhấp tối đa 50 ký tự.";
            this.txtCertificate.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtCertificate.Size = new System.Drawing.Size(196, 20);
            this.txtCertificate.TabIndex = 16;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(22, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelControl4.Size = new System.Drawing.Size(55, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Nơi cấp";
            // 
            // txtOrganization
            // 
            this.txtOrganization.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOrganization.Location = new System.Drawing.Point(134, 44);
            this.txtOrganization.Name = "txtOrganization";
            this.txtOrganization.Properties.MaxLength = 50;
            this.txtOrganization.Properties.NullValuePrompt = "Nhập tối đa 50 ký tự.";
            this.txtOrganization.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtOrganization.Size = new System.Drawing.Size(196, 20);
            this.txtOrganization.TabIndex = 17;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(22, 84);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Loại";
            // 
            // lueCertificateTypes
            // 
            this.lueCertificateTypes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lueCertificateTypes.Location = new System.Drawing.Point(134, 80);
            this.lueCertificateTypes.Name = "lueCertificateTypes";
            this.lueCertificateTypes.Properties.Appearance.Options.UseTextOptions = true;
            this.lueCertificateTypes.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lueCertificateTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCertificateTypes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lueCertificateTypes.Properties.NullText = "Chọn lựa";
            this.lueCertificateTypes.Size = new System.Drawing.Size(196, 20);
            this.lueCertificateTypes.TabIndex = 18;
            // 
            // frmIns_Certificates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 158);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIns_Certificates";
            this.Text = "Thêm bằng cấp/ chứng chỉ";
            this.Load += new System.EventHandler(this.frmIns_Certificates_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCertificate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrganization.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCertificateTypes.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCertificate;
        private DevExpress.XtraEditors.TextEdit txtOrganization;
        private DevExpress.XtraEditors.LookUpEdit lueCertificateTypes;
    }
}
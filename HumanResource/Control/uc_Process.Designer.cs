namespace HumanResource
{
    partial class uc_Process
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Step4 = new uc_ProcessItem();
            this.Step3 = new uc_ProcessItem();
            this.Step2 = new uc_ProcessItem();
            this.Step1 = new uc_ProcessItem();
            this.Step5 = new uc_ProcessItem();
            this.Step6 = new uc_ProcessItem();
            this.SuspendLayout();
            // 
            // Step4
            // 
            this.Step4.Location = new System.Drawing.Point(365, 224);
            this.Step4.Name = "Step4";
            this.Step4.Size = new System.Drawing.Size(169, 184);
            this.Step4.TabIndex = 3;
            // 
            // Step3
            // 
            this.Step3.Location = new System.Drawing.Point(365, 34);
            this.Step3.Name = "Step3";
            this.Step3.Size = new System.Drawing.Size(169, 184);
            this.Step3.TabIndex = 2;
            // 
            // Step2
            // 
            this.Step2.Location = new System.Drawing.Point(190, 130);
            this.Step2.Name = "Step2";
            this.Step2.Size = new System.Drawing.Size(169, 184);
            this.Step2.TabIndex = 1;
            // 
            // Step1
            // 
            this.Step1.Location = new System.Drawing.Point(25, 130);
            this.Step1.Name = "Step1";
            this.Step1.Size = new System.Drawing.Size(169, 184);
            this.Step1.TabIndex = 0;
            // 
            // Step5
            // 
            this.Step5.Location = new System.Drawing.Point(540, 130);
            this.Step5.Name = "Step5";
            this.Step5.Size = new System.Drawing.Size(169, 184);
            this.Step5.TabIndex = 4;
            // 
            // Step6
            // 
            this.Step6.Location = new System.Drawing.Point(706, 130);
            this.Step6.Name = "Step6";
            this.Step6.Size = new System.Drawing.Size(169, 184);
            this.Step6.TabIndex = 5;
            // 
            // uc_Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Step6);
            this.Controls.Add(this.Step5);
            this.Controls.Add(this.Step4);
            this.Controls.Add(this.Step3);
            this.Controls.Add(this.Step2);
            this.Controls.Add(this.Step1);
            this.Name = "uc_Process";
            this.Size = new System.Drawing.Size(1003, 507);
            this.Load += new System.EventHandler(this.uc_Process_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private uc_ProcessItem Step1;
        private uc_ProcessItem Step2;
        private uc_ProcessItem Step3;
        private uc_ProcessItem Step4;
        private uc_ProcessItem Step5;
        private uc_ProcessItem Step6;
    }
}

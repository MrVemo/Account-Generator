namespace Account_Gen
{
    partial class frmUpdateSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateSystem));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCheckUpdates = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelPerc = new DevExpress.XtraEditors.LabelControl();
            this.labelSpeed = new DevExpress.XtraEditors.LabelControl();
            this.labelDownloaded = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(444, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // btnCheckUpdates
            // 
            this.btnCheckUpdates.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckUpdates.Image")));
            this.btnCheckUpdates.Location = new System.Drawing.Point(0, 114);
            this.btnCheckUpdates.Name = "btnCheckUpdates";
            this.btnCheckUpdates.Size = new System.Drawing.Size(444, 23);
            this.btnCheckUpdates.TabIndex = 1;
            this.btnCheckUpdates.Text = "Auf Updates überprüfen";
            this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(93, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(135, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Runterladegeschwindigkeit :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(111, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(117, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Herruntergeladen (MB) :";
            // 
            // labelPerc
            // 
            this.labelPerc.Location = new System.Drawing.Point(175, 29);
            this.labelPerc.Name = "labelPerc";
            this.labelPerc.Size = new System.Drawing.Size(0, 13);
            this.labelPerc.TabIndex = 4;
            // 
            // labelSpeed
            // 
            this.labelSpeed.Location = new System.Drawing.Point(243, 59);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(0, 13);
            this.labelSpeed.TabIndex = 5;
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.Location = new System.Drawing.Point(243, 78);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(0, 13);
            this.labelDownloaded.TabIndex = 6;
            // 
            // frmUpdateSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 141);
            this.Controls.Add(this.labelDownloaded);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelPerc);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCheckUpdates);
            this.Controls.Add(this.progressBar1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(460, 180);
            this.MinimumSize = new System.Drawing.Size(460, 180);
            this.Name = "frmUpdateSystem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Generator - Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private DevExpress.XtraEditors.SimpleButton btnCheckUpdates;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelPerc;
        private DevExpress.XtraEditors.LabelControl labelSpeed;
        private DevExpress.XtraEditors.LabelControl labelDownloaded;
    }
}
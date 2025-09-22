namespace RadwagE
{
    partial class frmReportActionChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportActionChoice));
            this.lblQuestion = new DevExpress.XtraEditors.LabelControl();
            this.btnYes = new DevExpress.XtraEditors.SimpleButton();
            this.btnNo = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblQuestion.Appearance.Options.UseFont = true;
            this.lblQuestion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblQuestion.Location = new System.Drawing.Point(69, 12);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(329, 70);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Czy chcesz wyświetlić podgląd raportu przed wydrukiem?";
            // 
            // btnYes
            // 
            this.btnYes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYes.ImageOptions.Image")));
            this.btnYes.Location = new System.Drawing.Point(12, 88);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(100, 52);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "TAK";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.ImageOptions.Image")));
            this.btnNo.Location = new System.Drawing.Point(136, 88);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(110, 52);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "NIE";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(278, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 52);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "ANULUJ";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(12, 21);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(51, 48);
            this.pictureEdit1.TabIndex = 4;
            // 
            // frmReportActionChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 157);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportActionChoice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wybór raportu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblQuestion;
        private DevExpress.XtraEditors.SimpleButton btnYes;
        private DevExpress.XtraEditors.SimpleButton btnNo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}
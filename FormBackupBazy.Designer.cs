namespace RadwagE
{
    partial class FormBackupBazy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBackupBazy));
            this.btnWykonajKopie = new DevExpress.XtraEditors.SimpleButton();
            this.pbPostep = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.lbKopieZapasowe = new DevExpress.XtraEditors.ListBoxControl();
            this.btnPrzywrocKopie = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbPostep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKopieZapasowe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWykonajKopie
            // 
            this.btnWykonajKopie.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWykonajKopie.ImageOptions.Image")));
            this.btnWykonajKopie.Location = new System.Drawing.Point(43, 61);
            this.btnWykonajKopie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWykonajKopie.Name = "btnWykonajKopie";
            this.btnWykonajKopie.Size = new System.Drawing.Size(134, 58);
            this.btnWykonajKopie.TabIndex = 0;
            this.btnWykonajKopie.Text = "Wykonaj kopię";
            this.btnWykonajKopie.Click += new System.EventHandler(this.btnWykonajKopie_Click);
            // 
            // pbPostep
            // 
            this.pbPostep.Location = new System.Drawing.Point(43, 208);
            this.pbPostep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbPostep.Name = "pbPostep";
            this.pbPostep.Size = new System.Drawing.Size(508, 29);
            this.pbPostep.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseForeColor = true;
            this.lblStatus.Location = new System.Drawing.Point(43, 288);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(108, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "labelControl1";
            // 
            // lbKopieZapasowe
            // 
            this.lbKopieZapasowe.Location = new System.Drawing.Point(338, 61);
            this.lbKopieZapasowe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbKopieZapasowe.Name = "lbKopieZapasowe";
            this.lbKopieZapasowe.Size = new System.Drawing.Size(213, 108);
            this.lbKopieZapasowe.TabIndex = 3;
            // 
            // btnPrzywrocKopie
            // 
            this.btnPrzywrocKopie.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrzywrocKopie.ImageOptions.Image")));
            this.btnPrzywrocKopie.Location = new System.Drawing.Point(183, 61);
            this.btnPrzywrocKopie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrzywrocKopie.Name = "btnPrzywrocKopie";
            this.btnPrzywrocKopie.Size = new System.Drawing.Size(136, 58);
            this.btnPrzywrocKopie.TabIndex = 4;
            this.btnPrzywrocKopie.Text = "Przywróć z kopii";
            this.btnPrzywrocKopie.Click += new System.EventHandler(this.btnPrzywrocKopie_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(448, 319);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 55);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Zamknij";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormBackupBazy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 406);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrzywrocKopie);
            this.Controls.Add(this.lbKopieZapasowe);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbPostep);
            this.Controls.Add(this.btnWykonajKopie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBackupBazy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kopia Bazy danych";
            this.Load += new System.EventHandler(this.FormBackupBazy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPostep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKopieZapasowe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnWykonajKopie;
        private DevExpress.XtraEditors.ProgressBarControl pbPostep;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.ListBoxControl lbKopieZapasowe;
        private DevExpress.XtraEditors.SimpleButton btnPrzywrocKopie;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
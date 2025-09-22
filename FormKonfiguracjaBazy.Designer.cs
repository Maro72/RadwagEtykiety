namespace RadwagE
{
    partial class FormKonfiguracjaBazy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKonfiguracjaBazy));
            this.txtServer = new DevExpress.XtraEditors.TextEdit();
            this.rgAutentykacja = new DevExpress.XtraEditors.RadioGroup();
            this.txtUzytkownik = new DevExpress.XtraEditors.TextEdit();
            this.txtHaslo = new DevExpress.XtraEditors.TextEdit();
            this.txtBazaDanych = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTestuj = new DevExpress.XtraEditors.SimpleButton();
            this.btnZapisz = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnuluj = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgAutentykacja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUzytkownik.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaslo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBazaDanych.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(114, 28);
            this.txtServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtServer.Name = "txtServer";
            this.txtServer.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtServer.Properties.ContextImageOptions.Image")));
            this.txtServer.Size = new System.Drawing.Size(179, 36);
            this.txtServer.TabIndex = 0;
            // 
            // rgAutentykacja
            // 
            this.rgAutentykacja.Location = new System.Drawing.Point(326, 53);
            this.rgAutentykacja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rgAutentykacja.Name = "rgAutentykacja";
            this.rgAutentykacja.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Autentykacja Windows"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Autentykacja SQL Server")});
            this.rgAutentykacja.Size = new System.Drawing.Size(159, 91);
            this.rgAutentykacja.TabIndex = 1;
            // 
            // txtUzytkownik
            // 
            this.txtUzytkownik.Location = new System.Drawing.Point(114, 88);
            this.txtUzytkownik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUzytkownik.Name = "txtUzytkownik";
            this.txtUzytkownik.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtUzytkownik.Properties.ContextImageOptions.Image")));
            this.txtUzytkownik.Size = new System.Drawing.Size(179, 36);
            this.txtUzytkownik.TabIndex = 2;
            // 
            // txtHaslo
            // 
            this.txtHaslo.Location = new System.Drawing.Point(114, 143);
            this.txtHaslo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHaslo.Name = "txtHaslo";
            this.txtHaslo.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtHaslo.Properties.ContextImageOptions.Image")));
            this.txtHaslo.Properties.UseSystemPasswordChar = true;
            this.txtHaslo.Size = new System.Drawing.Size(179, 36);
            this.txtHaslo.TabIndex = 3;
            // 
            // txtBazaDanych
            // 
            this.txtBazaDanych.Location = new System.Drawing.Point(114, 191);
            this.txtBazaDanych.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBazaDanych.Name = "txtBazaDanych";
            this.txtBazaDanych.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtBazaDanych.Properties.ContextImageOptions.Image")));
            this.txtBazaDanych.Size = new System.Drawing.Size(179, 36);
            this.txtBazaDanych.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(57, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(49, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hasło";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(7, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Baza danych";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(322, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Autoryzacja";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(43, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Server";
            // 
            // btnTestuj
            // 
            this.btnTestuj.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTestuj.ImageOptions.Image")));
            this.btnTestuj.Location = new System.Drawing.Point(10, 269);
            this.btnTestuj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTestuj.Name = "btnTestuj";
            this.btnTestuj.Size = new System.Drawing.Size(105, 33);
            this.btnTestuj.TabIndex = 10;
            this.btnTestuj.Text = "Test";
            this.btnTestuj.Click += new System.EventHandler(this.btnTestuj_Click);
            // 
            // btnZapisz
            // 
            this.btnZapisz.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnZapisz.ImageOptions.Image")));
            this.btnZapisz.Location = new System.Drawing.Point(142, 269);
            this.btnZapisz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(117, 33);
            this.btnZapisz.TabIndex = 11;
            this.btnZapisz.Text = "Zapisz";
            this.btnZapisz.Click += new System.EventHandler(this.btnZapisz_Click);
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAnuluj.ImageOptions.Image")));
            this.btnAnuluj.Location = new System.Drawing.Point(286, 269);
            this.btnAnuluj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnuluj.Name = "btnAnuluj";
            this.btnAnuluj.Size = new System.Drawing.Size(112, 33);
            this.btnAnuluj.TabIndex = 12;
            this.btnAnuluj.Text = "Anuluj";
            this.btnAnuluj.Click += new System.EventHandler(this.btnAnuluj_Click);
            // 
            // FormKonfiguracjaBazy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 336);
            this.Controls.Add(this.btnAnuluj);
            this.Controls.Add(this.btnZapisz);
            this.Controls.Add(this.btnTestuj);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBazaDanych);
            this.Controls.Add(this.txtHaslo);
            this.Controls.Add(this.txtUzytkownik);
            this.Controls.Add(this.rgAutentykacja);
            this.Controls.Add(this.txtServer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormKonfiguracjaBazy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfiguracja bazy danych";
            this.Load += new System.EventHandler(this.FormKonfiguracjaBazy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgAutentykacja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUzytkownik.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaslo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBazaDanych.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtServer;
        private DevExpress.XtraEditors.RadioGroup rgAutentykacja;
        private DevExpress.XtraEditors.TextEdit txtUzytkownik;
        private DevExpress.XtraEditors.TextEdit txtHaslo;
        private DevExpress.XtraEditors.TextEdit txtBazaDanych;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnTestuj;
        private DevExpress.XtraEditors.SimpleButton btnZapisz;
        private DevExpress.XtraEditors.SimpleButton btnAnuluj;
    }
}
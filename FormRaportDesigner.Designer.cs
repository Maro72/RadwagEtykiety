namespace RadwagE
{
    partial class FormRaportDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRaportDesigner));
            this.cbRaportyDoEdycji = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnProjektujRaport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cbRaportyDoEdycji.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbRaportyDoEdycji
            // 
            this.cbRaportyDoEdycji.Location = new System.Drawing.Point(34, 55);
            this.cbRaportyDoEdycji.Name = "cbRaportyDoEdycji";
            this.cbRaportyDoEdycji.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbRaportyDoEdycji.Properties.Appearance.Options.UseFont = true;
            this.cbRaportyDoEdycji.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbRaportyDoEdycji.Size = new System.Drawing.Size(204, 22);
            this.cbRaportyDoEdycji.TabIndex = 0;
            // 
            // btnProjektujRaport
            // 
            this.btnProjektujRaport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnProjektujRaport.ImageOptions.SvgImage")));
            this.btnProjektujRaport.Location = new System.Drawing.Point(34, 92);
            this.btnProjektujRaport.Name = "btnProjektujRaport";
            this.btnProjektujRaport.Size = new System.Drawing.Size(204, 34);
            this.btnProjektujRaport.TabIndex = 1;
            this.btnProjektujRaport.Text = "Edytuj";
            this.btnProjektujRaport.Click += new System.EventHandler(this.btnProjektujRaport_Click_1);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(34, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(104, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Wybierz raport";
            // 
            // FormRaportDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 172);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnProjektujRaport);
            this.Controls.Add(this.cbRaportyDoEdycji);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRaportDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edytor raportów";
            this.Load += new System.EventHandler(this.FormRaportDesigner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbRaportyDoEdycji.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbRaportyDoEdycji;
        private DevExpress.XtraEditors.SimpleButton btnProjektujRaport;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
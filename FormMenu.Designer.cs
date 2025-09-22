namespace RadwagE
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.cbRok = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cbMiesiac = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnAutoneum = new DevExpress.XtraBars.BarButtonItem();
            this.btnCzechy = new DevExpress.XtraBars.BarButtonItem();
            this.btnAutoneum12 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSurowiec = new DevExpress.XtraBars.BarButtonItem();
            this.btnKonfiguracja = new DevExpress.XtraBars.BarButtonItem();
            this.btnKopia = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditReport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.beiBalanceNameFilter = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.beiCodeSeriesFilter = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnExcel = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AllowMdiChildButtons = false;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.cbRok,
            this.cbMiesiac,
            this.barButtonItem1,
            this.btnAutoneum,
            this.btnCzechy,
            this.btnAutoneum12,
            this.btnSurowiec,
            this.btnKonfiguracja,
            this.btnKopia,
            this.btnEditReport,
            this.barButtonItem2,
            this.beiBalanceNameFilter,
            this.beiCodeSeriesFilter,
            this.btnExcel});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 15;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsExpandCollapseMenu.ShowQuickAccessToolbarItem = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2,
            this.repositoryItemComboBox3,
            this.repositoryItemComboBox4});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(1025, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // cbRok
            // 
            this.cbRok.Caption = "Rok     ";
            this.cbRok.Edit = this.repositoryItemComboBox1;
            this.cbRok.EditWidth = 100;
            this.cbRok.Id = 1;
            this.cbRok.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("cbRok.ImageOptions.SvgImage")));
            this.cbRok.Name = "cbRok";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemComboBox1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025",
            "2026"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // cbMiesiac
            // 
            this.cbMiesiac.Caption = "Miesiąc";
            this.cbMiesiac.Edit = this.repositoryItemComboBox2;
            this.cbMiesiac.EditWidth = 100;
            this.cbMiesiac.Id = 2;
            this.cbMiesiac.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("cbMiesiac.ImageOptions.SvgImage")));
            this.cbMiesiac.Name = "cbMiesiac";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemComboBox2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemComboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Pobierz";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnAutoneum
            // 
            this.btnAutoneum.Caption = "Autoneum Antracyt";
            this.btnAutoneum.Id = 4;
            this.btnAutoneum.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAutoneum.ImageOptions.SvgImage")));
            this.btnAutoneum.Name = "btnAutoneum";
            this.btnAutoneum.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAutoneum_ItemClick);
            // 
            // btnCzechy
            // 
            this.btnCzechy.Caption = "Autoneum Czechy";
            this.btnCzechy.Id = 5;
            this.btnCzechy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCzechy.ImageOptions.SvgImage")));
            this.btnCzechy.Name = "btnCzechy";
            this.btnCzechy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCzechy_ItemClick);
            // 
            // btnAutoneum12
            // 
            this.btnAutoneum12.Caption = "Autoneunm 12 dtx";
            this.btnAutoneum12.Id = 6;
            this.btnAutoneum12.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAutoneum12.ImageOptions.SvgImage")));
            this.btnAutoneum12.Name = "btnAutoneum12";
            this.btnAutoneum12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAutoneum12_ItemClick);
            // 
            // btnSurowiec
            // 
            this.btnSurowiec.Caption = "Surowiec";
            this.btnSurowiec.Id = 7;
            this.btnSurowiec.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSurowiec.ImageOptions.SvgImage")));
            this.btnSurowiec.Name = "btnSurowiec";
            this.btnSurowiec.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSurowiec_ItemClick);
            // 
            // btnKonfiguracja
            // 
            this.btnKonfiguracja.Caption = "Konfiguracja";
            this.btnKonfiguracja.Id = 8;
            this.btnKonfiguracja.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKonfiguracja.ImageOptions.LargeImage")));
            this.btnKonfiguracja.Name = "btnKonfiguracja";
            this.btnKonfiguracja.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKonfiguracja_ItemClick);
            // 
            // btnKopia
            // 
            this.btnKopia.Caption = "Kopia bazy danych";
            this.btnKopia.Id = 9;
            this.btnKopia.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKopia.ImageOptions.LargeImage")));
            this.btnKopia.Name = "btnKopia";
            this.btnKopia.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKopia_ItemClick);
            // 
            // btnEditReport
            // 
            this.btnEditReport.Caption = "Edytor raportu";
            this.btnEditReport.Id = 10;
            this.btnEditReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEditReport.ImageOptions.LargeImage")));
            this.btnEditReport.Name = "btnEditReport";
            this.btnEditReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditReport_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Drukuj Dostawę";
            this.barButtonItem2.Hint = "Drukuj specyfikacje wazenia dostawy";
            this.barButtonItem2.Id = 11;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // beiBalanceNameFilter
            // 
            this.beiBalanceNameFilter.Caption = "Waga         ";
            this.beiBalanceNameFilter.Edit = this.repositoryItemComboBox3;
            this.beiBalanceNameFilter.EditWidth = 80;
            this.beiBalanceNameFilter.Enabled = false;
            this.beiBalanceNameFilter.Id = 12;
            this.beiBalanceNameFilter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("beiBalanceNameFilter.ImageOptions.SvgImage")));
            this.beiBalanceNameFilter.Name = "beiBalanceNameFilter";
            this.beiBalanceNameFilter.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // beiCodeSeriesFilter
            // 
            this.beiCodeSeriesFilter.Caption = "Nr dostawy";
            this.beiCodeSeriesFilter.Edit = this.repositoryItemComboBox4;
            this.beiCodeSeriesFilter.EditWidth = 80;
            this.beiCodeSeriesFilter.Enabled = false;
            this.beiCodeSeriesFilter.Id = 13;
            this.beiCodeSeriesFilter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("beiCodeSeriesFilter.ImageOptions.SvgImage")));
            this.beiCodeSeriesFilter.Name = "beiCodeSeriesFilter";
            this.beiCodeSeriesFilter.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemComboBox4
            // 
            this.repositoryItemComboBox4.AutoHeight = false;
            this.repositoryItemComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            // 
            // btnExcel
            // 
            this.btnExcel.Caption = "Export do Excela";
            this.btnExcel.Hint = "Exportuj tanele do pliku excel";
            this.btnExcel.Id = 14;
            this.btnExcel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExcel.ImageOptions.SvgImage")));
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcel_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup5,
            this.ribbonPageGroup6});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Radwag";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.cbRok);
            this.ribbonPageGroup1.ItemLinks.Add(this.cbMiesiac);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Ważenia";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAutoneum);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCzechy);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAutoneum12);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSurowiec);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Etykiety";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnExcel);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Raport dostaw";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.beiBalanceNameFilter);
            this.ribbonPageGroup6.ItemLinks.Add(this.beiCodeSeriesFilter);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Filtrowanie";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Administracja";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnKonfiguracja);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnKopia);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Bazy danych";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnEditReport);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Raporty";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 559);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1025, 24);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1025, 401);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsPrint.AllowMultilineHeaders = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 583);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IconOptions.ShowIcon = false;
            this.Name = "FormMenu";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Aplikacja do wydruku etykiet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarEditItem cbRok;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarEditItem cbMiesiac;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnAutoneum;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnCzechy;
        private DevExpress.XtraBars.BarButtonItem btnAutoneum12;
        private DevExpress.XtraBars.BarButtonItem btnSurowiec;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnKonfiguracja;
        private DevExpress.XtraBars.BarButtonItem btnKopia;
        private DevExpress.XtraBars.BarButtonItem btnEditReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarEditItem beiBalanceNameFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private DevExpress.XtraBars.BarEditItem beiCodeSeriesFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnExcel;
    }
}
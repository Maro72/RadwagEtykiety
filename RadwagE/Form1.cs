using DevExpress.XtraReports.UI;
using RadwagE.Klasy;
using RadwagE.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadwagE
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        E2REntities db = new E2REntities();

        public Form1()
        {
            InitializeComponent();
            DataBind();
        }
         public void DataBind()
         {
            // db.RS_V_EW1_WAZENIA.Load();
           // db.RS_V_EW1_WAZENIA.Load();
            

           // gridControl1.DataSource = db.RS_V_EW1_WAZENIA.ToList();
      }
    private void Form1_Load(object sender, EventArgs e)
        {
          //this.gridControl1.DataSource = db.ew1_kontrahenci.ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cbRok.EditValue == null || cbMiesiac.EditValue == null)
            {
                MessageBox.Show("Uzupełnij pola: rok i miesiąc", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbRok.Focus();
                return;
                //  btnArtec.Enabled = false;

            }


            try
            {
                int rok = Convert.ToInt32(cbRok.EditValue);
                int miesiac = Convert.ToInt32(cbMiesiac.EditValue);
                //int miesiacDo = Convert.ToInt32(comboBoxEdit3.EditValue);

               // SplashScreenManager.ShowForm(typeof(frmWaitForm));
                // gridView1.ShowLoadingPanel();
                using (E2REntities db = new E2REntities())

                    gridControl1.DataSource = (from n in db.RS_V_EW1_WAZENIA
                                                   // where n.DATE == dateEdit1.DateTime.Date && n.DATE <= dateEdit2.DateTime.Date
                                                .Where(a => a.DATE.Month >= miesiac && a.DATE.Year == rok)

                                               orderby n.DATE ascending
                                               select new Wazenia
                                               {
                                                   id = n.id,
                                                   Date = n.DATE,
                                                   ARTICLE_NAME = n.ARTICLE_NAME,
                                                   BALANCE_NAME = n.BALANCE_NAME,
                                                   UNIT = n.UNIT,
                                                   OPERATOR = n.OPERATOR,
                                                   CODE_SERIES = n.CODE_SERIES,
                                                   MASS_KG = n.MASS_KG,
                                                   MASSBRUTTO = n.MASSBRUTTO,
                                                   TARE = n.TARE,
                                                   SCODE_ARTICLE = n.SCODE_ARTICLE,
                                                   kod_serii2 = n.kod_serii2,
                                                   archiwalne = n.archiwalne,
                                                   licznik_statystyka = n.licznik_statystyka,
                                                   licznik_wazen = n.licznik_wazen,
                                                   //   DZIEN = n.DZIEN,
                                                   MIESIAC = n.DATE.Month,
                                                   ROK = n.DATE.Year,
                                                   COOPERATOR = n.COOPERATOR

                                               }).ToList();
                //    gridView1.HideLoadingPanel();
               // SplashScreenManager.CloseForm();

            }
            catch
            {
                //  MessageBox.Show("Wprowadź rok i miesiąc", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var k = (Wazenia)gridView1.GetRow(gridView1.FocusedRowHandle);
                Raporty.BorgersCz r = new Raporty.BorgersCz();
                r.DataSource = db.RS_V_EW1_WAZENIA.Where(p => p.id == k.id).ToList();
                r.ShowPreviewDialog();

            }
            catch
            {
                MessageBox.Show("Brak danych do wydruku etykiety !", "Dane etykiety", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

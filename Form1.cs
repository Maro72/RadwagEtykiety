using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using RadwagE.Klasy;
using RadwagE.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadwagE
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {


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
            // Ustawienie informacji o zalogowanym użytkowniku
          //  if (Program.AktualnyUzytkownik != null)
          //  {
          //      bsiZalogowanyUzytkownik.Caption = $"Użytkownik: {Program.AktualnyUzytkownik.NazwaUzytkownika}";
         //   }
          //  else
          //  {
                bsiZalogowanyUzytkownik.Caption = "Użytkownik: Niezalogowany";
          //  }

            // Ustawienie początkowej liczby rekordów
            bsiLiczbaRekordow.Caption = "Wczytano: 0 wierszy";

            // Twój istniejący kod...
           // ZastosujUprawnienia();
            //this.gridControl1.DataSource = db.ew1_kontrahenci.ToList();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {

            if (cbRok.EditValue == null || cbMiesiac.EditValue == null)
            {
                XtraMessageBox.Show("Uzupełnij pola: rok i miesiąc", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbRok.Focus();
                return;
            }

            try
            {
                int rok = Convert.ToInt32(cbRok.EditValue);
                int miesiac = Convert.ToInt32(cbMiesiac.EditValue);

                gridView1.ShowLoadingPanel(); // Pokaż wskaźnik ładowania

                using (var db = new E2REntities())
                {
                    // Użycie asynchronicznego zapytania, aby nie blokować UI
                    var wazenia = await(from n in db.RS_V_EW1_WAZENIA
                                        where n.DATE.Year == rok && n.DATE.Month == miesiac // Poprawiona logika
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
                                            MASS = n.MASS,
                                            MASSBRUTTO = n.MASSBRUTTO,
                                            MASS_KG = n.MASS_KG,
                                            TARE = n.TARE,
                                            SCODE_ARTICLE = n.SCODE_ARTICLE,
                                            kod_serii2 = n.kod_serii2,
                                            archiwalne = n.archiwalne,
                                            licznik_statystyka = n.licznik_statystyka,
                                            licznik_wazen = n.licznik_wazen,
                                            DZIEN = n.DATE.Day,
                                            MIESIAC = n.DATE.Month,
                                            ROK = n.DATE.Year,
                                             COOPERATOR = n.COOPERATOR
                                        }).ToListAsync(); // Asynchroniczne wykonanie zapytania

                    gridControl1.DataSource = wazenia;
                    int liczbaRekordow = wazenia.Count;
                    bsiLiczbaRekordow.Caption = $"Wczytano: {liczbaRekordow} wierszy";
                }
            }

            catch (Exception ex)
            {
                bsiLiczbaRekordow.Caption = "Błąd podczas ładowania danych";
                // Zawsze pokazuj błąd!
                XtraMessageBox.Show("Wystąpił błąd podczas pobierania danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gridView1.HideLoadingPanel(); // Ukryj wskaźnik ładowania, nawet jeśli wystąpił błąd
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Krok 1: Pobierz obiekt z siatki (bez zmian)
                var k = gridView1.GetRow(gridView1.FocusedRowHandle) as Wazenia;

                // Dodatkowa walidacja - upewnij się, że coś zostało zaznaczone
                if (k == null)
                {
                    MessageBox.Show("Nie zaznaczono żadnego wiersza!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Krok 2: Stwórz raport
                Raporty.BorgersCz r = new Raporty.BorgersCz();

                // Krok 3: Ustaw źródło danych na obiekt POBRANY Z SIATKI
                // Zamiast odpytywać bazę, tworzymy listę zawierającą tylko ten jeden obiekt.
                r.DataSource = new List<Wazenia> { k };

                // Krok 4: Drukuj
                r.Print();
            }
            catch (Exception ex) // Zawsze łap konkretny wyjątek!
            {
                MessageBox.Show("Wystąpił błąd podczas generowania wydruku: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                // Krok 1: Pobierz obiekt z siatki (bez zmian)
                var k = gridView1.GetRow(gridView1.FocusedRowHandle) as Wazenia;

                // Dodatkowa walidacja - upewnij się, że coś zostało zaznaczone
                if (k == null)
                {
                    MessageBox.Show("Nie zaznaczono żadnego wiersza!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Krok 2: Stwórz raport
                Raporty.BorgersDE r = new Raporty.BorgersDE();

                // Krok 3: Ustaw źródło danych na obiekt POBRANY Z SIATKI
                // Zamiast odpytywać bazę, tworzymy listę zawierającą tylko ten jeden obiekt.
                r.DataSource = new List<Wazenia> { k };

                // Krok 4: Drukuj
                r.Print();
            }
            catch (Exception ex) // Zawsze łap konkretny wyjątek!
            {
                MessageBox.Show("Wystąpił błąd podczas generowania wydruku: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OtworzOknoWyboruRaportu()
        {
            // Pobierz listę zaznaczonych wierszy z siatki
            var zaznaczoneWiersze = gridView1.GetSelectedRows()
                                             .Select(rowHandle => gridView1.GetRow(rowHandle) as Wazenia)
                                             .Where(w => w != null)
                                             .ToList();

            if (zaznaczoneWiersze.Count == 0)
            {
                XtraMessageBox.Show("Proszę najpierw zaznaczyć co najmniej jeden wiersz w tabeli.", "Brak zaznaczenia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Otwórz formularz wyboru, przekazując mu zaznaczone dane
          //  using (RaportWybor form = new RaportWybor(zaznaczoneWiersze))
         //   {
         //       form.ShowDialog(this);
         //   }
        }
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintReportForSelectedRows<Raporty.BorgersCz>();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintReportForSelectedRows<Raporty.BorgersDE>();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintReportForSelectedRows<Raporty.Borgres12>();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // var selected = gridView1.GetSelectedRows();
            // List<Wazenia> rekordy = new List<Wazenia>();

            ///  foreach (var s in selected)
            //  {
            //     rekordy.Add(gridView1.GetRow(s) as Wazenia);
            // }

            // var ids = rekordy.Select(m => m.id).ToList();

            int i = 0;
            while (i < Int32.Parse(textEdit1.Text))
            {
                using (var r = new Raporty.Artec())
                {
                    //r.DataSource = db.RS_V_EW1_WAZENIA.Where(p => ids.Contains(p.id)).ToList();
                    // r.ShowPreviewDialog();
                    r.Print();
                    i++;
                    // r.ShowPreviewDialog();
                }

            }

        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintReportForSelectedRows<Raporty.Surowiec>();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintReportForSelectedRows<Raporty.BorgersZielone>();
        }

        // metod do wybru wierszy w gridzie i druku
        private void PrintReportForSelectedRows<TReport>() where TReport : XtraReport, new()
        {
            var selectedRows = gridView1.GetSelectedRows()
                                .Select(rowHandle => gridView1.GetRow(rowHandle) as Wazenia)
                                .Where(wazenie => wazenie != null)
                                .ToList();

            if (selectedRows.Count == 0)
            {
                XtraMessageBox.Show("Nie zaznaczono żadnych danych do wydruku!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                XtraReport report = new TReport();

                // === ZMIANA: Użycie Twojej struktury katalogów ===
                string nazwaPliku = typeof(TReport).Name + ".repx";
                string sciezkaFolderuEdycji = Path.Combine(Application.StartupPath, "Raporty", "Raporty_edit");
                string sciezkaPliku = Path.Combine(sciezkaFolderuEdycji, nazwaPliku);

                // Jeśli plik .repx istnieje w folderze 'Raporty_edit', załaduj jego layout.
                if (File.Exists(sciezkaPliku))
                {
                    report.LoadLayout(sciezkaPliku);
                }

                report.DataSource = selectedRows;
                report.Print();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Wystąpił błąd podczas generowania raportu:\n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FormBackupBazy formBackup = new FormBackupBazy())
            {
                formBackup.ShowDialog(this);
            }
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Używamy bloku 'using', aby mieć pewność, że formularz zostanie poprawnie zwolniony z pamięci
            using (FormKonfiguracjaBazy formKonfiguracja = new FormKonfiguracjaBazy())
            {
                // Otwieramy formularz konfiguracyjny jako okno modalne.
                // Oznacza to, że użytkownik nie może wrócić do Form1, dopóki nie zamknie tego okna.
                var result = formKonfiguracja.ShowDialog(this);

                // Sprawdzamy, czy użytkownik kliknął "Zapisz" i czy konfiguracja faktycznie została zapisana.
                // Używamy tutaj flagi 'KonfiguracjaZapisana', którą stworzyliśmy w FormKonfiguracjaBazy.
                if (result == DialogResult.OK && formKonfiguracja.KonfiguracjaZapisana)
                {
                    // Najbezpieczniejszym i najprostszym sposobem na załadowanie nowej konfiguracji
                    // przez wszystkie komponenty aplikacji (w tym Entity Framework) jest jej restart.
                    Application.Restart();
                }
            }
        }

        private void btnOtworzProjektanta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FormRaportDesigner designerForm = new FormRaportDesigner())
            {
                // Otwieramy formularz jako okno modalne, blokując dostęp do Form1.
                designerForm.ShowDialog(this);
            }
        }

        private void btnDrukuj_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OtworzOknoWyboruRaportu();
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Sprawdzamy, czy został naciśnięty PRAWY przycisk myszy
            if (e.Button == MouseButtons.Right)
            {
                // Używamy "HitInfo", aby sprawdzić, co dokładnie zostało kliknięte
                var hitInfo = gridView1.CalcHitInfo(e.Location);

                // Jeśli kliknięcie nastąpiło na wierszu lub komórce...
                if (hitInfo.InRow || hitInfo.InRowCell)
                {
                    // ...pokaż nasze menu kontekstowe w miejscu, gdzie kliknął użytkownik.
                    // Używamy PointToScreen, aby przekonwertować koordynaty lokalne na ekranowe.
                    popupMenuSiatki.ShowPopup(gridControl1.PointToScreen(e.Location));
                }
            }
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OtworzOknoWyboruRaportu();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.MinimizeBox = true;
        }
    }
}
    

    

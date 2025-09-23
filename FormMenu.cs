using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using RadwagE.Klasy;
using RadwagE.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadwagE
{
    public partial class FormMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public FormMenu()
        {
            InitializeComponent();
            beiBalanceNameFilter.Enabled = false;
            beiCodeSeriesFilter.Enabled = false;


        }

        private async void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cbRok.EditValue == null || cbMiesiac.EditValue == null)
            {
                XtraMessageBox.Show("Uzupełnij pola: rok i miesiąc", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  cbRok.Focus();
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
                    var wazenia = await (from n in db.RS_V_EW1_WAZENIA
                                         where n.DATE.Year == rok && n.DATE.Month == miesiac // Poprawiona logika
                                         orderby n.DATE ascending
                                         select new Wazenia
                                         {
                                             id = n.id,
                                             Date = n.DATE,
                                             ARTICLE_NAME = n.ARTICLE_NAME,
                                             BALANCE_NAME = n.BALANCE_NAME,
                                             UNIT = n.UNIT,
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
                                             COOPERATOR = n.COOPERATOR,
                                             OPERATOR = n.OPERATOR,

                                         }).ToListAsync(); // Asynchroniczne wykonanie zapytania

                    gridControl1.DataSource = wazenia;

                    ConfigureGridColumns();

                    int liczbaRekordow = wazenia.Count;
                    barStaticItemRecordCount.Caption = $"Wczytano: {liczbaRekordow} rekordów";
                    gridView1.Columns["ARTICLE_NAME"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.Columns["ARTICLE_NAME"].SummaryItem.DisplayFormat = "Ilość:{0:n0}";

                    gridView1.Columns["MASS"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["MASS"].SummaryItem.DisplayFormat = "Waga:{0:n2} kg";
                }
            }

            catch (Exception ex)
            {
                barStaticItemUser.Caption = "Błąd podczas ładowania danych";
                // Zawsze pokazuj błąd!
                XtraMessageBox.Show("Wystąpił błąd podczas pobierania danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gridView1.HideLoadingPanel(); // Ukryj wskaźnik ładowania, nawet jeśli wystąpił błąd
            }
        }

        private void btnAutoneum_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintReportForSelectedRows<Raporty.BorgersDE>();
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

        private void btnKonfiguracja_ItemClick(object sender, ItemClickEventArgs e)
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

        private void btnEditReport_ItemClick(object sender, ItemClickEventArgs e)
        {

            using (FormRaportDesigner designerForm = new FormRaportDesigner())
            {
                // Otwieramy formularz jako okno modalne, blokując dostęp do Form1.
                designerForm.ShowDialog(this);
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintReportWazen<Raporty.RaportDostawy>();
        }

        // Wydruk raportu ważenia
        private void PrintReportWazen<TReport>() where TReport : XtraReport, new()
        {
            // === ZMIANA: Pobranie przefiltrowanych danych ===
            // Pobierz wszystkie widoczne wiersze po zastosowaniu filtrów
            var filteredRows = new List<Wazenia>();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                // Sprawdź, czy wiersz jest widoczny po filtracji i grupowaniu
                // GetRow(i) zwraca obiekt danych dla wiersza o indeksie 'i' (uwzględniającym sortowanie i filtrowanie)
                object row = gridView1.GetRow(i);
                if (row is Wazenia wazenie)
                {
                    filteredRows.Add(wazenie);
                }
            }

            if (filteredRows.Count == 0)
            {
                XtraMessageBox.Show("Brak danych do wydruku po zastosowaniu filtrów!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                XtraReport report = new TReport();

                // === Użycie Twojej struktury katalogów ===
                string nazwaPliku = typeof(TReport).Name + ".repx";
                string sciezkaFolderuEdycji = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Raporty", "Raporty_edit"); // Użyj AppDomain.CurrentDomain.BaseDirectory dla aplikacji Windows Forms
                string sciezkaPliku = Path.Combine(sciezkaFolderuEdycji, nazwaPliku);

                // Jeśli plik .repx istnieje w folderze 'Raporty_edit', załaduj jego layout.
                if (File.Exists(sciezkaPliku))
                {
                    report.LoadLayout(sciezkaPliku);
                }

                report.DataSource = filteredRows; // Przypisz przefiltrowane dane jako źródło raportu
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Wystąpił błąd podczas generowania raportu:\n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormMenu_Load(object sender, EventArgs e)
        {
            //.Caption =  bsiZalogowanyUzytkownik.Caption = "Użytkownik: Niezalogowany";
            // barStaticItemUser.Caption = "Użytkownik: Niezalogowany";
            barStaticItemRecordCount.Caption = "Wczytano: 0 wierszy";
            barStaticItem1.Caption = "Użytkownik: Niezalogowany";
        }

        private void btnCzechy_ItemClick(object sender, ItemClickEventArgs e)
        {

            PrintReportForSelectedRows<Raporty.BorgersCz>();
        }

        private void btnAutoneum12_ItemClick(object sender, ItemClickEventArgs e)
        {

            PrintReportForSelectedRows<Raporty.Borgres12>();
        }

        private void btnSurowiec_ItemClick(object sender, ItemClickEventArgs e)
        {

            PrintReportForSelectedRows<Raporty.Surowiec>();
        }

        private void btnKopia_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FormBackupBazy formBackup = new FormBackupBazy())
            {
                formBackup.ShowDialog(this);
            }
        }
        private void ConfigureGridColumns()
        {
            if (gridView1.Columns.Count > 0)
            {
                gridView1.Columns["Date"].VisibleIndex = 1;
                gridView1.Columns["Date"].Caption = "Data ważenia";

                gridView1.Columns["ARTICLE_NAME"].VisibleIndex = 3;
                gridView1.Columns["ARTICLE_NAME"].Caption = "Nazwa artykułu";

                gridView1.Columns["BALANCE_NAME"].VisibleIndex = 10;
                gridView1.Columns["BALANCE_NAME"].Caption = "Nazwa wagi";

                gridView1.Columns["UNIT"].VisibleIndex = 4;
                gridView1.Columns["UNIT"].Caption = "Jednostka";
                gridView1.Columns["UNIT"].Width = 60; // Szerokość w pikselach

                gridView1.Columns["CODE_SERIES"].VisibleIndex = 8;
                gridView1.Columns["CODE_SERIES"].Caption = "Kod serii";

                gridView1.Columns["MASS"].VisibleIndex = 5;
                gridView1.Columns["MASS"].Caption = "Masa netto";

                gridView1.Columns["MASSBRUTTO"].VisibleIndex = 7;
                gridView1.Columns["MASSBRUTTO"].Caption = "Masa brutto";


                gridView1.Columns["MASS_KG"].Caption = "Masa [kg]";


                gridView1.Columns["TARE"].VisibleIndex = 6;
                gridView1.Columns["TARE"].Caption = "Tara";

                gridView1.Columns["SCODE_ARTICLE"].VisibleIndex = 2;
                gridView1.Columns["SCODE_ARTICLE"].Caption = "Kod artykułu";

                gridView1.Columns["kod_serii2"].Caption = "Kod serii 2";

                gridView1.Columns["archiwalne"].Caption = "Archiwalne";

                gridView1.Columns["licznik_statystyka"].Caption = "Licznik statystyka";

                gridView1.Columns["licznik_wazen"].Caption = "Licznik ważeń";

                gridView1.Columns["DZIEN"].Caption = "Dzień";

                gridView1.Columns["MIESIAC"].Caption = "Miesiąc";

                gridView1.Columns["ROK"].Caption = "Rok";

                gridView1.Columns["COOPERATOR"].VisibleIndex = 10;
                gridView1.Columns["COOPERATOR"].Caption = "Kooperator";

                gridView1.Columns["OPERATOR"].VisibleIndex = 12;
                gridView1.Columns["OPERATOR"].Caption = "Operator";



                gridView1.Columns["MASS_KG"].Visible = false;
                gridView1.Columns["OPERATOR"].Visible = false;
                gridView1.Columns["archiwalne"].Visible = false;






            }
        }
        private void btnExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Utwórz okno dialogowe zapisu pliku
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pliki Excel (*.xlsx)|*.xlsx|Wszystkie pliki (*.*)|*.*";
            saveFileDialog1.Title = "Zapisz plik Excel";
            saveFileDialog1.FileName = "Zasyp_surowców.xlsx"; // Domyślna nazwa pliku

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Upewnij się, że gridControl1 jest nazwą twojej kontrolki GridControl
                    // A gridView1 jest głównym widokiem GridControla
                    if (gridControl1.MainView is GridView gridView1)
                    {
                        string filePath = saveFileDialog1.FileName;

                        // Eksportuj dane do pliku XLSX
                        gridView1.ExportToXlsx(filePath);
                        MessageBox.Show("Dane zostały pomyślnie wyeksportowane do: " + filePath, "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // --- Dodany kod do otwierania pliku Excela ---
                        try
                        {
                            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                        }
                        catch (Exception exOpen)
                        {
                            MessageBox.Show("Nie można otworzyć pliku Excela. Upewnij się, że masz zainstalowany program do obsługi plików .xlsx. Błąd: " + exOpen.Message, "Błąd otwierania pliku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        // ---------------------------------------------
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas eksportowania danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridControl1.MainView is DevExpress.XtraGrid.Views.Grid.GridView gridView)
            {
                // Jeśli tak, rzutuj i wywołaj metodę
                gridView.ClearColumnsFilter();
            }
        }

    }
}

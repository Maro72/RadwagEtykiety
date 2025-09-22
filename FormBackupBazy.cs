using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadwagE
{
    public partial class FormBackupBazy : XtraForm
    {
        private SqlConnectionStringBuilder scsb;
        private string sciezkaDoFolderuKopii;
        private const int MAKSYMALNA_LICZBA_KOPII = 10;
        private Timer animationTimer; // Timer do płynnej animacji
        private int targetProgress;   // Docelowy procent, do którego animujemy

        public FormBackupBazy()
        {
            InitializeComponent();
        }

        private void FormBackupBazy_Load(object sender, EventArgs e)

        {
            animationTimer = new Timer();
            animationTimer.Interval = 20; // Aktualizuj co 20 milisekund (płynna animacja)
            animationTimer.Tick += AnimationTimer_Tick; // Podłącz metodę, która będzie wykonywana co tick
            // Przeniesiono logikę z konstruktora, aby zapewnić, że formularz jest w pełni zainicjalizowany
            Inicjalizuj();
            OdswiezListeKopii();
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Jeśli aktualna pozycja paska jest mniejsza niż docelowa
            if (pbPostep.Position < targetProgress)
            {
                // Zwiększ pozycję o 1
                pbPostep.Position++;
            }
            else
            {
                // Jeśli pasek osiągnął docelową wartość, zatrzymaj timer, aby nie zużywać zasobów CPU
                animationTimer.Stop();
            }
        }
        private void Inicjalizuj()
        {
            try
            {
                // Krok 1: Zdefiniuj stałą ścieżkę na dysku D:
                // Używamy znaku @, aby uniknąć problemów z backslashem.
                sciezkaDoFolderuKopii = @"D:\kopie_E2R";

                // Krok 2: Utwórz folder, jeśli jeszcze nie istnieje.
                // Jeśli już istnieje, ta metoda nic nie zrobi.
                Directory.CreateDirectory(sciezkaDoFolderuKopii);

                // Krok 3: Wczytaj konfigurację połączenia z bazą danych (bez zmian)
                var cs = ConfigurationManager.ConnectionStrings["E2REntities"]?.ConnectionString;
                if (string.IsNullOrEmpty(cs))
                {
                    lblStatus.Text = "Błąd: Brak konfiguracji bazy danych.";
                    btnWykonajKopie.Enabled = false;
                    btnPrzywrocKopie.Enabled = false;
                    return;
                }
                var ecsb = new EntityConnectionStringBuilder(cs);
                scsb = new SqlConnectionStringBuilder(ecsb.ProviderConnectionString);

                // Ustaw status początkowy
                lblStatus.Text = $"Gotowy. Baza danych: '{scsb.InitialCatalog}'";
            }
            catch (UnauthorizedAccessException uae)
            {
                // Specjalna obsługa błędu, jeśli aplikacja nie ma uprawnień do zapisu
                lblStatus.Text = "Błąd uprawnień do zapisu.";
                XtraMessageBox.Show($"Aplikacja nie ma uprawnień do tworzenia folderu w lokalizacji:\n{sciezkaDoFolderuKopii}\n\nUruchom aplikację jako administrator lub skontaktuj się z pomocą techniczną.\n\nSzczegóły: {uae.Message}", "Błąd Uprawnień", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnWykonajKopie.Enabled = false;
                btnPrzywrocKopie.Enabled = false;
            }
            catch (Exception ex)
            {
                // Ogólna obsługa innych, nieprzewidzianych błędów
                lblStatus.Text = "Błąd krytyczny podczas inicjalizacji.";
                XtraMessageBox.Show("Wystąpił nieoczekiwany błąd podczas inicjalizacji modułu kopii zapasowych:\n\n" + ex.Message, "Błąd Krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnWykonajKopie.Enabled = false;
                btnPrzywrocKopie.Enabled = false;
            }
        }

        private void OdswiezListeKopii()
        {
            lbKopieZapasowe.Items.Clear();
            try
            {
                var plikiKopii = Directory.GetFiles(sciezkaDoFolderuKopii, "*.bak")
                                          .Select(path => new FileInfo(path))
                                          .OrderByDescending(fi => fi.CreationTime) // Sortuj od najnowszej
                                          .ToList();

                foreach (var plik in plikiKopii)
                {
                    lbKopieZapasowe.Items.Add(plik.Name);
                }

                if (lbKopieZapasowe.Items.Count > 0)
                {
                    lbKopieZapasowe.SelectedIndex = 0; // Zaznacz najnowszą
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Nie udało się odczytać listy kopii zapasowych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZarzadzajStarymiKopiami()
        {
            var plikiKopii = Directory.GetFiles(sciezkaDoFolderuKopii, "*.bak")
                                      .Select(path => new FileInfo(path))
                                      .OrderBy(fi => fi.CreationTime) // Sortuj od najstarszej
                                      .ToList();

            while (plikiKopii.Count >= MAKSYMALNA_LICZBA_KOPII)
            {
                FileInfo najstarszyPlik = plikiKopii.First();
                try
                {
                    najstarszyPlik.Delete();
                    plikiKopii.RemoveAt(0); // Usuń z listy, aby pętla mogła kontynuować
                }
                catch (Exception ex)
                {
                    // Nie udało się usunąć pliku, przerwij pętlę, aby uniknąć zapętlenia
                    XtraMessageBox.Show($"Nie udało się usunąć najstarszej kopii zapasowej: {najstarszyPlik.Name}\nBłąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
        }

        private async void btnWykonajKopie_Click(object sender, EventArgs e)
        {
            // Krok 1: Sprawdź, czy konfiguracja bazy danych jest poprawna.
            if (scsb == null)
            {
                XtraMessageBox.Show("Konfiguracja bazy danych nie została wczytana poprawnie.", "Błąd Krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Krok 2: Zarządzaj starymi kopiami, usuwając najstarsze, jeśli limit jest przekroczony.
            // Robimy to PRZED utworzeniem nowej kopii.
            ZarzadzajStarymiKopiami();

            // Krok 3: Przygotuj nazwę i pełną ścieżkę dla nowego pliku kopii zapasowej.
            string nazwaPliku = $"{scsb.InitialCatalog}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.bak";
            string sciezkaDoPlikuKopii = Path.Combine(sciezkaDoFolderuKopii, nazwaPliku);

            // Krok 4: Przygotuj interfejs użytkownika do rozpoczęcia operacji.
            ZablokujPrzyciski(true);
            lblStatus.Text = "Wykonywanie kopii zapasowej...";
            targetProgress = 0;
            pbPostep.Position = 0;

            try
            {
                // Krok 5: Wykonaj operację backupu w osobnym wątku, aby nie blokować UI.
                await Task.Run(() =>
                {
                    using (var con = new SqlConnection(scsb.ConnectionString))
                    {
                        // Subskrybuj zdarzenie InfoMessage, aby otrzymywać informacje o postępie.
                        con.InfoMessage += Con_InfoMessage;

                        // Polecenie T-SQL do wykonania kopii zapasowej.
                        // "WITH STATS = 10" powoduje wysyłanie komunikatów o postępie co 10%.
                        string query = $"BACKUP DATABASE [{scsb.InitialCatalog}] TO DISK = @path WITH STATS = 10";

                        using (var cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@path", sciezkaDoPlikuKopii);
                            con.Open();
                            cmd.ExecuteNonQuery(); // Ta operacja może potrwać długo.
                        }
                    }
                });

                // Krok 6: Zaktualizuj UI po pomyślnym zakończeniu operacji.
                lblStatus.Text = "Kopia zapasowa zakończona pomyślnie!";
                targetProgress = 100; // Ustaw cel animacji na 100%
                if (!animationTimer.Enabled) animationTimer.Start(); // Uruchom animację do końca
              
            }
            catch (Exception ex)
            {
                // Krok 7: Obsłuż ewentualne błędy.
                lblStatus.Text = "Błąd podczas tworzenia kopii zapasowej.";
                XtraMessageBox.Show("Wystąpił błąd podczas tworzenia kopii zapasowej:\n\n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Krok 8: Zawsze, niezależnie od wyniku, wykonaj te czynności.
                ZablokujPrzyciski(false); // Odblokuj przyciski.
                OdswiezListeKopii();    // Odśwież listę plików w interfejsie.
            }
        }

        private async void btnPrzywrocKopie_Click(object sender, EventArgs e)
        {
            // Krok 1: Sprawdź, czy użytkownik wybrał plik z listy.
            if (lbKopieZapasowe.SelectedItem == null)
            {
                XtraMessageBox.Show("Proszę wybrać z listy kopię zapasową do przywrócenia.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Krok 2: Wyświetl bardzo ważne ostrzeżenie i uzyskaj potwierdzenie od użytkownika.
            var dr = XtraMessageBox.Show("UWAGA!\nPrzywrócenie bazy danych spowoduje nadpisanie wszystkich obecnych danych. " +
                                       "Wszelkie niezapisane zmiany zostaną utracone. Czy na pewno chcesz kontynuować?",
                                       "Potwierdzenie przywracania", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
            {
                return; // Użytkownik anulował operację.
            }

            // Krok 3: Przygotuj ścieżkę do pliku i interfejs użytkownika.
            string nazwaPliku = lbKopieZapasowe.SelectedItem.ToString();
            string sciezkaDoPlikuKopii = Path.Combine(sciezkaDoFolderuKopii, nazwaPliku);

            ZablokujPrzyciski(true);
            lblStatus.Text = "Przywracanie bazy danych...";
            targetProgress = 0;
            pbPostep.Position = 0;

            try
            {
                // Krok 4: Wykonaj operację przywracania w osobnym wątku.
                await Task.Run(() =>
                {
                    // Do przywrócenia bazy musimy połączyć się z bazą 'master',
                    // aby móc operować na docelowej bazie danych.
                    var masterScsb = new SqlConnectionStringBuilder(scsb.ConnectionString) { InitialCatalog = "master" };

                    using (var con = new SqlConnection(masterScsb.ConnectionString))
                    {
                        con.Open();

                        // a) Przełącz bazę w tryb jednego użytkownika, aby rozłączyć wszystkich innych.
                        string sql = $"ALTER DATABASE [{scsb.InitialCatalog}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                        using (var cmd = new SqlCommand(sql, con))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // b) Wykonaj właściwe przywracanie.
                        con.InfoMessage += Con_InfoMessage;
                        // "WITH REPLACE" pozwala nadpisać istniejącą bazę danych.
                        sql = $"RESTORE DATABASE [{scsb.InitialCatalog}] FROM DISK = @path WITH REPLACE, STATS = 10";
                        using (var cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@path", sciezkaDoPlikuKopii);
                            cmd.ExecuteNonQuery(); // Ta operacja może potrwać.
                        }

                        // c) Przełącz bazę z powrotem w tryb wielu użytkowników.
                        sql = $"ALTER DATABASE [{scsb.InitialCatalog}] SET MULTI_USER";
                        using (var cmd = new SqlCommand(sql, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                });

                // Krok 5: Zaktualizuj UI po sukcesie i poinformuj o restarcie.
                lblStatus.Text = "Baza danych została przywrócona pomyślnie!";
                targetProgress = 100;
                if (!animationTimer.Enabled) animationTimer.Start();

                XtraMessageBox.Show("Przywracanie zakończone pomyślnie. Aplikacja zostanie ponownie uruchomiona, aby odświeżyć dane i połączenie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch (Exception ex)
            {
                // Krok 6: Obsłuż błędy.
                lblStatus.Text = "Błąd podczas przywracania bazy danych.";
                XtraMessageBox.Show("Wystąpił krytyczny błąd podczas przywracania bazy danych:\n\n" + ex.Message, "Błąd Krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Po błędzie spróbuj przywrócić tryb MULTI_USER, aby baza nie została w stanie zablokowanym.
                PrzywrocTrybWieluUzytkownikowPoBledzie();
            }
            finally
            {
                // Krok 7: Odblokuj przyciski (jeśli aplikacja się nie zrestartowała po błędzie).
                ZablokujPrzyciski(false);
            }
        
        }

        // --- Metody Pomocnicze ---

        private void ZablokujPrzyciski(bool zablokowane)
        {
            btnWykonajKopie.Enabled = !zablokowane;
            btnPrzywrocKopie.Enabled = !zablokowane;
        }

        private void Con_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // Krok 1: Sprawdź, czy otrzymany komunikat jest tym, który nas interesuje.
            // Szukamy frazy "percent processed", którą serwer wysyła dzięki opcji "WITH STATS".
            if (e.Message.Contains("percent processed."))
            {
                // Krok 2: Wyodrębnij wartość procentową z komunikatu.
                // Komunikat ma format "XX percent processed.", więc bierzemy pierwszy człon.
                var text = e.Message.Split(' ')[0];

                // Krok 3: Spróbuj przekonwertować tekst na liczbę całkowitą.
                if (int.TryParse(text, out int percentage))
                {
                    // Krok 4: Zaktualizuj interfejs użytkownika w bezpieczny sposób.
                    // Ponieważ ta metoda jest wywoływana z wątku innego niż główny wątek UI,
                    // musimy użyć 'this.BeginInvoke', aby przekazać operację do właściwego wątku.
                    // Bez tego aplikacja zgłosiłaby błąd "Cross-thread operation not valid".
                    this.BeginInvoke(new Action(() => {

                        // a) Ustaw nową docelową wartość dla naszej animacji.
                        targetProgress = percentage;

                        // b) Uruchom timer, który będzie animował pasek postępu do tej wartości.
                        //    Sprawdzamy, czy timer już działa, aby nie uruchamiać go wielokrotnie.
                        if (!animationTimer.Enabled)
                        {
                            animationTimer.Start();
                        }
                    }));
                }
            }
        }

        private void PrzywrocTrybWieluUzytkownikowPoBledzie()
        {
            try
            {
                var masterScsb = new SqlConnectionStringBuilder(scsb.ConnectionString) { InitialCatalog = "master" };
                using (var con = new SqlConnection(masterScsb.ConnectionString))
                {
                    con.Open();
                    string sql = $"ALTER DATABASE [{scsb.InitialCatalog}] SET MULTI_USER";
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("UWAGA: Nie udało się automatycznie przywrócić trybu wielu użytkowników. Może być wymagana interwencja administratora.\nBłąd: " + ex.Message, "Błąd Krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
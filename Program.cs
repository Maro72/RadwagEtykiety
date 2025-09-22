using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace RadwagE
{
     static class Program
    {
        [STAThread]
        static void Main()
        {
            // === NOWY, BARDZO WAŻNY KOD ===
            // Rejestrujemy nasz niestandardowy typ 'Wazenia' jako zaufany.
            // Musi to być wykonane PRZED jakąkolwiek operacją na raportach.
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(RadwagE.Klasy.Wazenia));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(System.Collections.Generic.List<RadwagE.Klasy.Wazenia>));

            // Jeśli raporty używają też List<Wazenia>, warto dodać i ten typ:
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (!SprawdzPolaczenieZBaza())
            {
                // Jeśli połączenie jest niepoprawne, pokaż formularz konfiguracyjny
                using (var formKonfiguracja = new FormKonfiguracjaBazy())
                {
                    var result = formKonfiguracja.ShowDialog();
                    if (result == DialogResult.OK && formKonfiguracja.KonfiguracjaZapisana)
                    {
                        // Jeśli użytkownik zapisał nową konfigurację, restartujemy aplikację
                        Application.Restart();
                        return; // Zakończ bieżącą instancję
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        // Jeśli użytkownik anulował, zamykamy aplikację
                        return;
                    }
                }
            }

            // Jeśli połączenie jest poprawne, uruchom główny formularz
            Application.Run(new FormMenu());
        }

        private static bool SprawdzPolaczenieZBaza()
        {
            try
            {
                var cs = ConfigurationManager.ConnectionStrings["E2REntities"]?.ConnectionString;
                if (string.IsNullOrEmpty(cs))
                {
                    return false; // Brak connection stringa
                }

                // Używamy using, aby mieć pewność, że kontekst zostanie zwolniony
                using (var db = new Model.E2REntities())
                {
                    db.Database.Connection.Open(); // Najprostszy test - próba otwarcia połączenia
                    db.Database.Connection.Close();
                }
                return true; // Sukces
            }
            catch
            {
                return false; // Błąd podczas łączenia
            }
        }
    }
}


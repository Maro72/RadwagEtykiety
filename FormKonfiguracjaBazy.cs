using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; // Potrzebne do pracy z App.config
using System.Data.SqlClient; // Potrzebne do testowania połączenia
using System.Data.Entity.Core.EntityClient; // Potrzebne do pracy z EF connection string1


namespace RadwagE
{
    public partial class FormKonfiguracjaBazy : DevExpress.XtraEditors.XtraForm
    {
        // Zmienna przechowująca informację, czy konfiguracja została zapisana
        public bool KonfiguracjaZapisana { get; private set; } = false;

        public FormKonfiguracjaBazy()
        {
            InitializeComponent();
            WczytajAktualnaKonfiguracje();
        }
        private void FormKonfiguracjaBazy_Load(object sender, EventArgs e)
        {
            // Pozostaw pustą
        }
        private void WczytajAktualnaKonfiguracje()
        {
            try
            {
                // Odczytujemy connection string z App.config
                var cs = ConfigurationManager.ConnectionStrings["E2REntities"]?.ConnectionString;
                if (string.IsNullOrEmpty(cs)) return;

                // Używamy EntityConnectionStringBuilder, aby rozbić go na części
                var ecsb = new EntityConnectionStringBuilder(cs);
                var sqlCs = ecsb.ProviderConnectionString; // Wyciągamy connection string dla SQL Servera
                var scsb = new SqlConnectionStringBuilder(sqlCs);

                // Wypełniamy pola na formularzu
                txtServer.Text = scsb.DataSource;
                txtBazaDanych.Text = scsb.InitialCatalog;

                if (scsb.IntegratedSecurity)
                {
                    rgAutentykacja.SelectedIndex = 0; // Autentykacja Windows
                }
                else
                {
                    rgAutentykacja.SelectedIndex = 1; // Autentykacja SQL Server
                    txtUzytkownik.Text = scsb.UserID;
                    txtHaslo.Text = scsb.Password;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Nie udało się wczytać konfiguracji: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rgAutentykacja_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Włącz/wyłącz pola loginu i hasła w zależności od wyboru
            bool sqlAuth = rgAutentykacja.SelectedIndex == 1;
            txtUzytkownik.Enabled = sqlAuth;
            txtHaslo.Enabled = sqlAuth;
        }

        private string ZbudujProviderConnectionString()
        {
            var scsb = new SqlConnectionStringBuilder
            {
                DataSource = txtServer.Text,
                InitialCatalog = txtBazaDanych.Text
            };

            if (rgAutentykacja.SelectedIndex == 0) // Autentykacja Windows
            {
                scsb.IntegratedSecurity = true;
            }
            else // Autentykacja SQL Server
            {
                scsb.IntegratedSecurity = false;
                scsb.UserID = txtUzytkownik.Text;
                scsb.Password = txtHaslo.Text;
            }
            return scsb.ConnectionString;
        }

        private void btnTestuj_Click(object sender, EventArgs e)
        {
            string providerCs = ZbudujProviderConnectionString();
            try
            {
                using (var con = new SqlConnection(providerCs))
                {
                    con.Open(); // Próba otwarcia połączenia
                }
                XtraMessageBox.Show("Połączenie udane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Połączenie nieudane.\n\nBłąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var csSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

                if (csSection == null)
                {
                    XtraMessageBox.Show("Brak sekcji 'connectionStrings' w pliku App.config.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Pobieramy istniejący connection string *bezpośrednio z odczytanego pliku*
                var currentConnectionString = csSection.ConnectionStrings["E2REntities"].ConnectionString;

                // Budujemy nowy provider connection string na podstawie danych z formularza
                var providerCs = ZbudujProviderConnectionString();

                // Używamy EntityConnectionStringBuilder do bezpiecznej modyfikacji
                var ecsb = new EntityConnectionStringBuilder(currentConnectionString)
                {
                    ProviderConnectionString = providerCs
                };

                // Aktualizujemy wartość w odczytanym obiekcie konfiguracyjnym
                csSection.ConnectionStrings["E2REntities"].ConnectionString = ecsb.ConnectionString;

                // Zapisujemy zmiany z powrotem do pliku RadwagE.exe.config
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                KonfiguracjaZapisana = true;
                XtraMessageBox.Show("Konfiguracja została zapisana. Aplikacja zostanie ponownie uruchomiona.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Nie udało się zapisać konfiguracji.\n\nBłąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
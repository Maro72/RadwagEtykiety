using DevExpress.Design;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using RadwagE.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadwagE
{
    public partial class FormRaportDesigner : DevExpress.XtraEditors.XtraForm
    {
        private Dictionary<string, Type> dostepneRaporty = new Dictionary<string, Type>();

        public FormRaportDesigner()
        {
            InitializeComponent();
            InicjalizujRaporty();
        }

        private void InicjalizujRaporty()
        {
            // Rejestracja raportów - bez zmian
            dostepneRaporty.Add("Etykieta Autoneum zielone", typeof(RadwagE.Raporty.BorgersZielone));
            dostepneRaporty.Add("Etykieta Surowiec", typeof(RadwagE.Raporty.Surowiec));
            dostepneRaporty.Add("Etykieta Autoneum (CZ)", typeof(RadwagE.Raporty.BorgersCz));
            dostepneRaporty.Add("Etykieta Autoneum (DE)", typeof(RadwagE.Raporty.BorgersDE));
            dostepneRaporty.Add("Etykieta Autoneum (12)", typeof(RadwagE.Raporty.Borgres12));
            dostepneRaporty.Add("Raport Dostawy", typeof(RadwagE.Raporty.RaportDostawy));
            // ...

            foreach (var nazwaRaportu in dostepneRaporty.Keys)
            {
                cbRaportyDoEdycji.Properties.Items.Add(nazwaRaportu);
            }
            if (cbRaportyDoEdycji.Properties.Items.Count > 0)
            {
                cbRaportyDoEdycji.SelectedIndex = 0;
            }
        }




        // === ZNACZNIE UPROSZCZONA KLASA POMOCNICZA ===
        // Wystarczy zaimplementować prosty interfejs ICommandHandler
        public class SaveCommandHandler : ICommandHandler
        {
            private readonly string sciezkaDoPliku;
            // NOWE POLE: przechowuje referencję do panelu projektanta
            private XRDesignPanel panel;

            public SaveCommandHandler(XRDesignPanel panel, string sciezka)
            {
                this.panel = panel;
                this.sciezkaDoPliku = sciezka;
            }

            public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
            {
                useNextHandler = command != ReportCommand.SaveFile;
                return !useNextHandler;
            }

            public void HandleCommand(ReportCommand command, object[] args)
            {
                // POBIERAMY RAPORT BEZPOŚREDNIO Z PANELU, A NIE Z 'args'
                XtraReport raport = panel.Report;

                if (raport != null)
                {
                    raport.SaveLayout(sciezkaDoPliku);
                    XtraMessageBox.Show($"Layout raportu został zapisany w:\n{sciezkaDoPliku}", "Zapisano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Ta klasa rozszerza standardowe narzędzie projektanta o naszą logikę zapisu
        public class CustomReportDesignTool : ReportDesignTool
        {
            private readonly string sciezkaDoZapisu;

            public CustomReportDesignTool(XtraReport report, string sciezka) : base(report)
            {
                XRDesignForm designForm = this.DesignForm as XRDesignForm;
                if (designForm != null)
                {
                    designForm.Load += DesignForm_Load;
                }
            }

            private void DesignForm_Load(object sender, EventArgs e)
            {
                // Pobieramy panel projektanta z formularza
                XRDesignPanel panel = ((XRDesignForm)sender).DesignMdiController.ActiveDesignPanel;
                if (panel != null)
                {
                    // Rejestrujemy nasz CommandHandler
                    panel.AddService(typeof(ICommandHandler), new SaveCommandHandler(panel, sciezkaDoZapisu));
                }
            }
        }

        private void btnProjektujRaport_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cbRaportyDoEdycji.SelectedItem == null)
                {
                    XtraMessageBox.Show("Proszę wybrać raport do edycji.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Type typRaportu = dostepneRaporty[cbRaportyDoEdycji.SelectedItem.ToString()];
                XtraReport raport = (XtraReport)Activator.CreateInstance(typRaportu);

                string nazwaPliku = typRaportu.Name + ".repx";
                string sciezkaFolderuEdycji = Path.Combine(Application.StartupPath, "Raporty", "Raporty_edit");
                string sciezkaDoPliku = Path.Combine(sciezkaFolderuEdycji, nazwaPliku);

                Directory.CreateDirectory(sciezkaFolderuEdycji);

                if (File.Exists(sciezkaDoPliku))
                {
                    raport.LoadLayout(sciezkaDoPliku);
                }

                raport.DataSource = new List<Wazenia> { new Wazenia() };

                // Używamy naszej niestandardowej klasy do uruchomienia projektanta
                CustomReportDesignTool designTool = new CustomReportDesignTool(raport, sciezkaDoPliku);

                // Pokaż okno projektanta
                designTool.ShowRibbonDesignerDialog();

                // === NOWY KOD - Zamknij bieżący formularz po otwarciu projektanta ===
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Wystąpił nieoczekiwany błąd podczas próby otwarcia projektanta:\n\n" +
                    "Komunikat: " + ex.Message + "\n\n" +
                    "Ślad stosu: " + ex.StackTrace,
                    "Błąd Krytyczny",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void FormRaportDesigner_Load(object sender, EventArgs e)
        {

        }
    }
}


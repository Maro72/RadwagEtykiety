using Newtonsoft.Json;
using RadwagE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public static class ZarzadzanieUzytkownikami
{
    private static List<Uzytkownik> listaUzytkownikow;

    // Metoda do haszowania hasła (prosty przykład, w rzeczywistych systemach użyj saltingu)
    private static string HaszujHaslo(string haslo)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(haslo));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public static void Inicjalizuj()
    {
        // Odczytaj dane z ustawień
        string daneJson = RadwagE.Properties.Settings.Default.Uzytkownicy;
        if (string.IsNullOrEmpty(daneJson))
        {
            // Jeśli nie ma żadnych użytkowników, stwórz domyślnego administratora
            listaUzytkownikow = new List<Uzytkownik>();
            listaUzytkownikow.Add(new Uzytkownik
            {
                NazwaUzytkownika = "admin",
                HashHasla = HaszujHaslo("admin"), // Domyślne hasło: admin
                Rola = RolaUzytkownika.Administrator
            });
            ZapiszUzytkownikow();
        }
        else
        {
            // Deserializuj listę z JSON
            listaUzytkownikow = JsonConvert.DeserializeObject<List<Uzytkownik>>(daneJson);
        }
    }

    public static void ZapiszUzytkownikow()
    {
        string daneJson = JsonConvert.SerializeObject(listaUzytkownikow, Formatting.Indented);
        RadwagE.Properties.Settings.Default.Uzytkownicy = daneJson;
        RadwagE.Properties.Settings.Default.Save();
    }

    public static Uzytkownik Weryfikuj(string nazwa, string haslo)
    {
        string hashPodanegoHasla = HaszujHaslo(haslo);
        return listaUzytkownikow.FirstOrDefault(u =>
            u.NazwaUzytkownika.Equals(nazwa, StringComparison.OrdinalIgnoreCase) &&
            u.HashHasla == hashPodanegoHasla);
    }
}
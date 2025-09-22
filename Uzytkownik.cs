using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadwagE
{
    public enum RolaUzytkownika
    {
        Administrator,
        Uzytkownik
    }

    public class Uzytkownik
    {
        public string NazwaUzytkownika { get; set; }
        public string HashHasla { get; set; } // Nigdy nie przechowuj haseł w czystym tekście!
        public RolaUzytkownika Rola { get; set; }
    }
}

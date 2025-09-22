using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadwagE.Klasy
{
public class Wazenia
    {
        
        public long? id { get; set; }
        public DateTime? Date { get; set; }
        public string ARTICLE_NAME { get; set; }
        public string BALANCE_NAME { get; set; }
        public string UNIT { get; set; }
        public string OPERATOR { get; set; }
        public string CODE_SERIES { get; set; }
        public float? MASS { get; set; }
        public float? MASSBRUTTO { get; set; }
        public float? MASS_KG { get; set; }
        public float? TARE { get; set; }
        public string SCODE_ARTICLE { get; set; }
        public string kod_serii2 { get; set; }
        public bool? archiwalne { get; set; }
        public int? licznik_statystyka { get; set; }
        public int? licznik_wazen { get; set; }
        public int? DZIEN { get; set; }
        public int? MIESIAC { get; set; }
        public int? ROK { get; set; }
        public string COOPERATOR { get; set; }


    }
}


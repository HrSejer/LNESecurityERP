using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    internal class Produkt
    {
        public int Varenummer { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public int Salgsspris { get; set; }
        public int Indkoebspris { get; set; }
        public string Lokation { get; set; }
        public decimal Antalpaalager { get; set; }
        public string Enhed { get; set; }

        public Produkt(int varenummer, string navn, string beskrivelse, int salgsspris, int indkoebspris, string lokation, decimal antalpaalager, string enhed)
        {
            varenummer = Varenummer;
            navn = Navn;
            beskrivelse = Beskrivelse;
            salgsspris = Salgsspris;
            indkoebspris = Indkoebspris;
            lokation = Lokation;
            antalpaalager = Antalpaalager;
            enhed = Enhed;
        }

    }
}

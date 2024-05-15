using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public enum Enhed
    {
        Styk,
        Timer,
        Meter
    }
    public class Produkt
    {
        public int ProduktId { get; set; }
        public int Varenummer { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public decimal Salgspris { get; set; }
        public decimal Indkoebspris { get; set; }
        public string Lokation { get; set; }
        public decimal Antalpaalager { get; set; }
        public Enhed Enhed { get; set; }
        public decimal Avance { get; set; }
        public decimal Fortjeneste { get; set; }

        public Produkt(int produktId, int varenummer, string navn, string beskrivelse, decimal salgsspris, decimal indkoebspris, string lokation, decimal antalpaalager, Enhed enhed, decimal avance, decimal fortjeneste)
        {
            ValidLokation(lokation);
            ProduktId = produktId;
            Varenummer = varenummer;
            Navn = navn;
            Beskrivelse = beskrivelse;
            Salgspris = salgsspris;
            Indkoebspris = indkoebspris;
            Lokation = lokation;
            Antalpaalager = antalpaalager;
            Enhed = enhed;
            Avance = avance;
            Fortjeneste = fortjeneste;
        }

        public Produkt() 
        {
            ProduktId = 0;
            Varenummer = 0;
            Navn = string.Empty;
            Beskrivelse = string.Empty;
            Salgspris = 0;
            Indkoebspris = 0;
            Lokation = string.Empty;
            Antalpaalager = 0;
            Avance = 0;
            Fortjeneste = 0;
        }
        private string ValidLokation(string lokation)
        {
            if (lokation.Length != 4 || !lokation.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Lokation skal være 4 bogstaver/tal.");
            }

            return lokation;
        }

        public decimal BeregnFortjeneste()
        {
            Fortjeneste = Salgspris - Indkoebspris;
            return Fortjeneste;
        }

        public decimal BeregnAvanceProcent()
        {
            Avance =  Salgspris / Indkoebspris * 100;
            return Avance;
        }



    }
}

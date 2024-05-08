using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Produkt
    {
        public int Varenummer { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public decimal Salgspris { get; set; }
        public decimal Indkoebspris { get; set; }
        public string Lokation { get; set; }
        public decimal Antalpaalager { get; set; }
        public string Enhed { get; set; }
        public decimal Avance { get; set; }

        public Produkt(int varenummer, string navn, string beskrivelse, decimal salgsspris, decimal indkoebspris, string lokation, decimal antalpaalager, string enhed, decimal avance)
        {

            ValidLokation(lokation);
            ValidEnhed(enhed);
            Varenummer = varenummer;
            Navn = navn;
            Beskrivelse = beskrivelse;
            Salgspris = salgsspris;
            Indkoebspris = indkoebspris;
            Lokation = lokation;
            Antalpaalager = antalpaalager;
            Enhed = enhed;
            Avance = avance;
        }

        public Produkt() 
        { 
            Varenummer = 0;
            Navn = string.Empty;
            Beskrivelse = string.Empty;
            Salgspris = 0;
            Indkoebspris = 0;
            Lokation = string.Empty;
            Antalpaalager = 0;
            Enhed = string.Empty;
            Avance = 0;
        }
        private string ValidLokation(string lokation)
        {
            lokation = "aaa2";

            if (lokation.Length != 4 || !lokation.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Lokation skal være 4 bogstaver/tal.");
            }
            return lokation;
        }

        private string ValidEnhed(string enhed)
        {
            enhed = "styk";

            string[] gyldigeEnheder = { "styk", "timer", "meter" };
            if (!gyldigeEnheder.Contains(enhed.ToLower()))
            {
                throw new ArgumentException("Ugyldig enhed. De tilladte enheder er: styk, timer eller meter.");
            }
            return enhed;
        }
        public decimal BeregnFortjeneste()
        {
            return Salgspris - Indkoebspris;
        }

        public decimal BeregnAvanceProcent()
        {
            return Salgspris / Indkoebspris * 100;
        }



    }
}

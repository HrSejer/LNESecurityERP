using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Salgsordrehoved
    {
        public int Ordrenummer { get; set; }
        public DateTime Oprettelsestidspunkt { get; set; }
        public DateTime Gennemførelsestidspunkt { get; set; }
        public int Kundenummer { get; set; }
        public string Tilstand { get; set; }
        
        List<string> Ordrelinjer = new List<string>();
        public int Ordrebeløb { get; set; }

        public Salgsordrehoved() { }
        public Salgsordrehoved(int ordreNummer, int kundeNummer, string tilstand, int ordreBeløb) 
        {
            Ordrenummer = ordreNummer;
            Kundenummer = kundeNummer;
            Tilstand = tilstand;
            Ordrebeløb = ordreBeløb;
        }
        private string ValidTilstand(string enhed)
        {
            string[] gyldigeEnheder = { "Ingen", "Oprettet", "Bekræftet", "Pakket", "Færdig" };
            if (!gyldigeEnheder.Contains(enhed.ToLower()))
            {
                throw new ArgumentException("Ugyldig enhed. De tilladte tilstande er: Ingen, Oprettet, Bekræftet, Pakket eller Færdig .");
            }
            return enhed;
        }
    }
}

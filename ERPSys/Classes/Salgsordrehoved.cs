using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
   public enum Tilstand
    {
        Ingen,
        Oprettet,
        Bekræftet,
        Pakket,
        Færdig
    }
    public class Salgsordrehoved
    {
        public int OrdreId { get; set; }
        public int Ordrenummer { get; set; }
        public DateTime Oprettelsestidspunkt { get; set; }
        public DateTime Gennemførelsestidspunkt { get; set; }
        public int Kundenummer { get; set; }
        public Tilstand Tilstand { get; set; }

        List<string> Ordrelinjer = new List<string>();
        public decimal Ordrebeløb { get; set; }
        public string Kundenavn { get; set; }
        public DateTime Dato { get; set; }
        
        public Salgsordrehoved(int ordreId, int ordreNummer, DateTime dato, int kundeNummer, string kundeNavn, decimal ordreBeløb, Tilstand tilstand, DateTime oprettelsestidspunkt, DateTime gennemførelsestidspunkt)
        {
            OrdreId = ordreId;
            Ordrenummer = ordreNummer;
            Dato = dato;
            Kundenummer = kundeNummer;
            Kundenavn = kundeNavn;
            Ordrebeløb = ordreBeløb;
            Tilstand = tilstand;
            Oprettelsestidspunkt = oprettelsestidspunkt;
            Gennemførelsestidspunkt = gennemførelsestidspunkt;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Salgsordrehoved() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}

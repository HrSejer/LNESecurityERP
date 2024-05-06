using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Kunde : Person
    {
        public int KundeNummer { get; set; }
        public DateTime Dato { get; set; }
        public Kunde(string navn, string fornavn, string efternavn, Addresse addresser, int tlfnummer, string mail, int kundenummer, DateTime dato) :base(navn, fornavn, efternavn, addresser, tlfnummer, mail) 
        {
            KundeNummer = kundenummer;
            Dato = dato;
            Navn = navn;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Addresser = addresser;
            Tlfnummer = tlfnummer;
            Mail = mail;
        }
        public Kunde() : base("", "", "", null, 1, "")
        {
            Navn = string.Empty;
            Addresser = null;
            Tlfnummer = 0;
            Mail = string.Empty;
            Fornavn = string.Empty;
            Efternavn = string.Empty;
            KundeNummer = 0;
            Dato = DateTime.Now;
        }
    }
}

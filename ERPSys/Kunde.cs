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
        public Kunde(string navn, string fornavn, string efternavn, string addresse, int tlfnummer, string mail, int kundenummer, DateTime dato): base(navn, fornavn, efternavn, addresse, tlfnummer, mail) 
        {
            KundeNummer = kundenummer;
            Dato = dato;
        }
    }
}

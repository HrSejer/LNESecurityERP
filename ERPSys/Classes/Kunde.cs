using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Kunde : Addresse
    {
        public int KundeNummer { get; set; }
        public DateTime Dato { get; set; }
        public Kunde() : base() 
        {
        }
        public Kunde(int personid, string navn, string fornavn, string efternavn, string tlfnummer, string mail, int AddressId, string Address, int kundenummer, DateTime dato)
            : base(personid, navn, fornavn, efternavn, tlfnummer, mail,AddressId,Address)
        {
            KundeNummer = kundenummer;
            Dato = dato;
        }     
    }
}

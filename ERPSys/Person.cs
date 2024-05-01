using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    internal class Person
    {
        public string Navn { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Addresse { get; set; }
        public int Tlfnummer { get; set; }
        public string Mail { get; set; }

        public Person(string navn, string fornavn, string efternavn, string addresse, int tlfnummer, string mail) 
        {
            navn = Navn;
            addresse = Addresse;
            tlfnummer = Tlfnummer;
            mail = Mail;
            fornavn = Fornavn;
            efternavn = Efternavn;
        }

        public string Fullname()
        {
            return $"{Fornavn}. {Efternavn}";
        }

        public void DisplayInfo()
        {

        }
    }
}

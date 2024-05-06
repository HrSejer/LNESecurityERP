using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Person
    {
        public Addresse Addresser { get; set; }
        public string Navn { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public int Tlfnummer { get; set; }
        public string Mail { get; set; }

        public Person(string navn, string fornavn, string efternavn, Addresse addresser, int tlfnummer, string mail) 
        {
            Navn = navn;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Addresser = addresser;
            Tlfnummer = tlfnummer;
            Mail = mail;
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

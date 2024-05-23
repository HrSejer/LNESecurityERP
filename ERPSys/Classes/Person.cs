using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Person : Addresse
    {
        public int PersonId { get; set; }
        public string Navn { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public int Tlfnummer { get; set; }
        public string Mail { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Person(): base()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        public Person(int personid, string navn, string fornavn, string efternavn, int tlfnummer, string mail, int addressId, string Address) : base(addressId, Address)
        {
            PersonId = personid;
            Navn = navn;
            Fornavn = fornavn;
            Efternavn = efternavn;
            AddressId = addressId;
            Addresser = Address;
            Tlfnummer = tlfnummer;
            Mail = mail;
        }

        public string Fullname()
        {
            return $"{Fornavn} {Efternavn}";
        }
    }
}

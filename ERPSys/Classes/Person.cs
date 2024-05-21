﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Person : Addresse
    {
        public string Navn { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public int Tlfnummer { get; set; }
        public string Mail { get; set; }
        public Person(): base()
        {

        }

        public Person(string navn, string fornavn, string efternavn, int tlfnummer, string mail, int addressId, string Address) : base(addressId, Address)
        {
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

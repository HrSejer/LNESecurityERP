﻿using System;
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
        public Kunde() : base() 
        {
        }
        public Kunde(string navn, string fornavn, string efternavn, int tlfnummer, string mail, int AddressId, string Address, int kundenummer, DateTime dato)
            : base(navn, fornavn, efternavn, tlfnummer, mail,AddressId,Address)
        {
            KundeNummer = kundenummer;
            Dato = dato;
            Navn = navn;
            Fornavn = fornavn;
            Efternavn = efternavn;
            
            Tlfnummer = tlfnummer;
            Mail = mail;
        }     
    }
}
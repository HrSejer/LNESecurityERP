using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ERPSys.Currency;


namespace ERPSys
{
    //Class/constructor for the UI 
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = "";
        public string Vej { get; set; }
        public string Husnummer { get; set; }
        public string Postnummer { get; set; }
        public string By { get; set; }
        public string Land { get; set; }
        public Currency.Valuta Currency { get; set; } // Changed type to Currency
                                               //this empty constructor is here only to stop the CS0310 ERRROR  
        public Company() { }
        public Company(int id, string companyName, string vej, string husnummer, string postnummer, string by, string land, Currency.Valuta currency) // Changed parameter type to Currency
        {
            Id = id;
            CompanyName = companyName;
            Vej = vej;
            Husnummer = husnummer;
            Postnummer = postnummer;
            By = by;
            Land = land;
            Currency = currency;
        }
    }
}

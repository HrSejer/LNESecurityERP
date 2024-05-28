using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ERPSys.Currency;


namespace ERPSys
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = "";
        public string Land { get; set; } = "";
        public string By { get; set; } = "";
        public string Vej { get; set; } = "";
        public string Husnummer { get; set; } = "";
        public string Postnummer { get; set; } = "";
        public Currency.Valuta Money { get; set; } 
                                               
        public Company() { }
        public Company(int id, string companyName, string vej, string husnummer, string postnummer, string by, string land, Currency.Valuta currency)
        {
            Id = id;
            CompanyName = companyName;
            Land = land;
            By = by;
            Vej = vej;
            Husnummer = husnummer;
            Postnummer = postnummer;
            Money = currency;
        }
    }
}

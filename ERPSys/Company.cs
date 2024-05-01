using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ERPSys
{
    internal class Company
    {
        public string CompanyName { get; set; } = "";
        public string Vej { get; set;}
        public string Husnummer { get; set; }
        public string Postnummer { get; set; }
        public string By { get; set; }
        public string Land {  get; set; }
        public string Currency {  get; set; }
        public Company() { }
        public Company(string companyName, string vej, string husnummer, string postnummer, string by, string land, string currency)
        {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Virksomhed
    {
        public int Id { get; set; }
        public string Firmanavn { get; set; }
        public string Vej { get; set; }
        public int Husnummer { get; set; }
        public int Postnummer { get; set; }
        public string By { get; set; }
        public string Land { get; set; }
        public string Valuta { get; set;}

        public Virksomhed(int id, string firmanavn, string vej, int husnummer,int postnummer, string by, string land, string valuta) 
        {
            id = Id;
            firmanavn = Firmanavn;
            vej = Vej;
            husnummer = Husnummer;
            postnummer = Postnummer;
            by = By;
            land = Land;
            valuta = Valuta;
        }
    }
}

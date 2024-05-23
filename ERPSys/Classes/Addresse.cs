using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Addresse : Person
    {
        public int AddressId { get; set; }
        public string Addresser { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Addresse():base()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { 
        }
        public Addresse(int personid, string navn, string fornavn, string efternavn, int tlfnummer, string mail, int addressId, string addresser) : base(personid, navn, fornavn, efternavn, tlfnummer, mail)
        {
            AddressId = addressId;
            Addresser = addresser;
        }
    }
}

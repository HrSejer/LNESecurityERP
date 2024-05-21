using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Addresse
    {
        public int AddressId { get; set; }
        public string Addresser { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Addresse()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { 
        }
        public Addresse(int addressId, string addresser) 
        {
            AddressId = addressId;
            Addresser = addresser;
        }
    }
}

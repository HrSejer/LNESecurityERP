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
        public Addresse() 
        { 
        }
        public Addresse(int addressId, string addresser) 
        {
            AddressId = addressId;
            Addresser = addresser;
        }
    }
}

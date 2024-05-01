using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public class Salgsordrehoved
    {
        public int Ordrenummer { get; set; }
        public DateTime Oprettelsestidspunkt { get; set; }
        public DateTime Gennemførelsestidspunkt { get; set; }
        public int Kundenummer { get; set; }
        public string Tilstand { get; set; }
        
        List<string> ordrelinjer = new List<string>();
        public int Ordrebeløb { get; set; }

        public Salgsordrehoved() 
        {
            
        }
    }
}

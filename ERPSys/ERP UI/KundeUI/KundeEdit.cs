using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class KundeEdit(Kunde kunde): Screen
    {
        public override string Title { get; set; } = "Kunde Edit";
        protected override void Draw()
        {
            ExitOnEscape(); 
            Clear(this);
            
            Form<Kunde> edit = new();

            edit.TextBox("Navn", nameof(kunde.Navn));
            edit.IntBox("TLF nummer", nameof(kunde.Tlfnummer));
            edit.TextBox("Mail", nameof(kunde.Mail));
            edit.TextBox("Addresse",nameof(kunde.Addresser));
            edit.TextBox("", nameof(kunde.Dato));
        }
    }
}

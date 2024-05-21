using Google.Protobuf.Reflection;
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
        Person person = new();
        public override string Title { get; set; } = "Kunde Edit";
        protected override void Draw()
        {
           
            Clear(this);

            ExitOnEscape();

            Form<Kunde> edit = new();

            edit.TextBox("Fornavn", nameof(kunde.Fornavn));
            edit.TextBox("Efternavn", nameof(kunde.Efternavn));
            edit.IntBox("TLF nummer", nameof(kunde.Tlfnummer));
            edit.TextBox("Mail", nameof(kunde.Mail));
            edit.TextBox("Addresse",nameof(kunde.Addresser));
            edit.TextBox("Dato", nameof(kunde.Dato));

            if (edit.Edit(kunde))
            {
                person.Fornavn = kunde.Fornavn;
                person.Efternavn = kunde.Efternavn;
                kunde.Navn = person.Fullname();
                if (kunde.KundeNummer != 0)
                {
                    Database.Instance.UpdateKunde(kunde);
                }
                else if (kunde.KundeNummer == 0)
                {
                    kunde.Dato = DateTime.Now;
                    Database.Instance.InsertKunde(kunde);
                }

            }
            else
            {

            }
        }
    }
}

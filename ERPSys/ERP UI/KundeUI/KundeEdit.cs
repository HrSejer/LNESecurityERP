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
            edit.TextBox("Tlfnummer", nameof(kunde.Tlfnummer));
            edit.TextBox("Mail", nameof(kunde.Mail));
            edit.TextBox("Addresse",nameof(kunde.Addresser));
            edit.TextBox("Dato", nameof(kunde.Dato));

            if (edit.Edit(kunde))
            {
                // taken the code from stack checks if there is any that hold null or is empty
                if (string.IsNullOrEmpty(kunde.Fornavn) || 
                    string.IsNullOrEmpty(kunde.Efternavn) || 
                    string.IsNullOrEmpty(kunde.Tlfnummer) || 
                    string.IsNullOrEmpty(kunde.Mail) || 
                    string.IsNullOrEmpty(kunde.Addresser))
                {
                    Console.WriteLine("JKunde not saved since missing data");
                    return;
                }

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
                Console.WriteLine("JKunde gemt");
            }
            else
            {
                Console.WriteLine("Jkunde blev ikke gemt");
            }
        }
    }
}

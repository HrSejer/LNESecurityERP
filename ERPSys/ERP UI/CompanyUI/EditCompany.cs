using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace ERPSys
{
    public class EditCompany(Company company) : Screen
    {
        Database database = Database.Instance;
        public override string Title { get; set; } = "Company Edit";
        protected override void Draw()
        {
            Clear(this);

            ExitOnEscape();

            Form<Company> editor = new();

            editor.TextBox("Company Name", nameof(company.CompanyName));
            editor.TextBox("Country", nameof(company.Land));
            editor.TextBox("By", nameof(company.By));
            editor.TextBox("Husnummer", nameof(company.Husnummer));
            editor.TextBox("Vej", nameof(company.Vej));
            editor.TextBox("Postnummer", nameof(company.Postnummer));
            editor.SelectBox("Currency", nameof(company.Money));
            editor.AddOption("Currency", "DKK", Currency.Valuta.DKK);
            editor.AddOption("Currency", "USD", Currency.Valuta.USD);
            editor.AddOption("Currency", "EURO", Currency.Valuta.EURO);
            editor.AddOption("Currency", "SEK", Currency.Valuta.SEK);

            if (editor.Edit(company))
            {
                if (string.IsNullOrEmpty(company.CompanyName) ||
                    string.IsNullOrEmpty(company.Land) ||
                    string.IsNullOrEmpty(company.Husnummer) ||
                    string.IsNullOrEmpty(company.Vej) ||
                    string.IsNullOrEmpty(company.Postnummer))
                {
                    Console.WriteLine("JCompany not saved since missing data");
                    return;
                }

                if (company.Id != 0)
                {
                    Database.Instance.UpdateCompany(company);
                }
                else if(company.Id == 0) 
                {
                    Database.Instance.InsertCompany(company);
                }
                Console.WriteLine("JCompany saved");
            }
            else
            {
                Console.WriteLine("JCompany not saved");
            }
        }
    }
}
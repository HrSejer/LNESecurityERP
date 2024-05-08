using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class EditCompany(Company company) : Screen
    {
        readonly CompanyData database = new();
        public override string Title { get; set; } = "Company Edit";
        protected override void Draw()
        {
            Clear(this);

            ExitOnEscape();

            Form<Company> editor = new Form<Company>();
            editor.TextBox("Company Name", "CompanyName");
            editor.TextBox("Country", "Land");
            editor.SelectBox("Currency", "Currency");
            editor.AddOption("Currency", "DKK", Currency.Valuta.DKK);
            editor.AddOption("Currency", "USD", Currency.Valuta.USD);
            editor.AddOption("Currency", "EURO", Currency.Valuta.EURO);
            editor.AddOption("Currency", "SEK", Currency.Valuta.SEK);
            editor.TextBox("Husnummer", "Husnummer");
            editor.TextBox("Postnummer", "Postnummer");
            editor.TextBox("By", "By");

            if (editor.Edit(company))
            {
                if (company.Id != 0)
                {
                    database.UpdateCompany(company);
                }
                else
                {

                }

            }
            else
            {

            }
        }
    }
}
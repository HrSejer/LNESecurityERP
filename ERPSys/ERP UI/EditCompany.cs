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
        public override string Title { get; set; } = "Company Edit";
        protected override void Draw()
        {
            Clear(this);
            

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
            editor.Edit(company);
            
            ExitOnEscape();

            Clear(this);
        }
    }
}

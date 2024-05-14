using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class SelectedCompany(Company company) : Screen
    {
        //made to show a single company's information
        public override string Title { get; set; } = "Selected Company";
        protected override void Draw()
        {
            Clear(this);

            ListPage<Company> selectedCompany = new ListPage<Company>();
            selectedCompany.Add(company);
            selectedCompany.AddColumn("Company Name", "CompanyName");
            selectedCompany.AddColumn("Country", "Land");
            selectedCompany.AddColumn("Currency", "Currency");
            selectedCompany.AddColumn("Vej", "Vej");
            selectedCompany.AddColumn("Husnummer", "Husnummer");
            selectedCompany.AddColumn("Postnummer", "Postnummer");
            selectedCompany.AddColumn("By", "By");

            selectedCompany.Draw();

            ExitOnEscape();
        }
    }
}

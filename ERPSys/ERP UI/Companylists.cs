using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class Companylists : Screen
    {
        public override string Title { get; set; } = "Company List";
        protected override void Draw()
        {
            do
            {
                ListPage<Company> companylist = new();
                companylist.Add(new Company("Company", "Someroad", "5", "9303", "city", "companycountry", Currency.Valuta.DKK));
                companylist.Add(new Company("Company1", "Someroad", "5", "9303", "city", "companycountry1", Currency.Valuta.DKK));
                companylist.Add(new Company("Company2", "Someroad", "5", "9303", "city", "companycountry2", Currency.Valuta.USD));

                //used to tell it what data from the class it should use
                companylist.AddColumn("Company Name", "CompanyName");
                companylist.AddColumn("Country", "Land");
                companylist.AddColumn("Currency", "Currency");


                ExitOnEscape();
                Company selected = companylist.Select();
                if (selected != null)
                {
                    Screen.Display(new SelectedCompany(selected));
                }
                else
                {
                    Quit();
                    return;
                }
            } while (Show);
        }
    }
}

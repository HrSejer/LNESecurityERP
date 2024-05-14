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
        Database database = Database.Instance;
        public override string Title { get; set; } = "Company List";
        protected override void Draw()
        {
            do
            {
                ListPage<Company> companylist = new();

                var companies = database.GetCompanies();
                foreach (Company company in companies)
                {                   
                    companylist.Add(company);
                }
                companylist.AddKey(ConsoleKey.F1, NewCompany);
                Console.WriteLine("Tryk F1 for at lave en ny virksomhed");

                companylist.AddKey(ConsoleKey.F2, editCompany);
                Console.WriteLine("Tryk F2 for at redigere virksomhed");

                //used to tell it what data from the class it should use in the order of
                //displaying name then the Code name
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
        void editCompany(Company company)
        {
            Screen.Display(new EditCompany(company));
        }
        void NewCompany(Company _)
        {
            Company newcompany = new();
            Screen.Display(new EditCompany(newcompany));
        }
    }
}

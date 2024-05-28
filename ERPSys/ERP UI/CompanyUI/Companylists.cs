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
                ExitOnEscape();

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

                companylist.AddKey(ConsoleKey.F5, DeleteCompany);
                Console.WriteLine("Tryk F5 for at fjerne virksomheder");

                //adds ´columns to desplay and the info it shows
                companylist.AddColumn("Company Name", "CompanyName");
                companylist.AddColumn("Country", "Land");
                companylist.AddColumn("Currency", nameof(Company.Money));

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
        
        void DeleteCompany(Company company)
        {
            Database.Instance.DeleteCompany(company);
            Screen.Clear(this);
            Draw();
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

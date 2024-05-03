﻿using ERPSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class ERP_UI : Screen
    {
        //er main menu til vores UI
        public override string Title { get; set; } = "Menu";
        protected override void Draw()
        {
            
            Clear(this);
            Menu menu = new Menu();
            //=====UI referencer====//
            menu.Add(new Companylists());

            //=====UI referencer====//
            menu.Start(this);
        }
    }
    public class Companylists : Screen
    {
        public override string Title { get; set; } = "Company List";
        protected override void Draw()
        {
            do
            {
                ListPage<Company> companylist = new();
                companylist.Add(new Company("Company", "Someroad","5","9303","city","companycountry", "DKK"));
                companylist.Add(new Company("Company1", "Someroad", "5", "9303", "city", "companycountry1", "DKK1"));
                companylist.Add(new Company("Company2", "Someroad", "5", "9303", "city", "companycountry2", "DKK2"));
            
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
            selectedCompany.AddColumn("Husnummer", "Husnummer");
            selectedCompany.AddColumn("Postnummer", "Postnummer");
            selectedCompany.AddColumn("By", "By");

            selectedCompany.Draw();

            ExitOnEscape();
        }
    }
}
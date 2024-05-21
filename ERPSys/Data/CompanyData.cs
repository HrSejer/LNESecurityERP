using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;
using System.Globalization;

namespace ERPSys
{
    public partial class Database
    {
        //TEST DATA Premade Data
        List<Company> companylist = new()
        {
            new Company{Id = 1,CompanyName = "Company1",Land = "companycountry1",By = "city1",Vej = "Someroad1",Husnummer = "5",Postnummer = "9303",Currency = Currency.Valuta.DKK },
            new Company{Id = 2,CompanyName = "Company2",Land = "companycountry2",By = "city2",Vej = "Someroad2",Husnummer = "5",Postnummer = "9303",Currency = Currency.Valuta.DKK },
            new Company{Id = 3,CompanyName = "Company3",Land = "companycountry3",By = "city3",Vej = "Someroad3",Husnummer = "5",Postnummer = "9303",Currency = Currency.Valuta.DKK }
        };

        public List<Company> GetCompanies()
        {
            List<Company> companyCopy = [.. companylist];
            return companyCopy;
        }
        public void UpdateCompany(Company company)
        {
            if (company.Id == 0)
            {
                return;
            }

            for (var i = 0; i < companylist.Count; i++)
            {
                if (companylist[i].Id == company.Id)
                {
                    companylist[i] = company;
                }
            }
        }
        public void InsertCompany(Company company)
        {
            if (company.Id != 0)
            {
                return;
            }
            company.Id = companylist.Count + 1;
            companylist.Add(company);
        }
        public void DeleteCompany(Company company)
        {
            if (company.Id == 0)
            {
                return;
            }
            if (companylist.Contains(company))
            {
                companylist.Remove(company);
            }
        }
    }

}



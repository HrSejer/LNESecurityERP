using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class CompanyData
    {
        //Premade Data
        List<Company> companylist = new()
        {
            new Company{Id = 1,CompanyName = "Company",Vej = "Someroad",Husnummer = "5",Postnummer = "9303",By = "city",Land = "companycountry",Currency = Currency.Valuta.DKK },
            new Company{Id = 2,CompanyName = "Company1",Vej = "Someroad1",Husnummer = "5",Postnummer = "9303",By = "city1",Land = "companycountry1",Currency = Currency.Valuta.DKK  },
            new Company{Id = 3,CompanyName = "Company2",Vej = "Someroad2",Husnummer = "5",Postnummer = "9303",By = "city2",Land = "companycountry2",Currency = Currency.Valuta.USD  }
        };

        public List<Company> GetCompanies()
        {
            List<Company> companyCopy = new();
            companyCopy.AddRange(companylist);
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

    }

}



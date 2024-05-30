using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace ERPSys
{
    public partial class Database
    {
        public List<Company> GetCompanies()
        {
            List<Company> CompanyList = new();
            using (SqlConnection connection = getConnection())
            {
                connection.Open();
                string Query = "SELECT CompanyId, CompanyName, CompanyCountry, CompanyCity, CompanyStreet, CompanyHousnumber, " +
                               "CompanyPostalCode, CompanyCurrency FROM Company";
                using (SqlCommand cmd = new(Query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompanyList.Add(new Company
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CompanyId")),
                                CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                                By = reader.GetString(reader.GetOrdinal("CompanyCity")),
                                Land = reader.GetString(reader.GetOrdinal("CompanyCountry")),
                                Vej = reader.GetString(reader.GetOrdinal("CompanyStreet")),
                                Husnummer = reader.GetString(reader.GetOrdinal("CompanyHousnumber")),
                                Postnummer = reader.GetString(reader.GetOrdinal("CompanyPostalCode")),
                                Money = Enum.Parse<Currency.Valuta>(reader.GetString(reader.GetOrdinal("CompanyCurrency")))
                            });
                        }
                    }
                }
                connection.Close();
            }
            return CompanyList;
        }

        public void UpdateCompany(Company company)
        {
            if (company.Id == 0)
            {
                return;
            }

            using (SqlConnection connection = getConnection())
            {
                connection.Open();
                string sql = "UPDATE Company " +
                             "SET CompanyName = @CompanyName, " +
                                 "CompanyCountry = @CompanyCountry, " +
                                 "CompanyCity = @CompanyCity, " +
                                 "CompanyStreet = @CompanyStreet, " +
                                 "CompanyHousnumber = @CompanyHousnumber, " +
                                 "CompanyPostalCode = @CompanyPostalCode, " +
                                 "CompanyCurrency = @CompanyCurrency " +
                             "WHERE CompanyId = @CompanyId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", company.Id);
                    command.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                    command.Parameters.AddWithValue("@CompanyCountry", company.Land);
                    command.Parameters.AddWithValue("@CompanyCity", company.By);
                    command.Parameters.AddWithValue("@CompanyStreet", company.Vej);
                    command.Parameters.AddWithValue("@CompanyHousnumber", company.Husnummer);
                    command.Parameters.AddWithValue("@CompanyPostalCode", company.Postnummer);
                    command.Parameters.AddWithValue("@CompanyCurrency", company.Money.ToString());

                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertCompany(Company company)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();
                string Query = "INSERT INTO Company (CompanyName, CompanyCountry, CompanyCity, CompanyStreet, CompanyHousnumber, CompanyPostalCode, CompanyCurrency) " +
                             "VALUES (@CompanyName, @CompanyCountry, @CompanyCity, @CompanyStreet, @CompanyHousnumber, @CompanyPostalCode, @CompanyCurrency); " +
                             "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                    command.Parameters.AddWithValue("@CompanyCountry", company.Land);
                    command.Parameters.AddWithValue("@CompanyCity", company.By);
                    command.Parameters.AddWithValue("@CompanyStreet", company.Vej);
                    command.Parameters.AddWithValue("@CompanyHousnumber", company.Husnummer);
                    command.Parameters.AddWithValue("@CompanyPostalCode", company.Postnummer);
                    command.Parameters.AddWithValue("@CompanyCurrency", company.Money.ToString());

                    company.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public void DeleteCompany(Company company)
        {
            if (company.Id == 0)
            {
                return;
            }

            using (SqlConnection connection = getConnection())
            {
                connection.Open();
                string sql = "DELETE FROM Company WHERE CompanyId = @CompanyId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", company.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}



using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public partial class Database
    {
        public List<Kunde> GetKunde()
        {
            List<Kunde> kundeList = new();
            using (SqlConnection connection = getConnection())
            {
                connection.Open();
                string Query = "SELECT " +
                        "p.PersonId, " +
                        "p.Navn, " +
                        "p.Fornavn, " +
                        "p.Efternavn, " +
                        "p.Tlfnummer, " +
                        "p.Mail, " +
                        "a.AddressId, " +
                        "a.Addresser, " +
                        "k.KundeNummer, " +
                        "k.KundeDate " +
                        "FROM Person p " +
                        "INNER JOIN Addresse a ON p.AddressId = a.AddressId " +
                        "INNER JOIN Kunde k ON p.PersonId = k.PersonId";

                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kundeList.Add(new Kunde
                            {
                                PersonId = reader.GetInt32(reader.GetOrdinal("PersonId")),
                                Navn = reader.GetString(reader.GetOrdinal("Navn")),
                                Fornavn = reader.GetString(reader.GetOrdinal("Fornavn")),
                                Efternavn = reader.GetString(reader.GetOrdinal("Efternavn")),
                                Tlfnummer = reader.GetInt32(reader.GetOrdinal("Tlfnummer")),
                                Mail = reader.GetString(reader.GetOrdinal("Mail")),
                                AddressId = reader.GetInt32(reader.GetOrdinal("AddressId")),
                                Addresser = reader.GetString(reader.GetOrdinal("Addresser")),
                                KundeNummer = reader.GetInt32(reader.GetOrdinal("KundeNummer")),
                                Dato = DateTime.Parse(reader.GetString(reader.GetOrdinal("KundeDate")))
                            });
                        }
                    }
                }
                connection.Close();
            }
            return kundeList;
        }

        public void UpdateKunde(Kunde kunde)
        {
            if (kunde.KundeNummer == 0)
            {
                return;
            }

            using (SqlConnection connection = getConnection())
            {
                connection.Open();
                string query =
                    "UPDATE Kunde " +
                    "SET " +
                    "KundeDate = @KundeDate, " +
                    "AddressId = @AddressId, " +
                    "PersonId = @PersonId " +
                    "WHERE " +
                    "KundeNummer = @KundeNummer; " +

                    "UPDATE Person " +
                    "SET " +
                    "Navn = @Navn, " +
                    "Fornavn = @Fornavn, " +
                    "Efternavn = @Efternavn, " +
                    "Tlfnummer = @Tlfnummer, " +
                    "Mail = @Mail " +
                    "WHERE " +
                    "PersonId = @PersonId; " +

                    "UPDATE Addresse " +
                    "SET " +
                    "Addresser = @Addresser " +
                    "WHERE " +
                    "AddressId = @AddressId;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@KundeNummer", kunde.KundeNummer);
                    cmd.Parameters.AddWithValue("@KundeDate", kunde.Dato.ToString());
                    cmd.Parameters.AddWithValue("@AddressId", kunde.AddressId);
                    cmd.Parameters.AddWithValue("@PersonId", kunde.PersonId);
                    cmd.Parameters.AddWithValue("@Navn", kunde.Navn);
                    cmd.Parameters.AddWithValue("@Fornavn", kunde.Fornavn);
                    cmd.Parameters.AddWithValue("@Efternavn", kunde.Efternavn);
                    cmd.Parameters.AddWithValue("@Tlfnummer", kunde.Tlfnummer);
                    cmd.Parameters.AddWithValue("@Mail", kunde.Mail);
                    cmd.Parameters.AddWithValue("@Addresser", kunde.Addresser);

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void InsertKunde(Kunde kunde)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();
                string query = "INSERT INTO Addresse (Addresser)"+
                    "VALUES (@Addresser);"+
                    "SELECT CAST(scope_identity() AS int);";

                int addressId;
                using (SqlCommand cmd = new(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Addresser", kunde.Addresser);
                    addressId = (int)cmd.ExecuteScalar();
                }

                query = "INSERT INTO Person (Navn, Fornavn, Efternavn, Tlfnummer, Mail, AddressId)"+
                    "VALUES (@Navn, @Fornavn, @Efternavn, @Tlfnummer, @Mail, @AddressId);"+
                    "SELECT CAST(scope_identity() AS int);";

                int personId;
                using (SqlCommand cmd = new(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Navn", kunde.Navn);
                    cmd.Parameters.AddWithValue("@Fornavn", kunde.Fornavn);
                    cmd.Parameters.AddWithValue("@Efternavn", kunde.Efternavn);
                    cmd.Parameters.AddWithValue("@Tlfnummer", kunde.Tlfnummer);
                    cmd.Parameters.AddWithValue("@Mail", kunde.Mail);
                    cmd.Parameters.AddWithValue("@AddressId", addressId);
                    personId = (int)cmd.ExecuteScalar();
                }

                query = "INSERT INTO Kunde (KundeDate, AddressId, PersonId)"+
                   "VALUES (@KundeDate, @AddressId, @PersonId);";

                using (SqlCommand cmd = new(query, connection))
                {
                    cmd.Parameters.AddWithValue("@KundeDate", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@AddressId", addressId);
                    cmd.Parameters.AddWithValue("@PersonId", personId);

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DeleteKunde(Kunde kunde)
        {
            if (kunde.KundeNummer == 0)
            {
                return;
            }

            using (SqlConnection connection = getConnection())
            {
                connection.Open();
                string query = @"
                    DELETE FROM Kunde 
                    WHERE KundeNummer = @KundeNummer;

                    DELETE FROM Person 
                    WHERE PersonId = @PersonId;

                    DELETE FROM Addresse 
                    WHERE AddressId = @AddressId;";

                using (SqlCommand cmd = new(query, connection))
                {
                    cmd.Parameters.AddWithValue("@KundeNummer", kunde.KundeNummer);
                    cmd.Parameters.AddWithValue("@PersonId", kunde.PersonId);
                    cmd.Parameters.AddWithValue("@AddressId", kunde.AddressId);

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}

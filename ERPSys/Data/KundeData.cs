using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public partial class Database
    {
        public Kunde KundeId(Kunde KundeId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Kunde WHERE KundeNummer = @KundeNummer";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@KundeNummer", KundeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Kunde kunde = new Kunde
                            {
                                KundeNummer = Convert.ToInt32(reader["KundeNummer"]),
                                Navn = reader["Navn"].ToString()
                            };

                            return KundeId;
                        }
                    }
                }
            }
            return null;
        }
        public void KundeAlle()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT KundeNummer, Navn FROM Kunde";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int kundenummer = reader.GetInt32(reader.GetOrdinal("Varenummer"));
                            string navn = reader.GetString(reader.GetOrdinal("Name"));

                            Kunde kunde = new Kunde
                            {
                                KundeNummer = kundenummer,
                                Navn = navn
                            };

                            Console.WriteLine($"ID: {kunde.KundeNummer}, Name: {kunde.Navn}");
                        }
                    }
                }
            }
        }
        public void indsaetKunde(Kunde kunde)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string Query = "INSERT INTO Kunde VALUES (@Kundenummer)";

                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@Kundenummer", kunde.KundeNummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void OpdaterKunde(Kunde kunde)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Kunde SET Kundenummer = @Kundenummer";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Kundenummer", kunde.KundeNummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SletKunde(Kunde kunde)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Kunde WHERE Kundenummer = @Kundenummer";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Kundenummer", kunde.KundeNummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

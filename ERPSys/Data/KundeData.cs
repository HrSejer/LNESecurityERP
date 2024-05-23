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
        //TEST DATA Premade Data
        List<Kunde> kundelist = new()
        {
            new Kunde(1, "Sombody with", "Sombody", "with", 12345678, "somewhere@some.dk",1,"9120", 1, DateTime.Now),
            new Kunde(2, "Jhon Doe", "Jhon", "Doe", 12345678, "somewhere@some.dk",2,"1234", 2, DateTime.Now),
            new Kunde(3, "Jane Doe", "Jane", "Doe", 12345678, "somewhere@some.dk", 3,"8721", 3, DateTime.Now)
        };

        public List<Kunde> GetKunde()
        {
            List<Kunde> KundeCopy = new();
            KundeCopy.AddRange(kundelist);
            return KundeCopy;
        }
        public void UpdateKunde(Kunde Kunde)
        {
            if (Kunde.KundeNummer == 0)
            {
                return;
            }

            for (var i = 0; i < kundelist.Count; i++)
            {
                if (kundelist[i].KundeNummer == Kunde.KundeNummer)
                {
                    kundelist[i] = Kunde;
                }
            }
        }
        public void InsertKunde(Kunde kunde)
        {
            if (kunde.KundeNummer != 0)
            {
                return;
            }
            kunde.KundeNummer = kundelist.Count + 1;
            kunde.AddressId = kunde.KundeNummer;
            kundelist.Add(kunde);
        }
        public void DeleteKunde(Kunde kunde)
        {
            if (kunde.KundeNummer == 0)
            {
                return;
            }
            if (kundelist.Contains(kunde))
            {
                kundelist.Remove(kunde);
            }
        }
        /*
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
        public void GetKunde()
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
        */
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ERPSys
{
    public partial class Database
    {
        public static Database Instance { get; private set; } = new Database();

        private Database()
        {

        }
        //Salgsordrehoved
        //sorry for any code breaking this will cause but you need to move this and call it
        //using this line of code: Database database = Database.Instance;
        /*
        Salgsordrehoved Salgsordrehoved = new Salgsordrehoved();

        public string ConnectionString { get; set; }
        public Database()
        {
            ConnectionString = "ConnectionString";
        }
        public Salgsordrehoved SalgsordreID(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Salgsordre WHERE Ordrenummer = @Ordrenummer";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Ordrenummer", Salgsordre);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Salgsordrehoved product = new Salgsordrehoved
                            {
                                Ordrenummer = Convert.ToInt32(reader["Ordrenummer"]),
                            };

                            return product;
                        }
                    }
                }
            }
            return null;
        }
        public void SalgsordreAlle()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Salgsordre";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ordrenummer = reader.GetInt32(reader.GetOrdinal("ordrenummer"));

                            Salgsordrehoved Salgsordre = new Salgsordrehoved
                            {
                                Ordrenummer = ordrenummer,
                            };

                            Console.WriteLine($"ID: {Salgsordre.Ordrenummer}");
                        }
                    }
                }
            }
        }
        public void IndsaetSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string Query = "INSERT INTO Salgsordre VALUES (@Ordrenummer)";

                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@Ordrenummer", Salgsordre.Ordrenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void OpdaterSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Salgsordre SET Ordrenummer = @Ordrenummer";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Ordrenummer", Salgsordre.Ordrenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SletSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Salgsordre WHERE Ordrenummer = @Ordrenummer";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SalgsordreId", Salgsordre.Ordrenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Produkt
        public Produkt ProduktId(Produkt ProduktId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Produkt WHERE Varenummer = @Varenummer";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Varenummer", ProduktId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Produkt produkt = new Produkt
                            {
                                Varenummer = Convert.ToInt32(reader["Ordrenummer"]),
                            };

                            return ProduktId;
                        }
                    }
                }
            }
            return null;
        }

        public void ProduktAlle()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Varenummer, Navn FROM Produkt";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int varenummer = reader.GetInt32(reader.GetOrdinal("Varenummer"));
                            string navn = reader.GetString(reader.GetOrdinal("Name"));

                            Produkt produkt = new Produkt
                            {
                                Varenummer = varenummer,
                                Navn = navn
                            };

                            Console.WriteLine($"ID: {produkt.Varenummer}, Name: {produkt.Navn}");
                        }
                    }
                }
            }
        }

        public void IndsaetProdukt(Produkt produkt)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string Query = "INSERT INTO Produkt VALUES (@Varenummer)";

                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@Varenummer", produkt.Varenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void OpdaterProdukt(Produkt produkt)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Produkt SET Varenummer = @Varenummer";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Varenummer", produkt.Varenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SletProdukt(Produkt produkt)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Produkt WHERE Varenummer = @Varenummer";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Varenummer", produkt.Varenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        //Kunde
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
        */
    }
}
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
    public class Database
    {
        //Salgsordrehoved

        Salgsordrehoved Salgsordrehoved = new Salgsordrehoved();

        public Database() 
        {
            
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
        public static void SalgsordreAlle()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Ordrenummer FROM Salgsordre";

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
        public void indsaetSalgsordre(Salgsordrehoved Salgsordre)
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

        public static void ProduktAlle()
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

        public void indsaetProdukt(Produkt produkt)
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
    }
}

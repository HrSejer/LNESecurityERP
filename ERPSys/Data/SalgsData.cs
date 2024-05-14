﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSys
{
    public partial class Database
    {
        Salgsordrehoved Salgsordrehoved = new Salgsordrehoved();

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
    }
}

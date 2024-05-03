using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                string sqlQuery = "SELECT * FROM Ordrenummer WHERE Ordrenummer = @Ordrenummer";

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
        public void SalgordreAlle(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Salgsordre";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        foreach (DataRow row in dt.Rows)
                        {
                            int id = (int)row["ID"];
                            string name = (string)row["Name"];

                            Console.WriteLine($"ID: {id}, Name: {name}");
                        }
                    }
                }
            }
        }

        public void indsaet(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                string Query = "insert into Salgsordre values (@Ordrenummer)";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Ordrenummer", Salgsordre.Ordrenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void OpdaterSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                string query = "Update Salgsordre set where Ordrenummer=@Ordrenummer";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Ordrenummer", Salgsordre.Ordrenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SletSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                string query = "Delete Salgsordre where Ordrenummer=@Ordrenummer";

                using (SqlCommand cmd = new SqlCommand(query, con))
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

                string sqlQuery = "SELECT * FROM Ordrenummer WHERE Ordrenummer = @Ordrenummer";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Ordrenummer", ProduktId);

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
    }
}

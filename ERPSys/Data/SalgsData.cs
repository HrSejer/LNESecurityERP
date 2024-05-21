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
        Salgsordrehoved Salgsordrehoved = new();

        List<Salgsordrehoved> salgsordrehovedlist = new()
        {
            new Salgsordrehoved{Ordrenummer = 1,Dato = DateTime.Now,Kundenummer = 1,Kundenavn = "city1",Ordrebeløb = 1,Tilstand = Tilstand.Færdig },
        };

        public List<Salgsordrehoved> GetSalgsordre()
        {
            List<Salgsordrehoved> salgsordrehovedcopy = new();
            salgsordrehovedcopy.AddRange(salgsordrehovedlist);
            return salgsordrehovedcopy;
        }
        public void UpdateSalgsordrehoved(Salgsordrehoved salgsordrehoved)
        {
            if (salgsordrehoved.Ordrenummer == 0)
            {
                return;
            }

            for (var i = 0; i < salgsordrehovedlist.Count; i++)
            {
                if (salgsordrehovedlist[i].Ordrenummer == salgsordrehoved.Ordrenummer)
                {
                    salgsordrehovedlist[i] = salgsordrehoved;
                }
            }
        }
        public void InsertSalgsordrehoved(Salgsordrehoved salgsordrehoved)
        {
            if (salgsordrehoved.Ordrenummer != 0)
            {
                return;
            }
            salgsordrehoved.Ordrenummer = salgsordrehovedlist.Count + 1;
            salgsordrehovedlist.Add(salgsordrehoved);
        }
        public Salgsordrehoved? SalgsordreID(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = new(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Salgsordre WHERE Ordrenummer = @Ordrenummer";

                using (SqlCommand command = new(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Ordrenummer", Salgsordre);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Salgsordrehoved product = new()
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
            using (SqlConnection connection = new(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Salgsordre";

                using (SqlCommand command = new(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ordrenummer = reader.GetInt32(reader.GetOrdinal("ordrenummer"));

                            Salgsordrehoved Salgsordre = new()
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
            using (SqlConnection connection = new(ConnectionString))
            {
                connection.Open();

                string Query = "INSERT INTO Salgsordre VALUES (@Ordrenummer)";

                using (SqlCommand cmd = new(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@Ordrenummer", Salgsordre.Ordrenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void OpdaterSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = new(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Salgsordre SET Ordrenummer = @Ordrenummer";

                using (SqlCommand cmd = new(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Ordrenummer", Salgsordre.Ordrenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SletSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = new(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Salgsordre WHERE Ordrenummer = @Ordrenummer";

                using (SqlCommand cmd = new(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SalgsordreId", Salgsordre.Ordrenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

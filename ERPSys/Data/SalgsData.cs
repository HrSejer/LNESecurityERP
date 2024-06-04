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
        public Salgsordrehoved? SalgsordreID(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = getConnection())
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
        public List<Salgsordrehoved> SalgsordreAlle()
        {
            List<Salgsordrehoved> salgsordre = new List<Salgsordrehoved>();

            using (SqlConnection connection = getConnection())
            {
                connection.Open();
                string query = "SELECT Ordrenummer, Dato, Kundenummer, Kundenavn, Ordrebeløb, Tilstand, Oprettelsestidspunkt, Gennemførelsestidspunkt FROM Salgsordre";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salgsordre.Add(new Salgsordrehoved
                            {
                                Ordrenummer = reader.GetInt32(reader.GetOrdinal("Ordrenummer")),
                                Dato = DateTime.Parse(reader.GetString(reader.GetOrdinal("Dato"))),                                Kundenummer = reader.GetInt32(reader.GetOrdinal("Kundenummer")),
                                Kundenavn = reader.GetString(reader.GetOrdinal("Kundenavn")),
                                Ordrebeløb = reader.GetDecimal(reader.GetOrdinal("Ordrebeløb")),
                                Tilstand = Enum.TryParse<Tilstand>(reader.GetString(reader.GetOrdinal("Tilstand")), out var tilstand) ? tilstand : default,
                                Oprettelsestidspunkt = DateTime.Parse(reader.GetString(reader.GetOrdinal("Oprettelsestidspunkt"))),
                                Gennemførelsestidspunkt = DateTime.Parse(reader.GetString(reader.GetOrdinal("Gennemførelsestidspunkt"))),
                            });
                        }
                    }
                }
            }

            return salgsordre;
        }
        public void IndsaetSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                string Query = "INSERT INTO Salgsordre (Kundenummer, Dato, Kundenavn, Ordrebeløb, Tilstand, Oprettelsestidspunkt, Gennemførelsestidspunkt)" +
                    "VALUES (@Kundenummer, @Dato, @Kundenavn, @Ordrebeløb, @Tilstand, @Oprettelsestidspunkt, @Gennemførelsestidspunkt)";

                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@Kundenummer", Salgsordre.Kundenummer);
                    cmd.Parameters.AddWithValue("@Dato", Salgsordre.Dato.ToString());
                    cmd.Parameters.AddWithValue("@Kundenavn", Salgsordre.Kundenavn);
                    cmd.Parameters.AddWithValue("@Ordrebeløb", Salgsordre.Ordrebeløb);
                    cmd.Parameters.AddWithValue("@Tilstand", Salgsordre.Tilstand);
                    cmd.Parameters.AddWithValue("@Oprettelsestidspunkt", Salgsordre.Oprettelsestidspunkt.ToString());
                    cmd.Parameters.AddWithValue("@Gennemførelsestidspunkt", Salgsordre.Gennemførelsestidspunkt.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void OpdaterSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                string query = "UPDATE Salgsordre SET Kundenummer = @Kundenummer, Dato = @Dato, Kundenavn = @Kundenavn, Ordrebeløb = @Ordrebeløb, Tilstand = @Tilstand, Oprettelsestidspunkt = @Oprettelsestidspunkt, Gennemførelsestidspunkt = @Gennemførelsestidspunkt  WHERE Ordrenummer = @Ordrenummer";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Ordrenummer", Salgsordre.Ordrenummer);
                        cmd.Parameters.AddWithValue("@Kundenummer", Salgsordre.Kundenummer);
                        cmd.Parameters.AddWithValue("@Dato", Salgsordre.Dato.ToString());
                        cmd.Parameters.AddWithValue("@Kundenavn", Salgsordre.Kundenavn);
                        cmd.Parameters.AddWithValue("@Ordrebeløb", Salgsordre.Ordrebeløb);
                        cmd.Parameters.AddWithValue("@Tilstand", Salgsordre.Tilstand);
                        cmd.Parameters.AddWithValue("@Oprettelsestidspunkt", Salgsordre.Oprettelsestidspunkt.ToString());
                        cmd.Parameters.AddWithValue("@Gennemførelsestidspunkt", Salgsordre.Gennemførelsestidspunkt.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"K Kunne ikke opdatere salgsordre til databasen grundet: {ex.Message}. Venligst tjek om kundenummer er et gyldigt værdi. TRYK ESC FOR AT KOMME TILBAGE TIL SALGSORDRE LIST");
                }
            }
        }

        public void SletSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                string query = "DELETE FROM Salgsordre WHERE Ordrenummer = @Ordrenummer";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Ordrenummer", Salgsordre.Ordrenummer);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

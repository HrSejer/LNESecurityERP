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
                string query = "SELECT OrdreId, Ordrenummer, Dato, Kundenummer, Kundenavn, Ordrebeløb, Tilstand, Oprettelsestidspunkt, Gennemførelsestidspunkt FROM Salgsordre";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salgsordre.Add(new Salgsordrehoved
                             {
                                OrdreId = reader.GetInt32(reader.GetOrdinal("OrdreId")),
                                Ordrenummer = reader.GetInt32(reader.GetOrdinal("Ordrenummer")),
                                Dato = reader.GetDateTime(reader.GetOrdinal("Dato")),
                                Kundenummer = reader.GetInt32(reader.GetOrdinal("Kundenummer")),
                                Kundenavn = reader.GetString(reader.GetOrdinal("Kundenavn")),
                                Ordrebeløb = reader.GetDecimal(reader.GetOrdinal("Ordrebeløb")),
                                Tilstand = Enum.TryParse<Tilstand>(reader.GetString(reader.GetOrdinal("Tilstand")), out var tilstand) ? tilstand : default,
                                Oprettelsestidspunkt = reader.GetDateTime(reader.GetOrdinal("Oprettelsestidspunkt")),
                                Gennemførelsestidspunkt = reader.GetDateTime(reader.GetOrdinal("Gennemførelsestidspunkt")),
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

                string Query = "INSERT INTO Salgsordre (Ordrenummer, Dato, Kundenummer, Kundenavn, Ordrebeløb, Tilstand)" + 
                    "VALUES (@Ordrenummer, @Dato, @Kundenummer, @Kundenavn, @Ordrebeløb, @Tilstand)";

                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@Ordrenummer", Salgsordre.Ordrenummer);
                    cmd.Parameters.AddWithValue("@Kundenummer", Salgsordre.Kundenummer);
                    cmd.Parameters.AddWithValue("@Dato", Salgsordre.Dato);
                    cmd.Parameters.AddWithValue("@Kundenavn", Salgsordre.Kundenavn);
                    cmd.Parameters.AddWithValue("@Ordrebeløb", Salgsordre.Ordrebeløb);
                    cmd.Parameters.AddWithValue("@Tilstand", Salgsordre.Tilstand);
                    cmd.Parameters.AddWithValue("@Oprettelsestidspunkt", Salgsordre.Oprettelsestidspunkt);
                    cmd.Parameters.AddWithValue("@Gennemførelsestidspunkt", Salgsordre.Gennemførelsestidspunkt);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void OpdaterSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                string query = "UPDATE Salgsordre SET Ordrenummer = @Ordrenummer, Kundenummer = @Kundenummer, Dato = @Dato, Kundenavn = @Kundenavn, Ordrebeløb = @Ordrebeløb, Tilstand = @Tilstand, Oprettelsestidspunkt = @Oprettelsestidspunkt, Gennemførelsestidspunkt = @Gennemførelsestidspunkt  WHERE OrdreId = @OrdreId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@OrdreId", Salgsordre.OrdreId);
                    cmd.Parameters.AddWithValue("@Ordrenummer", Salgsordre.Ordrenummer);
                    cmd.Parameters.AddWithValue("@Kundenummer", Salgsordre.Kundenummer);
                    cmd.Parameters.AddWithValue("@Dato", Salgsordre.Dato);
                    cmd.Parameters.AddWithValue("@Kundenavn", Salgsordre.Kundenavn);
                    cmd.Parameters.AddWithValue("@Ordrebeløb", Salgsordre.Ordrebeløb);
                    cmd.Parameters.AddWithValue("@Tilstand", Salgsordre.Tilstand);
                    cmd.Parameters.AddWithValue("@Oprettelsestidspunkt", Salgsordre.Oprettelsestidspunkt);
                    cmd.Parameters.AddWithValue("@Gennemførelsestidspunkt", Salgsordre.Gennemførelsestidspunkt);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SletSalgsordre(Salgsordrehoved Salgsordre)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                string query = "DELETE FROM Salgsordre WHERE OrdreId = @OrdreId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@OrdreId", Salgsordre.OrdreId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

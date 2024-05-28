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
        //note here was a NULL warning may be Null
        public Produkt? ProduktId(Produkt ProduktId)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Produkt WHERE ProduktId = @ProduktId";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProduktId", ProduktId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Produkt produkt = new Produkt
                            {
                                ProduktId = Convert.ToInt32(reader["ProduktId"]),
                            };

                            return ProduktId;
                        }
                    }
                }
            }
            return null;
        }

        public List<Produkt> GetAllProdukter()
        {
            List<Produkt> produkter = new List<Produkt>();

            using (SqlConnection connection = getConnection())
            {
                connection.Open();
                string query = "SELECT ProduktId, Varenummer, Navn, Beskrivelse, Salgspris, Indkoebspris, Lokation, Antalpaalager, Enhed, Avance, Fortjeneste FROM Produkt";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produkter.Add(new Produkt
                            {
                                ProduktId = reader.GetInt32(reader.GetOrdinal("ProduktId")),
                                Varenummer = reader.GetInt32(reader.GetOrdinal("Varenummer")),
                                Navn = reader.GetString(reader.GetOrdinal("Navn")),
                                Beskrivelse = reader.GetString(reader.GetOrdinal("Beskrivelse")),
                                Salgspris = reader.GetDecimal(reader.GetOrdinal("Salgspris")),
                                Indkoebspris = reader.GetDecimal(reader.GetOrdinal("Indkoebspris")),
                                Lokation = reader.GetString(reader.GetOrdinal("Lokation")),
                                Antalpaalager = reader.GetDecimal(reader.GetOrdinal("Antalpaalager")),
                                Enhed = Enum.TryParse<Enhed>(reader.GetString(reader.GetOrdinal("Enhed")), out var enhed) ? enhed : default,
                                Avance = reader.GetDecimal(reader.GetOrdinal("Avance")),
                                Fortjeneste = reader.GetDecimal(reader.GetOrdinal("Fortjeneste")),
                            });
                        }
                    }
                }
            }

            return produkter;
        }

        public void IndsaetProdukt(Produkt produkt)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                string Query = "INSERT INTO Produkt (Varenummer, Navn, Beskrivelse, Salgspris, Indkoebspris, Lokation, Antalpaalager, Enhed, Avance, Fortjeneste)" 
                    + " VALUES (@Varenummer, @Navn, @Beskrivelse, @Salgspris, @Indkoebspris, @Lokation, @Antalpaalager, @Enhed, @Avance, @Fortjeneste)";

                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@Varenummer", produkt.Varenummer);
                    cmd.Parameters.AddWithValue("@Navn", produkt.Navn);
                    cmd.Parameters.AddWithValue("@Beskrivelse", produkt.Beskrivelse);
                    cmd.Parameters.AddWithValue("@Salgspris", produkt.Salgspris);
                    cmd.Parameters.AddWithValue("@Indkoebspris", produkt.Indkoebspris);
                    cmd.Parameters.AddWithValue("@Lokation", produkt.Lokation);
                    cmd.Parameters.AddWithValue("@Antalpaalager", produkt.Antalpaalager);
                    cmd.Parameters.AddWithValue("@Enhed", produkt.Enhed);
                    cmd.Parameters.AddWithValue("@Avance", produkt.Avance);
                    cmd.Parameters.AddWithValue("@Fortjeneste", produkt.Fortjeneste);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void OpdaterProdukt(Produkt produkt)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                string query = "UPDATE Produkt SET Varenummer = @Varenummer, Navn = @Navn, Beskrivelse = @Beskrivelse, Salgspris = @Salgspris, Indkoebspris = @Indkoebspris, Lokation = @Lokation, Antalpaalager = @Antalpaalager, Enhed = @Enhed, Avance = @Avance, Fortjeneste = @Fortjeneste WHERE ProduktId = @ProduktId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProduktId", produkt.ProduktId);
                    cmd.Parameters.AddWithValue("@Varenummer", produkt.Varenummer);
                    cmd.Parameters.AddWithValue("@Navn", produkt.Navn);
                    cmd.Parameters.AddWithValue("@Beskrivelse", produkt.Beskrivelse);
                    cmd.Parameters.AddWithValue("@Salgspris", produkt.Salgspris);
                    cmd.Parameters.AddWithValue("@Indkoebspris", produkt.Indkoebspris);
                    cmd.Parameters.AddWithValue("@Lokation", produkt.Lokation);
                    cmd.Parameters.AddWithValue("@Antalpaalager", produkt.Antalpaalager);
                    cmd.Parameters.AddWithValue("@Enhed", produkt.Enhed);
                    cmd.Parameters.AddWithValue("@Avance", produkt.Avance);
                    cmd.Parameters.AddWithValue("@Fortjeneste", produkt.Fortjeneste);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SletProdukt(Produkt produkt)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                string query = "DELETE FROM Produkt WHERE ProduktId = @ProduktId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProduktId", produkt.ProduktId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


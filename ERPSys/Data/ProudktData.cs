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
        //note here was a NULL warning may be Null
        public Produkt? ProduktId(Produkt ProduktId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
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

        public void ProduktAlle()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT ProduktId, Navn FROM Produkt";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int produktId = reader.GetInt32(reader.GetOrdinal("ProduktId"));
                            string navn = reader.GetString(reader.GetOrdinal("Name"));

                            Produkt produkt = new Produkt
                            {
                                ProduktId = produktId,
                                Navn = navn
                            };

                            Console.WriteLine($"ID: {produkt.ProduktId}, Name: {produkt.Navn}");
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

                string Query = "INSERT INTO Produkt VALUES (@ProduktId)";

                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProduktId", produkt.ProduktId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void OpdaterProdukt(Produkt produkt)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Produkt SET ProduktId = @ProdukId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProduktId", produkt.ProduktId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SletProdukt(Produkt produkt)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
        public List<Produkt> GetProdukt()
        {
            List<Produkt> produktCopy = new();
            produktCopy.AddRange(produktlist);
            return produktCopy;
        }

        List<Produkt> produktlist = new()
        {
            new Produkt{ProduktId = 1, Varenummer = 1, Navn = "Computer", Beskrivelse = "Kan Spille", Salgspris = 2500, Indkoebspris = 9999, Lokation = "ff3g", Antalpaalager = 2, Enhed = Enhed.Styk, Avance = 25, Fortjeneste = 2000 }
        };
        public void UpdateProdukt(Produkt produkt)
        {
            if (produkt.ProduktId == 0)
            {
                return;
            }

            for (var i = 0; i < produktlist.Count; i++)
            {
                if (produktlist[i].ProduktId == produkt.ProduktId)
                {
                    produktlist[i] = produkt;
                }
            }
        }
        public void InsertProdukt(Produkt produkt)
        {
            if (produkt.ProduktId != 0)
            {
                return;
            }
            produkt.ProduktId = produktlist.Count + 1;
            produktlist.Add(produkt);
        }

        public void DeleteProdukt(Produkt produkt)
        {
            if (produkt.ProduktId == 0)
            {
                return;
            }
            if (produktlist.Contains(produkt))
            {
                produktlist.Remove(produkt);
            }
        }
    }
}


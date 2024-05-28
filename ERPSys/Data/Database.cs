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
        public string ConnectionString { get; set; }

        public static Database Instance { get; private set; } = new Database();

        private Database()
        {
            ConnectionString = "Connectionstring";
        }
        private SqlConnection getConnection()
        {
            SqlConnectionStringBuilder sb = new();
            sb.DataSource = "docker.data.techcollege.dk";
            sb.InitialCatalog = "H1PD040124_Gruppe2";
            sb.UserID = "H1PD040124_Gruppe2";
            sb.Password = "H1PD040124_Gruppe2";
            string connectionString = sb.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
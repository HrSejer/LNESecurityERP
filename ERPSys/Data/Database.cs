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
    }
}
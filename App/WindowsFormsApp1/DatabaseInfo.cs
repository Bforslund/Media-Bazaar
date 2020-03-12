using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class DatabaseInfo
    {
        public static string connectionString = "Server=studmysql01.fhict.local;Uid=dbi432004;Database=dbi432004;Pwd=Password;";

        public static MySqlConnection sqlConnection = new MySqlConnection(connectionString);
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden_Glory.Database
{
    class DB
    {
        private string conn_str = @"Data Source=JEKLAPPY\JEK;Initial Catalog=""Garden Glory"";Integrated Security=True";
        private static DB _Instance = new DB();
        static SqlConnection cnn;
        private DB()
        {
            cnn = new SqlConnection(conn_str);
            cnn.Open();
        }

        public static SqlConnection Connection()
        {
            return cnn;
        }
    }
}

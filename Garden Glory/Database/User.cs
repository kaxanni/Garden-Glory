using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden_Glory.Database
{
    enum UserRole
    {
        Administrator = 332,
        Administrative_Assistant,
        Mangement
    }

    class User
    {
        public static string Username { get; private set; }
        public static string AccountID { get; private set; }
        public static UserRole UserRole { get;  set; }

        public static bool login(string username, string password)
        {
            var query = $"SELECT * FROM Account WHERE Username='{username}' AND Password='{password}';";
            SqlCommand sqlCommand = new SqlCommand(query, DB.Connection());

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            if(dt.Rows.Count >= 1)
            {
                Username = username;
                AccountID = dt.Rows[0]["AccountID"].ToString();
                if (dt.Rows[0]["RoleType"].ToString() == "Manager")
                {
                    UserRole = UserRole.Mangement;
                }
                else if(dt.Rows[0]["RoleType"].ToString() == "Assistant")
                {
                    UserRole = UserRole.Administrative_Assistant;
                }
                else if (dt.Rows[0]["RoleType"].ToString() == "Administrator")
                {
                    UserRole = UserRole.Administrator;
                }
                return true;
            }

            return false;
        }

    }
}

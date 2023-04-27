using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Garden_Glory.Database
{
    class Query
    {
        private SqlDataAdapter adapter;

        public Query()
        {
            adapter = new SqlDataAdapter();
        }

        public string Add(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, DB.Connection());
            var res = 0;
            try
            {
                res = sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid data!");
                return "";
            }

            if(res < 1)
            {
                MessageBox.Show("Can not insert the rows!", "Insert Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            query = "SELECT SCOPE_IDENTITY()";
            sqlCommand = new SqlCommand(query, DB.Connection());
            string id = "0";

            try
            {
                id = sqlCommand.ExecuteScalar().ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid data!");
                return "0";
            }
            return id;
        }

        public DataTable GetAllData(string table) {
            var query = $"SELECT * FROM {table};";
            SqlCommand sqlCommand = new SqlCommand(query, DB.Connection());
            adapter.SelectCommand = sqlCommand;

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            return dt;
        }

        public void Delete(string query)
        {
            
            SqlCommand sqlCommand = new SqlCommand(query, DB.Connection());
            var res = 0;

            try
            {
                res = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid data!");
                return ;
            }

            if (res < 1)
            {
                MessageBox.Show("Can not insert the rows!", "Insert Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Edit(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, DB.Connection());
            var res = 0;

            try
            {
                res = sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid data!");
                return;
            }

            if (res < 1)
            {
                MessageBox.Show("Can not insert the rows!", "Insert Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

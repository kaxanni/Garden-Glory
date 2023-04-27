using Garden_Glory.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Garden_Glory.Views
{
    /// <summary>
    /// Interaction logic for Account_Personal.xaml
    /// </summary>
    public partial class Account_Personal : Page
    {
        public Account_Personal()
        {
            InitializeComponent();

            var query = $"SELECT * FROM Account WHERE AccountID='{User.AccountID}';";
            SqlCommand sqlCommand = new SqlCommand(query, DB.Connection());

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            username.Text = dt.Rows[0]["Username"].ToString();
            password.Text = dt.Rows[0]["Password"].ToString();

        }

        private void save_click(object sender, RoutedEventArgs e)
        {
            if(username.Text == String.Empty || password.Text == String.Empty)
            {
                MessageBox.Show("Username or Password is empty!");
                return;
            }
            var query = $"UPDATE Account SET Username='{username.Text}', Password='{password.Text}' WHERE AccountID = { User.AccountID }";
            SqlCommand sqlCommand = new SqlCommand(query, DB.Connection());
            var res = sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Data save sucessfully!");
        }
    }
}

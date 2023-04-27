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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            var query = $"SELECT * FROM Employee JOIN Account ON Employee.EmployeeID=Account.EmployeeID WHERE AccountID = '{User.AccountID}'";
            SqlCommand sqlCommand = new SqlCommand(query, DB.Connection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            username_tb.Text = dt.Rows[0]["Username"].ToString();
            role_tb.Text = dt.Rows[0]["RoleType"].ToString();
            firstName_tb.Text = dt.Rows[0]["FirstName"].ToString();
            lastName_tb.Text = dt.Rows[0]["LastName"].ToString();
            phone_tb.Text = dt.Rows[0]["CellPhone"].ToString();
            experience_tb.Text = dt.Rows[0]["ExperienceLevel"].ToString();
            totalHours_tb.Text = dt.Rows[0]["TotalHourWorked"].ToString();
            type_tb.Text = dt.Rows[0]["EmployeeType"].ToString();
            status_tb.Text = dt.Rows[0]["EmployeeStatus"].ToString();

        }
    }
}

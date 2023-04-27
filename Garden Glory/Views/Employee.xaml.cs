using Garden_Glory.Database;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Page
    {
        Database.Query database;
        DataTable dt;
        DataRowView dr;
        public Employee()
        {
            InitializeComponent();
            database = new Database.Query();
            dt = database.GetAllData("Employee");
            datagrid_customer.ItemsSource = dt.DefaultView;
            dr = null;

            if (User.UserRole == UserRole.Administrative_Assistant)
            {
                delete_btn.IsEnabled = false;
            }

            if (User.UserRole != UserRole.Administrator)
            {
                supervisor_type.IsEnabled = false;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO Employee(FirstName, LastName, CellPhone, ExperienceLevel, TotalHourWorked, EmployeeType, EmployeeStatus) VALUES('{first_name.Text}', '{last_name.Text}', '{number.Text}', '{experience.Text}','{totalHoursWorked.Text}','{type.Text}','{status.Text}');";
            string id = database.Add(query);

            dt.Rows.Add(new object[] { $"{id}",  first_name.Text , last_name.Text , number.Text , experience.Text , totalHoursWorked.Text , type.Text , status.Text  });

            Helper.clearAll(this);
        }

        private void row_selected(object sender, SelectionChangedEventArgs e)
        {

            DataGrid dg = (DataGrid)sender;
            dr = (DataRowView)dg.SelectedItem;

            if (dr == null)
            {
                return;
            }

            first_name.Text = dr[1].ToString();
            last_name.Text = dr[2].ToString();
            number.Text = dr[3].ToString();
            experience.Text = dr[4].ToString();
            totalHoursWorked.Text = dr[5].ToString();
            type.Text = dr[6].ToString();
            status.Text = dr[7].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }
            var query = $"DELETE FROM Employee WHERE EmployeeID={dr[0]}";
            database.Delete(query);
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }


            var query = $"UPDATE Employee SET FirstName='{first_name.Text}', LastName='{last_name.Text}', CellPhone='{number.Text}', ExperienceLevel='{experience.Text}', TotalHourWorked='{totalHoursWorked.Text}', EmployeeType='{type.Text}', EmployeeStatus='{status.Text}' WHERE EmployeeID={dr[0]}";

            database.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", first_name.Text, last_name.Text, number.Text, experience.Text, totalHoursWorked.Text, type.Text, status.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

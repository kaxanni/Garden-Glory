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
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        Database.Query database;
        DataTable dt;
        DataRowView dr;
        public Account()
        {
            InitializeComponent();
            database = new Database.Query();
            dt = database.GetAllData("Account");
            datagrid_customer.ItemsSource = dt.DefaultView;
            var comboDt = database.GetAllData("Employee");
            employeeId.ItemsSource = comboDt.DefaultView;
            dr = null;
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO Account(RoleType, Username, Password, EmployeeID) VALUES('{role.Text}', '{username.Text}', '{password.Text}', '{employeeId.Text}');";
            string id = database.Add(query);

            dt.Rows.Add(new object[] { $"{id}", role.Text, username.Text, password.Text, employeeId.Text });

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

            role.Text = dr[1].ToString();
            username.Text = dr[2].ToString();
            password.Text = dr[3].ToString();
            employeeId.Text = dr[4].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }
            var query = $"DELETE FROM Account WHERE AccountID={dr[0]}";
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


            var query = $"UPDATE Account SET RoleType='{role.Text}', Username='{username.Text}', Password='{password.Text}', EmployeeID='{employeeId.Text}' WHERE AccountID={dr[0]}";

            database.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", role.Text, username.Text, password.Text, employeeId.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

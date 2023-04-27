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
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class Task : Page
    {
        Database.Query database;
        DataTable dt;
        DataRowView dr;
        public Task()
        {
            InitializeComponent();
            database = new Database.Query();
            dt = database.GetAllData("Task");
            datagrid_customer.ItemsSource = dt.DefaultView;
            var comboDt = database.GetAllData("Service");
            serviceID.ItemsSource = comboDt.DefaultView;
            var comboDt_Emp = database.GetAllData("Employee");
            employeeID.ItemsSource = comboDt_Emp.DefaultView;
            dr = null;
            if (User.UserRole == UserRole.Administrative_Assistant)
            {
                delete_btn.IsEnabled = false;
                edit_btn.IsEnabled = false;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO Task(EmployeeID, ServiceID, DateConducted, HourseWorked, TaskName) VALUES('{employeeID.Text}', '{serviceID.Text}', '{conductedData.SelectedDate.Value.ToString("yyyy-MM-dd")}', '{hoursWorked.Text}','{name.Text}');";
            string id = database.Add(query);

            dt.Rows.Add(new object[] { $"{id}", employeeID.Text, serviceID.Text, conductedData.Text, hoursWorked.Text, name.Text });

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

            employeeID.Text = dr[1].ToString();
            serviceID.Text = dr[2].ToString();
            conductedData.Text = dr[3].ToString();
            hoursWorked.Text = dr[4].ToString();
            name.Text = dr[5].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }
            var query = $"DELETE FROM Task WHERE TaskID={dr[0]}";
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


            var query = $"UPDATE Task SET EmployeeID='{employeeID.Text}', ServiceID='{serviceID.Text}', DateConducted='{conductedData.SelectedDate.Value.ToString("yyyy-MM-dd")}', HourseWorked='{hoursWorked.Text}', TaskName='{name.Text}' WHERE TaskID={dr[0]}";

            database.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", employeeID.Text, serviceID.Text, conductedData.Text, hoursWorked.Text, name.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

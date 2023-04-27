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
    /// Interaction logic for Trained.xaml
    /// </summary>
    public partial class Trained : Page
    {
        Database.Query database;
        DataTable dt;
        DataRowView dr;
        public Trained()
        {
            InitializeComponent();
            database = new Database.Query();
            dt = database.GetAllData("TrainedEmployee");
            datagrid_customer.ItemsSource = dt.DefaultView;
            var comboDt = database.GetAllData("Employee");
            EmployeeID.ItemsSource = comboDt.DefaultView;
            var comboDt_task = database.GetAllData("Equipment");
            EquipmentID.ItemsSource = comboDt_task.DefaultView;
            dr = null;

            if (User.UserRole == UserRole.Administrative_Assistant)
            {
                delete_btn.IsEnabled = false;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO TrainedEmployee(EmployeeID,EquipmentID) VALUES('{EmployeeID.Text}', '{EquipmentID.Text}');";
            string id = database.Add(query);

            dt.Rows.Add(new object[] { $"{id}", EmployeeID.Text, EquipmentID.Text });

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

            EmployeeID.Text = dr[1].ToString();
            EquipmentID.Text = dr[2].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }
            var query = $"DELETE FROM TrainedEmployee WHERE TrainedEmployeeID={dr[0]}";
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


            var query = $"UPDATE TrainedEmployee SET EmployeeID='{EmployeeID}',EquipmentID='{EquipmentID}' WHERE TrainedEmployeeID={dr[0]}";

            database.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", EmployeeID.Text, EquipmentID.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

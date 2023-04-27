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
    /// Interaction logic for EquipmentUsage.xaml
    /// </summary>
    public partial class EquipmentUsage : Page
    {
        Database.Query database;
        DataTable dt;
        DataRowView dr;
        public EquipmentUsage()
        {
            InitializeComponent();
            database = new Database.Query();
            dt = database.GetAllData("EquipmentUsage");
            datagrid_customer.ItemsSource = dt.DefaultView;
            var comboDt = database.GetAllData("Equipment");
            EquipmentID.ItemsSource = comboDt.DefaultView;
            var comboDt_task = database.GetAllData("Task");
            TaskID.ItemsSource = comboDt_task.DefaultView;
            dr = null;

            if (User.UserRole == UserRole.Administrative_Assistant)
            {
                delete_btn.IsEnabled = false;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO EquipmentUsage(EquipmentID, TaskID, UsageDescription) VALUES('{EquipmentID.Text}', '{TaskID.Text}', '{usage.Text}');";
            string id = database.Add(query);

            dt.Rows.Add(new object[] { $"{id}", EquipmentID.Text, TaskID.Text, usage.Text });

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

            EquipmentID.Text = dr[1].ToString();
            TaskID.Text = dr[2].ToString();
            usage.Text = dr[3].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }
            var query = $"DELETE FROM EquipmentUsage WHERE EquipmentUsageID={dr[0]}";
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


            var query = $"UPDATE EquipmentUsage SET EquipmentID='{EquipmentID.Text}', TaskID='{TaskID.Text}', UsageDescription='{usage.Text}' WHERE EquipmentUsageID={dr[0]}";

            database.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", EquipmentID.Text, TaskID.Text, usage.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

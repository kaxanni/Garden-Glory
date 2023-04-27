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
    /// Interaction logic for EquipmentRepair.xaml
    /// </summary>
    public partial class EquipmentRepair : Page
    {
        Database.Query database;
        DataTable dt;
        DataRowView dr;
        public EquipmentRepair()
        {
            InitializeComponent();
            database = new Database.Query();
            dt = database.GetAllData("EquipmentRepair");
            datagrid_customer.ItemsSource = dt.DefaultView;
            var comboDt = database.GetAllData("Equipment");
            equipmentID.ItemsSource = comboDt.DefaultView;
            dr = null;

            if (User.UserRole == UserRole.Administrative_Assistant)
            {
                delete_btn.IsEnabled = false;
                edit_btn.IsEnabled = false;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO EquipmentRepair(EquipmentID, DateOfRepair, Amount, Remarks) VALUES('{equipmentID.Text}','{repairDate.SelectedDate.Value.ToString("yyyy-MM-dd")}', '{amount.Text}', '{remarks.Text}');";
            string id = database.Add(query);

            dt.Rows.Add(new object[] { $"{id}", equipmentID.Text, repairDate.Text, amount.Text, remarks.Text });

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

            equipmentID.Text = dr[1].ToString();
            repairDate.Text = dr[2].ToString();
            amount.Text = dr[3].ToString();
            remarks.Text = dr[4].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }
            var query = $"DELETE FROM EquipmentRepair WHERE EquipmentRepairID={dr[0]}";
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


            var query = $"UPDATE EquipmentRepair SET EquipmentID='{equipmentID.Text}', DateOfRepair='{repairDate.SelectedDate.Value.ToString("yyyy-MM-dd")}', Amount='{amount.Text}', Remarks='{remarks.Text}' WHERE EquipmentRepairID={dr[0]}";

            database.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", equipmentID.Text, repairDate.Text, amount.Text, remarks.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

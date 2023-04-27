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
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : Page
    {
        Database.Query database;
        DataTable dt;
        DataRowView dr;
        public Equipment()
        {
            InitializeComponent();
            database = new Database.Query();
            dt = database.GetAllData("Equipment");
            datagrid_customer.ItemsSource = dt.DefaultView;
            dr = null;

            if (User.UserRole == UserRole.Administrative_Assistant)
            {
                delete_btn.IsEnabled = false;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO Equipment(EquipmentName, EqipmentQuantity) VALUES('{name.Text}', '{quantity.Text}');";
            string id = database.Add(query);

            dt.Rows.Add(new object[] { $"{id}", name.Text, quantity.Text });

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

            name.Text = dr[1].ToString();
            quantity.Text = dr[2].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }
            var query = $"DELETE FROM Equipment WHERE EquipmentID={dr[0]}";
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


            var query = $"UPDATE Equipment SET EquipmentName='{name.Text}', EqipmentQuantity='{quantity.Text}' WHERE EquipmentID={dr[0]}";

            database.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", name.Text, quantity.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

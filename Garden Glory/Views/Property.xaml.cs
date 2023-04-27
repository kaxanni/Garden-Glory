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
    /// Interaction logic for Property.xaml
    /// </summary>
    public partial class Property : Page
    {

        Database.Query database;
        DataTable dt;
        DataRowView dr;
        public Property()
        {
            InitializeComponent();
            database = new Database.Query();
            dt = database.GetAllData("Property");
            datagrid_customer.ItemsSource = dt.DefaultView;
            var comboDt = database.GetAllData("Owner");
            ownerId.ItemsSource = comboDt.DefaultView;
            dr = null;

            if (User.UserRole == UserRole.Administrative_Assistant)
            {
                delete_btn.IsEnabled = false;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO Property(PropertyName, Street, city, State ,Zip,OwnerID) VALUES('{name.Text}', '{street.Text}', '{city.Text}', '{state.Text}', '{zip.Text}', '{ownerId.Text}');";
            string id = database.Add(query);

            dt.Rows.Add(new object[] { $"{id}", name.Text, street.Text, city.Text, state.Text, zip.Text, ownerId.Text });

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
            street.Text = dr[2].ToString();
            city.Text = dr[3].ToString();
            state.Text = dr[4].ToString();
            zip.Text = dr[5].ToString();
            ownerId.Text = dr[6].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }
            var query = $"DELETE FROM Property WHERE PropertyID={dr[0]}";
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


            var query = $"UPDATE Property SET PropertyName='{name.Text}', Street='{street.Text}', city='{city.Text}', State='{state.Text}' ,Zip='{zip.Text}',OwnerID='{ownerId.Text}' WHERE PropertyID={dr[0]}";

            database.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", name.Text, street.Text, city.Text, state.Text, zip.Text, ownerId.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

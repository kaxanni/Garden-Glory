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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        Database.Query customer_db;
        DataTable dt;
        DataRowView dr;
        public Customer()
        {
            InitializeComponent();
            customer_db= new Database.Query();
            dt = customer_db.GetAllData("Owner");
            datagrid_customer.ItemsSource = dt.DefaultView;
            dr = null;

            if(User.UserRole == UserRole.Administrative_Assistant)
            {
                delete_btn.IsEnabled = false;
            }
        }

       

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO Owner(OwnerName, OwnerEmail, OwnerPhone, OwnerType) VALUES('{first_name.Text + " " + last_name.Text}', '{email.Text}', '{number.Text}', '{type.Text}');";
            string id = customer_db.Add(query);

            dt.Rows.Add(new object[] { $"{id}",$"{first_name.Text + " " + last_name.Text}", email.Text, type.Text, number.Text });

            Helper.clearAll(this);
        }

        private void row_selected(object sender, SelectionChangedEventArgs e)
        {
            
            DataGrid dg = (DataGrid)sender;
            dr = (DataRowView)dg.SelectedItem;

            if(dr == null)
            {
                return;
            }

            string name = dr[1].ToString();
            if (name != string.Empty && name != null)
            {
                string[] names = name.Split(' ');
                first_name.Text = names[0];
                last_name.Text = names[1];
            }

            email.Text = dr[2].ToString();
            type.Text = dr[3].ToString();
            number.Text = dr[4].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if(dr == null)
            {
                return;
            }
            var query = $"DELETE FROM Owner WHERE OwnerID={dr[0]}";
            customer_db.Delete(query);
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }


            var query = $"UPDATE Owner SET OwnerName='{first_name.Text + " " + last_name.Text}', OwnerEmail='{email.Text}', OwnerPhone='{number.Text}', OwnerType='{type.Text}' WHERE OwnerID={dr[0]}";

            customer_db.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", $"{first_name.Text + " " + last_name.Text}", email.Text, type.Text, number.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

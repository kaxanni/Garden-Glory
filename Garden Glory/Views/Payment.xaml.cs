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
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Page
    {
        Database.Query database;
        DataTable dt;
        DataRowView dr;
        public Payment()
        {
            InitializeComponent();
            database = new Database.Query();
            dt = database.GetAllData("Payment");
            datagrid_customer.ItemsSource = dt.DefaultView;
            var comboDt = database.GetAllData("Service");
            serviceID.ItemsSource = comboDt.DefaultView;
            dr = null;

            if (User.UserRole == UserRole.Administrative_Assistant)
            {
                delete_btn.IsEnabled = false;
                edit_btn.IsEnabled = false;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO Payment(ServiceID, PaymentMethod, PaymentDate, PaymentAmount) VALUES('{serviceID.Text}', '{paymentType.Text}', '{paymentDate.SelectedDate.Value.ToString("yyyy-MM-dd")}', '{amount.Text}');";
            string id = database.Add(query);

            dt.Rows.Add(new object[] { $"{id}", serviceID.Text, paymentType.Text, paymentDate.Text, amount.Text });

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

            serviceID.Text = dr[1].ToString();
            paymentType.Text = dr[2].ToString();
            paymentDate.Text = dr[3].ToString();
            amount.Text = dr[4].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }
            var query = $"DELETE FROM Payment WHERE PaymentID={dr[0]}";
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


            var query = $"UPDATE Payment SET ServiceID='{serviceID.Text}', PaymentMethod='{paymentType.Text}', PaymentDate='{paymentDate.SelectedDate.Value.ToString("yyyy-MM-dd")}', PaymentAmount='{amount.Text}' WHERE PaymentID={dr[0]}";

            database.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", serviceID.Text, paymentType.Text, paymentDate.Text, amount.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

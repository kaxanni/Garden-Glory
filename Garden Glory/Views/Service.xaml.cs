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
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : Page
    {
        Database.Query database;
        DataTable dt;
        DataRowView dr;
        public Service()
        {
            InitializeComponent();
            database = new Database.Query();
            dt = database.GetAllData("Service");
            datagrid_customer.ItemsSource = dt.DefaultView;
            var comboDt = database.GetAllData("Property");
            propertyId.ItemsSource = comboDt.DefaultView;
            dr = null;

            if (User.UserRole == UserRole.Administrative_Assistant)
            {
                delete_btn.IsEnabled = false;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            var query = $"INSERT INTO Service(RequestDate, ServiceRequest, RequestType, PropertyID) VALUES('{requestDate.SelectedDate.Value.ToString("yyyy-MM-dd")}', '{serviceRequest.Text}', '{serviceType.Text}', '{propertyId.Text}');";
            string id = database.Add(query);

            dt.Rows.Add(new object[] { $"{id}", requestDate.Text, serviceRequest.Text, propertyId.Text, serviceType.Text });

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

            requestDate.Text = dr[1].ToString();
            serviceRequest.Text = dr[2].ToString();
            propertyId.Text = dr[3].ToString();
            serviceType.Text = dr[4].ToString();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                return;
            }
            var query = $"DELETE FROM Service WHERE ServiceID={dr[0]}";
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


            var query = $"UPDATE Service SET RequestDate='{requestDate.SelectedDate.Value.ToString("yyyy-MM-dd")}', ServiceRequest='{serviceRequest.Text}', RequestType='{serviceType.Text}', PropertyID='{propertyId.Text}' WHERE ServiceID={dr[0]}";

            database.Edit(query);
            dt.Rows.Add(new object[] { $"{dr[0]}", requestDate.Text, serviceRequest.Text, propertyId.Text, serviceType.Text });
            dt.Rows.Remove(dr.Row);
            Helper.clearAll(this);
        }
    }
}

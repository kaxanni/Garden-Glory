using Garden_Glory.Database;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Garden_Glory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            updateNevigation();
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;

            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private void customer_selected(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/Customer.xaml",UriKind.Relative);
        }

        private void emplyee_selected(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/Employee.xaml", UriKind.Relative);
        }

        private void equipment_selected(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/Equipment.xaml", UriKind.Relative);
        }

        private void equipment_repair_selected(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/EquipmentRepair.xaml", UriKind.Relative);
        }

        private void equipment_usage_selected(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/EquipmentUsage.xaml", UriKind.Relative);
        }

        private void property_selected(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/Property.xaml", UriKind.Relative);
        }

        private void service_selected(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/Service.xaml", UriKind.Relative);
        }

        private void task_selected(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/Task.xaml", UriKind.Relative);
        }

        private void payment_selected(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/Payment.xaml", UriKind.Relative);
        }

        private void account_selected(object sender, RoutedEventArgs e)
        {
            if(User.UserRole == UserRole.Administrator)
            {
                navigation_frame.Source = new Uri(@"Views/Account.xaml", UriKind.Relative);
            }
            else
            {
                navigation_frame.Source = new Uri(@"Views/Account_Personal.xaml", UriKind.Relative);
            }
            
        }

        private void back_btn_click(object sender, RoutedEventArgs e)
        {
            navigation_frame.GoBack();
            
        }

        private void fwd_btn_click(object sender, RoutedEventArgs e)
        {
            navigation_frame.GoForward();

        }

        private void navigated_complete(object sender, NavigationEventArgs e)
        {
            updateNevigation();
        }

        private void updateNevigation()
        {
            if (navigation_frame.CanGoBack)
            {
                back_btn.IsEnabled = true;
            }
            else
            {
                back_btn.IsEnabled = false;
            }

            if (navigation_frame.CanGoForward)
            {
                fwd_btn.IsEnabled = true;
            }
            else
            {
                fwd_btn.IsEnabled = false;
            }
        }

        private void home_click(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/Home.xaml", UriKind.Relative);
        }

        private void logout_click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void trainedemplyee_selected(object sender, RoutedEventArgs e)
        {
            navigation_frame.Source = new Uri(@"Views/Trained.xaml", UriKind.Relative);
        }
    }
}

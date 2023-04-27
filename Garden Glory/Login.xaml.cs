using Garden_Glory.Database;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Garden_Glory
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_click(object sender, RoutedEventArgs e)
        {
            if(username.Text == String.Empty || password.Password == String.Empty)
            {
                MessageBox.Show("Username or Password is empty!");
                return;
            }

            var res = User.login(username.Text, password.Password);

            if (res)
            {
                MainWindow win = new MainWindow();
                win.Show();
                this.Close();
                return;
            }

            MessageBox.Show("Username or Password is not correct!");
        }
    }
}

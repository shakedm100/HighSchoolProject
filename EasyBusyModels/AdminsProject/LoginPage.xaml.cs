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
using System.Windows.Navigation;
using System.Windows.Shapes;

using EasyBusyModels;
using EasyBusyViewModel;

namespace AdminsProject
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            //newAdminButton.BorderBrush.Opacity = 0;
            //newAdminButton.Background.Opacity = 0;
        }

        ClientDB clientdb = new ClientDB();

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            Client client = clientdb.SelectByName(userNameTextBox.Text, Password.Password);

            if(client != null)
            {
                MainWindow.Frame.Navigate(new HomePage());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Frame.Navigate(new RegisterPage());
        }
    }
}

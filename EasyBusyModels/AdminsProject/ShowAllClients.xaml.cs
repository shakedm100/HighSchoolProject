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
    /// Interaction logic for ShowAllClients.xaml
    /// </summary>
    public partial class ShowAllClients : Page
    {
        ClientDB clientDB = new ClientDB();

        public ShowAllClients()
        {
            InitializeComponent();

            Client client = new Client();
            //client.Taz

            ClientList clientList = clientDB.SelectAll();

            clientsListView.ItemsSource = clientList;
        
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Client client = (Client)clientsListView.SelectedItem;
            MainWindow.Frame.Navigate(new UpdateClientsPage(client));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Client client = (Client)clientsListView.SelectedItem;
            Window warning = new WarningWindow("Are you sure you want to delete: "+client.Username, client, clientDB);
            warning.Show();
        }
    }
}

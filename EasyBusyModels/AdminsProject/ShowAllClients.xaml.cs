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

        ClientList clientList = new ClientList();

        public ShowAllClients()
        {
            InitializeComponent();

            Client client = new Client();
            //client.Taz

            clientList = clientDB.SelectAll();

            clientsListView.ItemsSource = clientList;
        
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Client client = (Client)clientsListView.SelectedItem;
            MainWindow.Frame.Navigate(new UpdateClientsPage(client));
        }

        //private int yesNo = 0;
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Client client = (Client)clientsListView.SelectedItem;
            Window warning = new WarningWindow("Are you sure you want to delete: "+client.Username, client, clientDB);
            warning.Show();

            //if(yesNo == 1)
            //{
            //    //Delete user at client.Username, client.Password
            //    clientDB.Delete(client);
            //}
            //Else yesNo == 0 or -1 so it doesn't delete
        }
    }
}

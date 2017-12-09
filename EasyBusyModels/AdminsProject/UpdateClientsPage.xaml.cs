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
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdateClientsPage : Page
    {
        Client client;

        public UpdateClientsPage(Client client)
        {
            InitializeComponent();

            this.client = client;
            DataContext = client;
            passwordTextBox.Password = client.Password;
        }

        ClientDB clientDB = new ClientDB();

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            clientDB.Update(client);
            ClientDB.SaveChanges();
        }
    }
}

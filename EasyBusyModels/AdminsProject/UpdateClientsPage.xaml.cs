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

            CityDB cityDB = new CityDB();
            KidometDB kidometDB = new KidometDB();

            kidometComboBox.ItemsSource = new List<Kidomet>(kidometDB.SelectAll());
            cityComboBox.ItemsSource = new List<City>(cityDB.SelectAll());

            kidometComboBox.SelectedItem = kidometComboBox.Items[client.Kidomet.ID - 1];
            cityComboBox.SelectedItem = cityComboBox.Items[client.GetSetCity.ID - 1];
        }

        ClientDB clientDB = new ClientDB();

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            client.FirstName = firstNameTextBox.Text;
            client.LastName = lastNameTextBox.Text;
            client.Username = userNameTextBox.Text;
            client.Password = passwordTextBox.Password;
            client.Birthday = DateTime.Parse(birthdayTextBox.Text);
            client.Kidomet = KidometDB.SelectByName(kidometComboBox.SelectedValue.ToString());
            client.PhoneNumber = phoneNumberTextBox.Text;
            client.Taz = TazTextBox.Text;
            client.GetSetCity = CityDB.SelectByName(cityComboBox.SelectedValue.ToString());
            client.Address = addressTextBox.Text;
            client.CreditcardNumber = creditCardNumberTextBox.Text;

            clientDB.Update(client);
            ClientDB.SaveChanges();
        }
    }
}

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
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AdminsProject
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {


        public RegisterPage()
        {
            InitializeComponent();

            CityDB cityDB = new CityDB();
            KidometDB kidometDB = new KidometDB();

            cityComboBox.ItemsSource = new List<City>(cityDB.SelectAll());
            kidometComboBox.ItemsSource = new List<Kidomet>(kidometDB.SelectAll());
        }

        Client client = new Client();

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ClientDB clientDB = new ClientDB();
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
            clientDB.Insert(client);
            ClientDB.SaveChanges();
        }
    }
}

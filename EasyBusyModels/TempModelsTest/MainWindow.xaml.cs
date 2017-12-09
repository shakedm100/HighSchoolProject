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
using EasyBusyViewModel;
using EasyBusyModels;

namespace TempModelsTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ClientDB db = new ClientDB();

        private void tryButton_Click(object sender, RoutedEventArgs e)
        {
            ClientList clientList = db.SelectAll();
            tryTextBox.Text = clientList.Count.ToString();
            tryListBox.ItemsSource = clientList;
        }
    }
}

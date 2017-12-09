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
    /// Interaction logic for ShowAllWorkers.xaml
    /// </summary>
    public partial class ShowAllWorkers : Page
    {
        WorkerDB workerDB;

        public ShowAllWorkers()
        {
            InitializeComponent();

            workerDB = new WorkerDB();

            WorkerList workerList = workerDB.SelectAll();

            //foreach(Worker worker in workerList)
            //{
            //    worker.Birthday = worker.Birthday.ToShortDateString();
            //}

            workersListView.ItemsSource = workerList;
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Worker worker = (Worker)workersListView.SelectedItem;
            MainWindow.Frame.Navigate(new UpdateWorkerPage(worker));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Worker worker = (Worker)workersListView.SelectedItem;
            Window warning = new WarningWindow("Are you sure you want to delete: " + worker.Username, worker, workerDB);
            warning.Show();
        }
    }
}

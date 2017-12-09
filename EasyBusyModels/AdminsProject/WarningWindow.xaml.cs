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

using EasyBusyModels;
using EasyBusyViewModel;

namespace AdminsProject
{
    /// <summary>
    /// Interaction logic for WarningWindow.xaml
    /// </summary>
    public partial class WarningWindow : Window
    {
        //private int yesNo;
        PeopleDB peopleDB;
        Base entity;

        public WarningWindow(String warning,Base entity, PeopleDB peopleDB)
        {
            InitializeComponent();

            warningLabel.Content = warning;
            this.peopleDB = peopleDB;
            this.entity = entity;
            //this.yesNo *= yesNo;
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            ClientDB clientDB = peopleDB as ClientDB;
            if (clientDB != null)
            {
                clientDB.Delete(entity);
                ClientDB.SaveChanges();
            }
            else
            {
                WorkerDB workerDB = peopleDB as WorkerDB;
                if(workerDB != null)
                {
                    workerDB.Delete(entity);
                    WorkerDB.SaveChanges();
                }
            }

            this.Close();
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

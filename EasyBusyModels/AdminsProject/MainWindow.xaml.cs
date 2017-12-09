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

namespace AdminsProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame Frame;

        public MainWindow()
        {
            InitializeComponent();
            Frame = this.frame;
        }

        private void frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (Frame != null && Frame.Content != null && // if Self-Navigation
                Frame.Content.GetType() == e.Content.GetType())
            {
                e.Cancel = true;   //cancel navigation
            }
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            //if (User != null)
            //    this.MenuGrid.Visibility = Visibility.Visible;  // display my-menu Buttons
            //else
            //    this.MenuGrid.Visibility = Visibility.Collapsed;
        }
    }
}

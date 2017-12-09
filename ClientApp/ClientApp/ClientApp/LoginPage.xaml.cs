using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ClientApp.ClientService;

namespace ClientApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        ClientService.Service1Client service;

		public LoginPage ()
		{
			InitializeComponent ();

            service = new Service1Client();

            service.GetClientByUsernameCompleted += GetClientByUsernameAndPassword;
        }

        private void GetClientByUsernameAndPassword(object sender, GetClientByUsernameCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string msg = null;

                if (e.Error != null) { msg = e.Error.Message; }
                else if (e.Cancelled) { msg = "Request was cancelled."; }
                else { msg = e.Result.ToString(); }

                this.usernameEntry.Text = msg;
            });
        }

        private void submitButton_Clicked(object sender, EventArgs e)
        {
            service.GetClientByUsernameAsync(usernameEntry.Text, passwordEntry.Text);
        }
    }
}
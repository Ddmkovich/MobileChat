using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileChat.Classes;
using MobileChat.Modules;
using System.Net;


namespace MobileChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrPage : ContentPage
    {
        string serveradress1 = ServerAddress.srvrAddress;
        public RegistrPage()
        {
            InitializeComponent();
        }

        private async void reg_Clicked(object sender, EventArgs e)
        {
            if (tbPassw.Text==tbRepPassw.Text)
            {
                try
                {
                    string result = WebClientModules.RegisterMethod(tbLogin.Text, tbPassw.Text);
                    await DisplayAlert("Reg", result, "OK");
                    await Navigation.PushModalAsync(new MainPage());
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Check your passwords", "OK");
            }
            
            
        }
    }
}
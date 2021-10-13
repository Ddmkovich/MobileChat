using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileChat.Classes;
using MobileChat.Modules;



namespace MobileChat
{
    public partial class MainPage : ContentPage
    {
        string serveradress1 = ServerAddress.srvrAddress;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLog_Clicked(object sender, EventArgs e)
        {
            try
            {
                string[] _result = WebClientModules.LoginMethod(tbLogin.Text, tbPassword.Text);
                if (_result[0] == "ok")
                {
                    ClassStatus.autorezult = _result[0];
                    ClassStatus.user_id = _result[1];
                    ClassStatus.nick = tbLogin.Text;
                    await Navigation.PushModalAsync(new ChatPage());
                }
                else
                {
                    await DisplayAlert("Error", "Неверный логин или пароль", "Ok");
                }
                
            }
            catch (Exception a)
            {

                await DisplayAlert("Error", a.Message , "Ok");
            }
            
        }
        private async void btnReg_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("nice", "reg", "OK");
            await Navigation.PushModalAsync(new RegistrPage());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileChat.Classes;
using MobileChat.Modules;

namespace MobileChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        string nickSearch;
        string serveradress1 = ServerAddress.srvrAddress;
        List<string> nickN = new List<string>();
        public class getuserdata
        {
            public string id;
            public string nickname;
        }
        public ChatPage()
        {
            InitializeComponent();
        }

        private async void search_Clicked(object sender, EventArgs e)
        {
            nickSearch = await DisplayPromptAsync("Введите ник", "");
            try
            {
                string[] subs = WebClientModules.SearchUserMethod(nickSearch);
                if (subs[0] == "ok")
                {
                    nickN.Add(subs[1] + "\t" + nickSearch);
                    usersList.ItemsSource = nickN;
                    Users.insert(subs[1], nickSearch);
                }
                else
                {
                    await DisplayAlert("Error", "Пользователь не найден...", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error",ex.Message,"Ok");
            }
        }

        private async void back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        private async void change_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ChangeInfo());
        }

        private async void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
                string[] subs = usersList.SelectedItem.ToString().Split('\t');
                await Navigation.PushModalAsync(new MessagePage(subs[0]));  
        }
    }
}
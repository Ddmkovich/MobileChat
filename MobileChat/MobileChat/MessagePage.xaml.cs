using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileChat.Classes;
using MobileChat.Modules;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MobileChat
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        string idMes;
        ObservableCollection<string> messagesList = new ObservableCollection<string>();

        public MessagePage(string id)
        {
            InitializeComponent();
            idMes = id;
            MessageShow();
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    messgRefresh_Refreshing(null,null);
                });
                return true; // runs again, or false to stop
            });

        }
        private async void MessageShow()
        {
                try
                {
                    messagesList.Clear();
                    var _searchAnswer = WebClientModules.ShowMessageMethod(idMes);
                    if (_searchAnswer != null)
                    {
                        foreach (var i in _searchAnswer)
                        {
                            string[] _dateSplit = i.datetime.Split(' ');
                            string _Hours_minutes = _dateSplit[1].Remove(5, 3);

                            messagesList.Add(_Hours_minutes + "\t" + i.nickname + "\t" + i.content);
                            aboba.ItemsSource = messagesList;
                            aboba.ScrollTo(messagesList.Count - 1);


                        }
                    }
                    else
                    {
                        messagesList.Add("No messages");
                        aboba.ItemsSource = messagesList;
                        aboba.ScrollTo(messagesList.Count - 1);
                    }
                }
                catch (Exception ex)
                {

                    await DisplayAlert("lak", ex.Message, "Ok");
                }
        }

        private async void back_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("ok", "back", "back");
            await Navigation.PushModalAsync(new ChatPage());
        }
        private async void change_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("ok", "change", "back");
            await Navigation.PushModalAsync(new ChangeInfo());
        }
        private void send_Clicked(object sender, EventArgs e)
        {
            if (tbMess.Text!=null || tbMess.Text!="")
            {
                string answer = WebClientModules.SendMessageMethod(idMes, tbMess.Text);
                tbMess.Text = null;
                MessageShow();
            }
            
        }

        private void messgRefresh_Refreshing(object sender, EventArgs e)
        {
            MessageShow();  
        }

        private void tbMess_Completed(object sender, EventArgs e)
        {
            send_Clicked(sender,e);
        }
    }
}
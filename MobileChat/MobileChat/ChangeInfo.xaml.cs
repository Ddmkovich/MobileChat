using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeInfo : ContentPage
    {
        public ChangeInfo()
        {
            InitializeComponent();
        }
        
        private void btChangeNick_Clicked(object sender, EventArgs e)
        {
            tbNickname.IsEnabled = true;
        }

        private async void btChangePassw_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("ok", "change", "ok");
            await Navigation.PushModalAsync(new MainPage());
        }

        private async void back_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("ok", "back", "back");
            await Navigation.PushModalAsync(new ChatPage());
        }
    }
}
using HowHigh.MobileApp.Pages;
using HowHigh.Models.Models;
using System.Net.Http.Json;

namespace HowHigh.MobileApp.Pages
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }

        private async void OnLogInClickedAsync(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(PseudoInput.Text))
            {
                PseudoInput.Placeholder = "Pseudo is required";
                PseudoInput.PlaceholderColor = Color.Parse("red");
                return;
            }
            if (String.IsNullOrEmpty(PasswordInput.Text))
            {
                PasswordInput.Placeholder = "Password is required";
                PasswordInput.PlaceholderColor = Color.Parse("red");
                return;
            }
            string pseudo = PseudoInput.Text;
            string password = PasswordInput.Text;

            //https://192.168.1.9:7100/api/
            //http://192.168.1.9:5122/api/
            string apiAdress = "http://192.168.1.9:5122/api/Users/";
            HttpClient sharedClient = new HttpClient();
            HttpResponseMessage response = await sharedClient.GetAsync(apiAdress + "Login?pseudo=" + pseudo + "&password=" + password);

            if (response.IsSuccessStatusCode)
            {
                await Navigation.PushAsync(new TabbedBarPage());
            }
            else
            {
                if ((int)response.StatusCode == 404)
                    await DisplayAlert("Problem", "Account not found.", "OK");
                else
                    await DisplayAlert("Problem", "Internal Server Error, try later.", "OK");
            }
        }

        private void OnSignInClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new SignInPage());
        }

        private void OnLogAsGuestClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedBarPage());
        }
    }
}
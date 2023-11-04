using HowHigh.MobileApp.Views;
using HowHigh.MobileApp.ViewModels;
using HowHigh.Models.Models;
using System.Net.Http.Json;

namespace HowHigh.MobileApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            //BindingContext =  new LoginViewModel();

        }

        private async void OnLogInClickedAsync(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(PseudoInput.Text))
            {
                PseudoInput.Placeholder = "Pseudo is required";
                PseudoInput.PlaceholderColor = Color.Parse("red");
                return;
            }
            //A supprimer ?
            if (PseudoInput.TextColor == Color.Parse("red"))
            {
                await DisplayAlert("Pseudo Invalid", "Please enter valid pseudo", "OK");
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
                await Shell.Current.GoToAsync("///Play");
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
        private async void OnContinueAsGuestClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///Play");
        }
    }
}
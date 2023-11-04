using HowHigh.MobileApp.Views;
using HowHigh.MobileApp.ViewModels;
using HowHigh.Models.Models;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Text.Json;
using Microsoft.Identity.Client;

namespace HowHigh.MobileApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel lvm)
        {
            InitializeComponent();
            BindingContext = lvm;

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
                string responseBody = await response.Content.ReadAsStringAsync();
                Users userConnected = JsonSerializer.Deserialize<Users>(responseBody);
                
                //Preferences.Set("hasAuth", "true");
                Preferences.Set("id", userConnected.id);

                //await SecureStorage.Default.SetAsync("hasAuth", "true");
                //await SecureStorage.Default.SetAsync("pseudo", pseudo);
                //await SecureStorage.Default.SetAsync("idUser", userConnected.id.ToString());

                //await Navigation.PushAsync(new TabbedBarPage.TabbedBarPage());
                await Navigation.PopAsync();

                //await Shell.Current.GoToAsync("../../PlayPage");
            }
            else
            {
                if ((int)response.StatusCode == 404)
                    await DisplayAlert("Problem", "Account not found.", "OK");
                else
                    await DisplayAlert("Problem", "Internal Server Error, try later.", "OK");
            }
        }

        private async void OnReturnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
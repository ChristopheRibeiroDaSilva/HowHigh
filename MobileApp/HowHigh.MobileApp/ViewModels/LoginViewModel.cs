using CommunityToolkit.Mvvm.Input;
using HowHigh.MobileApp.Views;
using HowHigh.MobileApp.Services;
using HowHigh.Models.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowHigh.MobileApp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userservice;

        private Color textColor;
        private string userName;
        private string password;

        public Color TextColor
        {
            get => textColor;
            //set => SetProperty(ref textColor, value);
        }
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public Command LoginCommand { get; }
        public Command ContinueAsGuestCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogInClickedAsync);
            ContinueAsGuestCommand = new Command(OnContinueAsGuestClickedAsync);
        }

        private async void OnContinueAsGuestClickedAsync()
        {
            await Shell.Current.GoToAsync("///Play");
        }

        private async void OnLogInClickedAsync()
        {
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                return;
            }

            //https://192.168.1.9:7100/api/
            //http://192.168.1.9:5122/api/
            string apiAdress = "http://192.168.1.9:5122/api/Users/";
            HttpClient sharedClient = new HttpClient();
            HttpResponseMessage response = await sharedClient.GetAsync(apiAdress + "Login?pseudo=" + userName + "&password=" + password);

            if (response.IsSuccessStatusCode)
            {
                await SecureStorage.SetAsync("hasAuth", "true");
                await Shell.Current.GoToAsync("///Play");
            }
            else
            {
                if ((int)response.StatusCode == 404)
                    await App.Current.MainPage.DisplayAlert("Problem", "Account not found.", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Problem", "Internal Server Error, try later.", "OK");
            }
        }

    }
}

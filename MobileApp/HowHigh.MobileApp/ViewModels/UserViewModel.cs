using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HowHigh.MobileApp.Views;
using HowHigh.Models.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowHigh.MobileApp.ViewModels
{
    [QueryProperty(nameof(User), "User")]
    public partial class UserViewModel : ObservableObject
    {
        [ObservableProperty]
        public Users user;

        [ObservableProperty]
        private bool logoutbtnisvisible;
        [ObservableProperty]
        private bool loginbtnisvisible;
        [ObservableProperty]
        private bool signinbtnisvisible;

        public UserViewModel() {
            logoutbtnisvisible = true;
            loginbtnisvisible = true;
            signinbtnisvisible = true;

            /*if(user.pseudo == null)
            {
                loginbtnisvisible = true;
                signinbtnisvisible = true;
                logoutbtnisvisible = false;

            }
            else
            {
                loginbtnisvisible = false;
                signinbtnisvisible = false;
                logoutbtnisvisible = true;
            }*/
        }

        [RelayCommand]
        private async Task LogOutClickedAsync()
        {
            Preferences.Clear();
            await Shell.Current.GoToAsync("//Loading");
            
        }

        [RelayCommand]
        private async Task LogInClickedAsync()
        {
            Preferences.Set("pseudo", "test");
            await Shell.Current.GoToAsync("//Loading");
        }

    }
}

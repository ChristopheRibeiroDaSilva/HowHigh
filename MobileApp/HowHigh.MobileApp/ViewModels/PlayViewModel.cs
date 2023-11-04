using CommunityToolkit.Mvvm.ComponentModel;
using HowHigh.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowHigh.MobileApp.ViewModels
{
    //[QueryProperty(nameof(User), "User")]
    public partial class PlayViewModel : ObservableObject
    {
        [ObservableProperty]
        private Users user;

        [ObservableProperty]
        private string text;

        public PlayViewModel() {

            string pseudo = Preferences.Get("pseudo", "Guest");

            text = "Connected as " + pseudo;

        }

    }
}

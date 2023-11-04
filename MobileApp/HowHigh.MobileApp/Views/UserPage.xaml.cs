using HowHigh.MobileApp.ViewModels;
using HowHigh.Models.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HowHigh.MobileApp.Views;

public partial class UserPage : ContentPage
{
    public UserPage(UserViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
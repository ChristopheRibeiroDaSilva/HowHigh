using HowHigh.Models.Models;

namespace HowHigh.MobileApp.Views;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();

	}
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {

        Users user = IsConnected();

        await Shell.Current.GoToAsync("///User",
            new Dictionary<string, object> 
            { 
                ["User"] = user            
            });
    }

    private Users IsConnected()
    {
        Task.Delay(500).Wait();
        var pseudo = Preferences.Get("pseudo", null);
        return new Users() { pseudo = pseudo };
    }

}
using HowHigh.MobileApp.ViewModels;

namespace HowHigh.MobileApp.Views;

public partial class PlayPage : ContentPage
{
	public PlayPage(PlayViewModel pvm)
	{
        InitializeComponent();
        BindingContext = pvm;

    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
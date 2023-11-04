using HowHigh.MobileApp.Views;

namespace HowHigh.MobileApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        //Register all routes
        Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));

        Routing.RegisterRoute(nameof(PlayPage), typeof(PlayPage));
        Routing.RegisterRoute(nameof(LadderPage), typeof(LadderPage));
        Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));
    }

}
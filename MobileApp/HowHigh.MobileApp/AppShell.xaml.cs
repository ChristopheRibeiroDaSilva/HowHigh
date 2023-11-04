using HowHigh.MobileApp.Views;

namespace HowHigh.MobileApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        //Register all routes
        Routing.RegisterRoute("Loading", typeof(LoadingPage));

        Routing.RegisterRoute("Login", typeof(LoginPage));
        Routing.RegisterRoute("SignIn", typeof(SignInPage));

        Routing.RegisterRoute("Play", typeof(PlayPage));
        Routing.RegisterRoute("Ladder", typeof(LadderPage));
        Routing.RegisterRoute("User", typeof(UserPage));
    }
}
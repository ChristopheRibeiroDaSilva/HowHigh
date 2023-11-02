using HowHigh.MobileApp.Pages;

namespace HowHigh.MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());

        }
    }
}
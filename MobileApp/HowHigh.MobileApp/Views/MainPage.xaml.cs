using HowHigh.MobileApp.Views;

namespace HowHigh.MobileApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            loginBtn.Clicked += OnLogInClicked;
            signIntBtn.Clicked += OnSignInClicked;
        }

        private void OnLogInClicked(object sender, EventArgs e)
        {


        }

        private void OnSignInClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SignInPage());
        }
    }
}
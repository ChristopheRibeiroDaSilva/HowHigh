namespace HowHigh.MobileApp.Views;

public partial class SignInPage : ContentPage
{
	public SignInPage()
	{
		InitializeComponent();
        createBtn.Clicked += OnCreateClicked;
        returnBtn.Clicked += OnReturnClicked;

    }

    private void OnCreateClicked(object sender, EventArgs e)
    {


    }

    private void OnReturnClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}
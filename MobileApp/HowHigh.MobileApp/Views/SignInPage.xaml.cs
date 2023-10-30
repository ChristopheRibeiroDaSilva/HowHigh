using HowHigh.Models.Models;

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
        Users newUser = new Users();
        newUser.pseudo = PseudoInput.Text;
        newUser.password = PasswordInput.Text;
        newUser.nom = NameInput.Text;
        newUser.prenom = SurnameInput.Text;
        newUser.date_naissance = date_birth.Date;
        newUser.mail = mailInput.Text;

    }

    private void OnReturnClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}
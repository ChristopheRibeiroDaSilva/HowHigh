using HowHigh.Models.Models;
using CommunityToolkit.Maui.Markup;
using System.Net.Http.Json;
using CommunityToolkit.Maui.Behaviors;
using HowHigh.MobileApp.ViewModels;

namespace HowHigh.MobileApp.Views;

public partial class SignInPage : ContentPage
{
	public SignInPage(SignInViewModel sivm)
	{

        InitializeComponent();
        date_birth.MaximumDate = DateTime.Now;
        BindingContext = sivm;

    }

    private async void OnCreateClicked(object sender, EventArgs e)
    {

        if(String.IsNullOrEmpty(PseudoInput.Text) || PseudoInput.TextColor == Color.Parse("red"))
        {
            await DisplayAlert("Invalid Pseudo", "Please put a validate pseudo", "OK");
            PseudoInput.Placeholder = "Pseudo is required";
            PseudoInput.PlaceholderColor = Color.Parse("red");
            return;
        }
        if (String.IsNullOrEmpty(PasswordInput.Text)|| PasswordInput.TextColor == Color.Parse("red"))
        {
            await DisplayAlert("Invalid Password", "Please put a validate password", "OK");
            PasswordInput.Placeholder = "Password is required";
            PasswordInput.PlaceholderColor = Color.Parse("red");
            return;
        }
        if (String.IsNullOrEmpty(mailInput.Text)||mailInput.TextColor == Color.Parse("red"))
        {
            await DisplayAlert("Invalid mail", "Invalid mail, please put a valid mail.", "OK");
            mailInput.Placeholder = "Valid Mail is required.";
            mailInput.PlaceholderColor = Color.Parse("red");
            return;
        }

        Users newUser = new Users();
        newUser.pseudo = PseudoInput.Text;
        newUser.password = PasswordInput.Text;
        newUser.nom = NameInput.Text;
        newUser.prenom = SurnameInput.Text;
        newUser.date_naissance = date_birth.Date;
        newUser.mail = mailInput.Text;

        //https://192.168.1.9:7100/api/
        //http://192.168.1.9:5122/api/
        string apiAdress = "http://192.168.1.9:5122/api/Users/";
        HttpClient sharedClient = new HttpClient();
        HttpResponseMessage response = await sharedClient.PostAsJsonAsync(apiAdress + "CreateUser", newUser);

        if(response.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Account created", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            if((int)response.StatusCode == 403)
                await DisplayAlert("Problem", "Account already exist, change mail or pseudo", "OK");
            else
                await DisplayAlert("Problem", "Internal Server Error, try later.", "OK");
        }
    }

    private async void OnReturnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
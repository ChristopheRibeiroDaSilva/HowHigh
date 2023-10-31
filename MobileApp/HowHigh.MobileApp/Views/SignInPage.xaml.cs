using HowHigh.Models.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Net.Http.Json;

namespace HowHigh.MobileApp.Views;

public partial class SignInPage : ContentPage
{
	public SignInPage()
	{
		InitializeComponent();

        createBtn.Clicked += OnCreateClicked;
        returnBtn.Clicked += OnReturnClicked;
        date_birth.MaximumDate = DateTime.Now;

    }

    private async void OnCreateClicked(object sender, EventArgs e)
    {
        Users newUser = new Users();
        newUser.pseudo = PseudoInput.Text;
        newUser.password = PasswordInput.Text;
        newUser.nom = NameInput.Text;
        newUser.prenom = SurnameInput.Text;
        newUser.date_naissance = date_birth.Date;
        newUser.mail = mailInput.Text;

        if(String.IsNullOrEmpty(newUser.pseudo))
        {
            PseudoInput.Placeholder = "Pseudo is required";
            PseudoInput.PlaceholderColor = Color.Parse("red");
            return;
        }
        if (String.IsNullOrEmpty(newUser.password))
        {
            PasswordInput.Placeholder = "Pasword is required";
            PasswordInput.PlaceholderColor = Color.Parse("red");
            return;
        }

        //https://192.168.1.9:7100/api/
        //http://192.168.1.9:5122/api/
        string apiAdress = "http://192.168.1.9:5122/api/Users/";
        HttpClient sharedClient = new HttpClient();
        HttpResponseMessage response = await sharedClient.PostAsJsonAsync(apiAdress + "CreateUser", newUser);

        if(response.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Account created", "OK");
            Navigation.PopModalAsync();
        }
        else
        {
            if((int)response.StatusCode == 403)
                await DisplayAlert("Problem", "Account already exist, change mail or pseudo", "OK");
            else
                await DisplayAlert("Problem", "Internal Server Error, try later.", "OK");
        }
    }

    private void OnReturnClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}
using SQLite;
using System;
using System.IO;
using UniversityAdvisor.Models;
using Xamarin.Forms;

namespace UniversityAdvisor.Views
{
    public class LoginPage : ContentPage
    {
        private readonly Entry _emailEntry;
        private readonly Entry _passwordEntry;
        private readonly Button _loginButton;
        private readonly Button _registerButton;
        private readonly string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "uniAdv.db3");

        public LoginPage()
        {
            Title = "Prisijungti";

            StackLayout stackLayout = new StackLayout();

            _emailEntry = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "El. paštas"
            };
            stackLayout.Children.Add(_emailEntry);

            _passwordEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                IsPassword = true,
                Placeholder = "Slaptažodis"
            };
            stackLayout.Children.Add(_passwordEntry);

            _loginButton = new Button
            {
                Text = "Prisijungti"
            };
            _loginButton.Clicked += _loginButton_Clicked;
            stackLayout.Children.Add(_loginButton);

            _registerButton = new Button
            {
                Text = "Registruotis"
            };
            _registerButton.Clicked += _registerButton_Clicked;
            stackLayout.Children.Add(_registerButton);

            Content = stackLayout;
        }

        private async void _registerButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void _loginButton_Clicked(object sender, EventArgs e)
        {
            User user = App.Repository.FindUser(_emailEntry.Text, _passwordEntry.Text);
            if (user != null)
            {
                await Navigation.PushAsync(new MenuPage(user));
            }
            else
            {
                await DisplayAlert("", "Neteisingas el. paštas ir/ar slaptažodis.", "OK");
            }
        }
    }
}
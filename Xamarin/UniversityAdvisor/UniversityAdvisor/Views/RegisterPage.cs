using SQLite;
using System;
using System.IO;
using System.Linq;
using UniversityAdvisor.Models;
using Xamarin.Forms;

namespace UniversityAdvisor.Views
{
    public class RegisterPage : ContentPage
    {
        private readonly Entry _nameEntry;
        private readonly Entry _emailEntry;
        private readonly Entry _passwordEntry;
        private readonly Button _registerButton;
        private readonly string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "uniAdv.db3");
        
        public RegisterPage()
        {
            Title = "Registruotis";

            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Vardas"
            };
            stackLayout.Children.Add(_nameEntry);

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
            User newUser = new User
            {
                Name = _nameEntry.Text,
                Email = _emailEntry.Text,
                Password = _passwordEntry.Text
            };
            if (!App.Repository.UserExists(newUser))
            {
                App.Repository.InsertUser(newUser);
                await DisplayAlert("", "Registracija sėkminga.", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("", "Šis el. paštas jau užregistruotas.", "OK");
            }
        }
    }
}
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
            Title = "Register";

            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Name"
            };
            stackLayout.Children.Add(_nameEntry);

            _emailEntry = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "Email Address"
            };
            stackLayout.Children.Add(_emailEntry);

            _passwordEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                IsPassword = true,
                Placeholder = "Password"
            };
            stackLayout.Children.Add(_passwordEntry);

            _registerButton = new Button
            {
                Text = "Register"
            };
            _registerButton.Clicked += _registerButton_Clicked;
            stackLayout.Children.Add(_registerButton);

            Content = stackLayout;
        }

        private async void _registerButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<User>();

            if (!db.Table<User>().Where(u => u.Email == _emailEntry.Text).Any())
            {
                User user = new User()
                {
                    Name = _nameEntry.Text,
                    Email = _emailEntry.Text,
                    Password = _passwordEntry.Text
                };
                db.Insert(user);
                await DisplayAlert("", "Registration successful.", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("", "This email is already used.", "OK");
            }
        }
    }
}
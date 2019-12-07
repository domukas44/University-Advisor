using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UniversityAdvisor.Models;
using Xamarin.Forms;

namespace UniversityAdvisor.Views
{
    public class LoginPage : ContentPage
    {
        private Entry _emailEntry;
        private Entry _passwordEntry;
        private Button _loginButton;
        private Button _registerButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "uniAdv.db3");
        public LoginPage()
        {
            this.Title = "Login";

            StackLayout stackLayout = new StackLayout();

            _emailEntry = new Entry();
            _emailEntry.Keyboard = Keyboard.Email;
            _emailEntry.Placeholder = "Email";
            stackLayout.Children.Add(_emailEntry);

            _passwordEntry = new Entry();
            _passwordEntry.Keyboard = Keyboard.Text;
            _passwordEntry.IsPassword = true;
            _passwordEntry.Placeholder = "Password";
            stackLayout.Children.Add(_passwordEntry);

            _loginButton = new Button();
            _loginButton.Text = "Login";
            _loginButton.Clicked += _loginButton_Clicked;
            stackLayout.Children.Add(_loginButton);

            _registerButton = new Button();
            _registerButton.Text = "Register";
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
            var db = new SQLiteConnection(_dbPath);
            var user = db.Table<User>().Where(u => u.Email == _emailEntry.Text && u.Password == _passwordEntry.Text).FirstOrDefault();
            if (user != null)
            {
                await Navigation.PushAsync(new MenuPage(user));
            }
            else
            {
                await DisplayAlert("", "Wrong email and/or password.", "OK");
            }
        }
    }
}
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
    public class RegisterPage : ContentPage
    {
        private Entry _nameEntry;
        private Entry _emailEntry;
        private Entry _passwordEntry;
        private Button _registerButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "uniAdv.db3");
        
        public RegisterPage()
        {
            this.Title = "Register";

            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Name";
            stackLayout.Children.Add(_nameEntry);

            _emailEntry = new Entry();
            _emailEntry.Keyboard = Keyboard.Text;
            _emailEntry.Placeholder = "Email Address";
            stackLayout.Children.Add(_emailEntry);

            _passwordEntry = new Entry();
            _passwordEntry.Keyboard = Keyboard.Text;
            _passwordEntry.Placeholder = "Password";
            stackLayout.Children.Add(_passwordEntry);

            _registerButton = new Button();
            _registerButton.Text = "Register";
            _registerButton.Clicked += _registerButton_Clicked;
            stackLayout.Children.Add(_registerButton);

            Content = stackLayout;

        }

        private async void _registerButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<User>();

            User user = new User()
            {
                Name = _nameEntry.Text,
                Email = _emailEntry.Text,
                Password = _passwordEntry.Text
            };
            db.Insert(user);
        }
    }
}
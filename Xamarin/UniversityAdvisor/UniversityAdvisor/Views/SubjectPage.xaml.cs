using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UniversityAdvisor.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversityAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectPage : ContentPage
    {
        Subject Subject;
        User User;

        public SubjectPage(User user, Subject subject)
        {
            InitializeComponent();
            this.User = user;
            this.Subject = subject;
            nameLabel.Text = subject.Name;
            ratingLabel.Text = subject.Rating.ToString();

            this.BindingContext = new Review();
        }

        private async void SendButtonClicked(object sender, System.EventArgs e)
        {
            if (ratingPicker.SelectedIndex >= 0)
            {
                var review = (Review)this.BindingContext;
                review.SubjectName = Subject.Name;
                review.Author = User.Email;
                
                await App.Database.SaveItemAsync(review);
                await DisplayAlert("", "Atsiliepimas sėkmingai išsiųstas.", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
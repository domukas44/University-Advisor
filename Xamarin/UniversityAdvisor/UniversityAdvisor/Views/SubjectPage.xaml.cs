using SQLite;
using System;
using System.IO;
using UniversityAdvisor.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversityAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectPage : ContentPage
    {
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "uniAdv.db3");
        Subject subject;
        User user;
        public SubjectPage(User u, Subject s)
        {
            InitializeComponent();
            user = u;
            subject = s;
            nameLabel.Text = subject.Name;
            ratingLabel.Text = subject.Rating.ToString();
        }

        private async void SendButtonClicked(object sender, System.EventArgs e)
        {
            if(ratingPicker.SelectedIndex >= 0)
            {
                var db = new SQLiteConnection(_dbPath);
                db.CreateTable<Review>();
                var r = new Review { Id = db.Table<Review>().Count(), SubjectName = subject.Name, Comment = reviewEntry.Text, Rating = Convert.ToInt32(ratingPicker.SelectedItem), Author = user.Email };
                db.Insert(r);
                await DisplayAlert("", "Atsiliepimas sėkmingai išsiųstas.", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
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
        private Subject subject;
        private readonly User user;
        private readonly MenuPage menu;
        private readonly string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "uniAdv.db3");

        public SubjectPage(User user, MenuPage menu, Subject subject)
        {
            InitializeComponent();
            this.user = user;
            this.menu = menu;
            this.subject = subject;
            nameLabel.Text = subject.Name;
            ratingLabel.Text = subject.Rating.ToString();

            BindingContext = new Review();
        }

        private async void SendButtonClicked(object sender, System.EventArgs e)
        {
            if (ratingPicker.SelectedIndex >= 0)
            {
                var db = new SQLiteConnection(_dbPath);

                var review = (Review)BindingContext;
                review.SubjectName = subject.Name;
                review.Author = user.Email;

                var ratingSum = subject.Rating * subject.ReviewCount;
                ratingSum += review.Rating;
                subject.ReviewCount++;
                subject.Rating = ratingSum / subject.ReviewCount;
                // UpdateSubjectRating(subject);
                menu.PopulateSubjectList();         // update menu subject list

                //await App.reviewDB.SaveItemAsync(review);
                await DisplayAlert("", "Atsiliepimas sėkmingai išsiųstas.", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
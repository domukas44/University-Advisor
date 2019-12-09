using UniversityAdvisor.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversityAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectPage : ContentPage
    {
        private readonly Subject Subject;
        private readonly User User;

        public SubjectPage(User user, Subject subject)
        {
            InitializeComponent();
            User = user;
            Subject = subject;
            nameLabel.Text = subject.Name;
            ratingLabel.Text = subject.Rating.ToString();

            BindingContext = new Review();
        }

        private async void SendButtonClicked(object sender, System.EventArgs e)
        {
            if (ratingPicker.SelectedIndex >= 0)
            {
                var review = (Review)BindingContext;
                review.SubjectName = Subject.Name;
                review.Author = User.Email;
                
                await App.Database.SaveItemAsync(review);
                await DisplayAlert("", "Atsiliepimas sėkmingai išsiųstas.", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
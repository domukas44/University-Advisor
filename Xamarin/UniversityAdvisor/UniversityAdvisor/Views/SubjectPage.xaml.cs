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
                var review = (Review)BindingContext;
                review.SubjectName = subject.Name;
                review.Author = user.Email;
                if (review.Comment == null || review.Comment.Equals(""))
                {
                    review.Comment = "[empty]";
                }

                await App.ReviewManager.SaveReviewAsync(review, true);   // saves review and accordingly updates the subject's rating
                menu.PopulateSubjectList();      // update menu subject list

                await DisplayAlert("", "Atsiliepimas sėkmingai išsiųstas.", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("", "Būtina pasirinkti įvertinimą.", "OK");
            }
        }
    }
}
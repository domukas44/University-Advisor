using UniversityAdvisor.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversityAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectPage : ContentPage
    {
        Subject subject;
        public SubjectPage(Subject s)
        {
            InitializeComponent();
            subject = s;
            nameLabel.Text = subject.Name;
            ratingLabel.Text = subject.Rating.ToString();
        }
    }
}
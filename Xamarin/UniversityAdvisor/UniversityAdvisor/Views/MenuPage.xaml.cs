using UniversityAdvisor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;

namespace UniversityAdvisor.Views
{
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        private List<Subject> subjects;
        private readonly User user;

        public MenuPage()
        {
            InitializeComponent();
            PopulateSubjectList();
        }

        public MenuPage(User u)
        {
            InitializeComponent();
            PopulateSubjectList();
            user = u;
        }

        public async void PopulateSubjectList()
        {
            subjects = await App.SubjectManager.GetSubjectsAsync();
            ListViewMenu.ItemsSource = subjects;
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    subjects.Sort((Subject a, Subject b) => a.Name.CompareTo(b.Name));
                    break;
                case 1:
                    subjects.Sort((Subject a, Subject b) => b.Rating.CompareTo(a.Rating));
                    break;
                default:
                    break;
            }

            ListViewMenu.ItemsSource = null;
            ListViewMenu.ItemsSource = subjects;
        }

        private async void ItemSelected(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new SubjectPage(user, this, subjects.ElementAt(e.ItemIndex)));
        }
    }
}
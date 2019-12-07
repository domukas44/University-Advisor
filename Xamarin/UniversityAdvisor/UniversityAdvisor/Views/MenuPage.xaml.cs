using UniversityAdvisor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.IO;
using System.Linq;
using UniversityAdvisor.Services;

namespace UniversityAdvisor.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "uniAdv.db3");
        List<Subject> subjects;
        SubjectDataStore sds;
        User user;

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

        private async void PopulateSubjectList()
        {
            sds = new SubjectDataStore();
            subjects = (await sds.GetItemsAsync()).ToList(); 
            menuItems = new List<HomeMenuItem>();
            foreach (Subject s in subjects)
            {
                menuItems.Add(new HomeMenuItem { Id = Convert.ToInt32(s.Id), Title = s.Name, Rating = s.Rating });
            };
            ListViewMenu.ItemsSource = menuItems;
        }
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    menuItems.Sort((HomeMenuItem a, HomeMenuItem b) => a.Title.CompareTo(b.Title));
                    break;
                case 1:
                    menuItems.Sort((HomeMenuItem a, HomeMenuItem b) => b.Rating.CompareTo(a.Rating));
                    break;
                default:
                    break;
            }

            ListViewMenu.ItemsSource = null;
            ListViewMenu.ItemsSource = menuItems;
        }
        private async void ItemSelected(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new SubjectPage(user, subjects.ElementAt(e.ItemIndex)));
        }
    }
}
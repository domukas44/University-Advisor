using UniversityAdvisor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.IO;
using System.Linq;
using System.Data;

namespace UniversityAdvisor.Views
{
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        private List<HomeMenuItem> menuItems;
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

        private void PopulateSubjectList()
        {
            DataTable data = SubjectDataTable.GetTable();

            subjects = new List<Subject>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Subject subject = new Subject
                {
                    Id = Convert.ToInt32(data.Rows[i]["Id"]),
                    Name = data.Rows[i]["Name"].ToString(),
                    Rating = Convert.ToDouble(data.Rows[i]["Rating"])
                };
                subjects.Add(subject);
            }

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
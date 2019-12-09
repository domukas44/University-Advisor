using UniversityAdvisor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;
using System.Data;

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

        public void PopulateSubjectList()
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
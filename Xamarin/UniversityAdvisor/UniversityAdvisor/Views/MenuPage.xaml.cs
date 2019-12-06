using UniversityAdvisor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
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

        SubjectDataStore sds;

        public MenuPage()
        {
            InitializeComponent();
            PopulateSubjectList();
        }

        private async void PopulateSubjectList()
        {
            sds = new SubjectDataStore();
            var subjects = await sds.GetItemsAsync(); 
            menuItems = new List<HomeMenuItem>();
            foreach (Subject s in subjects)
            {
                menuItems.Add(new HomeMenuItem { Id = Convert.ToInt32(s.Id), Title = s.Name + ", " + s.Rating });
            };
            ListViewMenu.ItemsSource = menuItems;
        }
    }
}
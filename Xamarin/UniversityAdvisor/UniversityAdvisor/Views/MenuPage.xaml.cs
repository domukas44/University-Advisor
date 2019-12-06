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

            /*menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = 0, Title="Browse" },
                new HomeMenuItem {Id = 1, Title="About" },
                new HomeMenuItem {Id = 2, Title="Register" }

            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {

                //var user = (User)BindingContext;
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };*/



            ListViewMenu = new ListView();
            PopulateSubjectList();

            /*menuItems = new List<HomeMenuItem>();
            foreach (Subject s in ListViewMenu.ItemsSource)
            {
                menuItems.Add(new HomeMenuItem { Id = Convert.ToInt32(s.Id), Title = s.Name + "\t" + s.Rating });
            };
            ListViewMenu.ItemsSource = menuItems;*/

        }

        private async void PopulateSubjectList()
        {
            sds = new SubjectDataStore();
            ListViewMenu.ItemsSource = await sds.GetItemsAsync();
            await DisplayAlert("", "ok", "ok");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UniversityAdvisor.Models;
using SQLite;
using System.Collections.ObjectModel;
using System.Data;

namespace UniversityAdvisor.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
       // SQLiteAsyncConnection conn = DependencyService.Get<ISqlConnection>().Connection();

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;

           // conn.CreateTableAsync<User>();
            ReadData();

            MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public ObservableCollection<User> UserList { get; set; }

        private void Save(object sender, EventArgs e)
        {
            //conn.InsertAsync(new User() { });

            ReadData();
        }

        public void ReadData()
        {

           // var list = conn.Table<User>().ToListAsync().Result;

            //UserList = new ObservableCollection<User>(list);
           // UsersList.ItemsSource = UserList;
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case 0:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case 1:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case 2:
                        MenuPages.Add(id, new NavigationPage(new RegisterPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
﻿using Xamarin.Forms;
using UniversityAdvisor.Views;
using UniversityAdvisor.Data;

namespace UniversityAdvisor
{
    public partial class App : Application
    {
        public static SubjectManager SubjectManager { get; set; }
        public static ReviewManager ReviewManager { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

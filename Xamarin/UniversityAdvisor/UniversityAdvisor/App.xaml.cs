using System;
using Xamarin.Forms;
using UniversityAdvisor.Views;
using UniversityAdvisor.Data;
using System.IO;

namespace UniversityAdvisor
{
    public partial class App : Application
    {
        public static ReviewDatabase reviewDB;
        public static SubjectDatabase subjectDB;

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

        public static ReviewDatabase ReviewDB
        {
            get
            {
                if (reviewDB == null)
                {
                    reviewDB = new ReviewDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "review.db3"));
                }
                return reviewDB;
            }
        }

        public static SubjectDatabase SubjectDB
        {
            get
            {
                if (subjectDB == null)
                {
                    subjectDB = new SubjectDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "subject.db3"));
                }
                return subjectDB;
            }
        }
    }
}

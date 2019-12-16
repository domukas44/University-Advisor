using Xamarin.Forms;
using UniversityAdvisor.Views;
using UniversityAdvisor.Data;
using Microsoft.EntityFrameworkCore;
using UniversityAdvisor.Repositories;

namespace UniversityAdvisor
{
    public partial class App : Application
    {
        public static SubjectManager SubjectManager { get; set; }
        public static ReviewManager ReviewManager { get; set; }

        private static Context _context = null;
        public static Repository Repository { get; set; } = new Repository();

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }
        public static Context Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new Context();
                    _context.Database.EnsureCreated();
                    _context.Database.Migrate();
                }
                return _context;
            }
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

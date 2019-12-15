﻿using System;
using Xamarin.Forms;
using UniversityAdvisor.Views;
using UniversityAdvisor.Data;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace UniversityAdvisor
{
    public partial class App : Application
    {
        public static ReviewDatabase database;
        private static Context _context = null;

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

        public static ReviewDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ReviewDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Review.db3"));
                }
                return database;
            }
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
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db");
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}

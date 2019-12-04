using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityAdvisor.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        [PrimaryKey]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
